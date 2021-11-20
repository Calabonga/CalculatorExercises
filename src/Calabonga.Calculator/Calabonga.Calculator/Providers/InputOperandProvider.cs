using System.Collections.Generic;
using System.Linq;
using Calabonga.Calculator.Contracts;
using Calabonga.Calculator.Shell.Factories;
using Calabonga.Calculator.Shell.Services;
using Calabonga.Calculator.Shell.Services.Base;

namespace Calabonga.Calculator.Shell.Providers
{
    public class InputOperandProvider
    {
        private readonly IOutputService _outputService;
        private readonly IEnumerable<IOperation> _operations;
        private readonly InputStringService _inputStringService;

        public InputOperandProvider(
            IEnumerable<IOperation> operations,
            OutputSelectionFactory outputServiceFactory, 
            InputStringService inputStringService)
        {
            _outputService = outputServiceFactory.GetOutputService();
            _operations = operations;
            _inputStringService = inputStringService;
        }

        /// <summary>
        /// Returns OperandType
        /// </summary>
        /// <returns></returns>
        public IOperation? GetOperand()
        {
            if (!_operations.Any())
            {
                return null;
            }

            var messages = _operations.Select(x => $"[{x.ShortName}] {x.Name}. {x.Description}");

            _outputService.Print("Select operation:");
            _outputService.Print(string.Join("\n", messages));

            var operandString = _inputStringService.GetStringFromUser();
            return _operations.FirstOrDefault(x => x.ShortName.Equals(operandString));
        }
    }
}
