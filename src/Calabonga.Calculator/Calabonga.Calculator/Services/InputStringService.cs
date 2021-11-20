using System;

namespace Calabonga.Calculator.Shell.Services
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
