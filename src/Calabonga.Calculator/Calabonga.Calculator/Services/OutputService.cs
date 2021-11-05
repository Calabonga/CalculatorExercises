using System;

namespace Calabonga.Calculator.Services
{
    /// <summary>
    /// Простой сервис печати
    /// </summary>
    public class OutputService
    {
        /// <summary>
        /// Выводит на экран консоли текст сообщения
        /// </summary>
        /// <param name="message"></param>
        public void Print(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            Console.WriteLine(message);
        }
    }
}
