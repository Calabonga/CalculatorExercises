using Calabonga.Calculator.Factories;
using Calabonga.Calculator.Services;
using Calabonga.Calculator.Services.Base;

namespace Calabonga.Calculator.Providers
{
    public class InputOperandProvider
    {
        private readonly IOutputService _outputService;
        private readonly InputStringService _inputStringService;

        public InputOperandProvider(OutputSelectionFactory outputServiceFactory, InputStringService inputStringService)
        {
            _outputService = outputServiceFactory.GetOutputService();
            _inputStringService = inputStringService;
        }

        /// <summary>
        /// Returns OperandType
        /// </summary>
        /// <returns></returns>
        public OperandType GetOperand()
        {
            _outputService.Print("Enter operand + - * /");
            var operandString = _inputStringService.GetStringFromUser();

            return operandString switch
            {
                "+" => OperandType.Addition,
                "-" => OperandType.Subtraction,
                "*" => OperandType.Multiplication,
                "/" => OperandType.Division,
                _ => OperandType.None,
            };
        }
    }
}
