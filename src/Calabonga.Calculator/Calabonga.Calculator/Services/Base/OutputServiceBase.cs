using System;

namespace Calabonga.Calculator.Services.Base
{
    public abstract class OutputServiceBase: IOutputService
    {
        /// <summary>
        /// Вывод информации пользователю
        /// </summary>
        /// <param name="message"></param>
        public void Print(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            Output(message);
        }

        /// <summary>
        /// Выводит на экран консоли текст сообщения
        /// </summary>
        /// <param name="message"></param>
        protected abstract void Output(string message);
    }
}
