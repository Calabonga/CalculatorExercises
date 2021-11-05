using Calabonga.Calculator.Services;

namespace Calabonga.Calculator.Providers
{
    public class InputOperandProvider
    {
        private readonly OutputService _outputService;
        private readonly InputStringService _inputStringService;

        public InputOperandProvider(OutputService outputService, InputStringService inputStringService)
        {
            _outputService = outputService;
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
