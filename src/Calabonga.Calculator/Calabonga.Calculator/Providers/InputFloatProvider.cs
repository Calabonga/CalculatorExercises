using Calabonga.Calculator.Shell.Factories;
using Calabonga.Calculator.Shell.Services;
using Calabonga.Calculator.Shell.Services.Base;

namespace Calabonga.Calculator.Shell.Providers
{
    public class InputFloatProvider
    {
        private readonly IOutputService _outputService;
        private readonly InputStringService _inputStringService;

        public InputFloatProvider(OutputSelectionFactory outputServiceFactory, InputStringService inputStringService)
        {
            _outputService = outputServiceFactory.GetOutputService();
            _inputStringService = inputStringService;
        }

        /// <summary>
        /// Returns parsed number
        /// </summary>
        /// <returns></returns>
        public float GetNumber()
        {
            float number;
            bool isInputValid;
            do
            {
                var numberString = _inputStringService.GetStringFromUser();
                var numberParsed = float.TryParse(numberString, out number);
                isInputValid = numberParsed;
                if (!numberParsed)
                {
                    _outputService.Print("Wrong number, please try again enter a valid float number:");
                }
            } while (!isInputValid);

            return number;
        }
    }
}
