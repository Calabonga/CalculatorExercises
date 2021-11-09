using System.Windows.Forms;
using Calabonga.Calculator.Services.Base;

namespace Calabonga.Calculator.Services
{
    public class MessageBoxOutputService: OutputServiceBase
    {
        /// <summary>
        /// Выводит на экран консоли текст сообщения
        /// </summary>
        /// <param name="message"></param>
        protected override void Output(string message)
        {
            MessageBox.Show(message);
        }
    }
}
