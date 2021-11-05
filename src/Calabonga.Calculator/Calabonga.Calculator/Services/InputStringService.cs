using System;

namespace Calabonga.Calculator.Services
{
    public class InputStringService
    {
        /// <summary>
        /// Returns string from user
        /// </summary>
        /// <returns></returns>
        public string? GetStringFromUser()
        {
            return Console.ReadLine();
        }
    }
}
