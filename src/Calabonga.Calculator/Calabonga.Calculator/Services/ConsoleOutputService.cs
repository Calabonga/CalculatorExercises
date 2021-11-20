using System;
using Calabonga.Calculator.Shell.Services.Base;

namespace Calabonga.Calculator.Shell.Services
{
    /// <summary>
    /// Простой сервис печати
    /// </summary>
    public class ConsoleOutputService : OutputServiceBase
    {
        protected override void Output(string message)
        {
            Console.WriteLine(message);
        }
    }
}
