namespace Calabonga.Calculator.Services.Base
{
    /// <summary>
    /// Сервис вывода информации пользователю
    /// </summary>
    public interface IOutputService
    {
        /// <summary>
        /// Вывод информации пользователю
        /// </summary>
        /// <param name="message"></param>
        void Print(string message);
    }
}
