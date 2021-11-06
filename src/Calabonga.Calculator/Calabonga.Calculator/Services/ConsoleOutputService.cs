using System;
using Calabonga.Calculator.Services.Base;

namespace Calabonga.Calculator.Services
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
