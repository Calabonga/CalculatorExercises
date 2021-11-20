using System;
using System.IO;
using Calabonga.Calculator.Shell.Services.Base;

namespace Calabonga.Calculator.Shell.Services
{
    public class FileOutputService : OutputServiceBase
    {
        private const string FileName = "output.txt";
        private const string FolderName = "Logs";

        /// <summary>
        /// Выводит на экран консоли текст сообщения
        /// </summary>
        /// <param name="message"></param>
        protected override void Output(string message)
        {
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FolderName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using var file = File.AppendText(Path.Combine(path, FileName));
                file.WriteLine(message);
            }
            catch
            {
                throw;
            }
        }
    }
}
