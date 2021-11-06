using System;
using System.Linq;
using Calabonga.Calculator.Providers;
using Calabonga.Calculator.Services;
using Calabonga.Calculator.Services.Base;

namespace Calabonga.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!args.Any())
            {
                throw new ArgumentNullException();
            }

            IOutputService outputService;

            var values = args[0].Split('=');
            if (values[1] == "console")
            {
                outputService = new ConsoleOutputService();
            }
            else
            {
                outputService = new MessageBoxOutputService();
            }

            // Creating instances
            var inputStringService = new InputStringService();
            var inputService = new InputFloatProvider(outputService, inputStringService);
            var parseOperandService = new InputOperandProvider(outputService, inputStringService);
            var calculateService = new CalculatorProvider(outputService);

            // Welcome
            outputService.Print("Calculator v3.0.0");

            // Getting first number
            outputService.Print("Enter first number (float)");
            var number1 = inputService.GetNumber();

            // Getting second number
            outputService.Print("Enter second number (float)");
            var number2 = inputService.GetNumber();

            // Getting Operand
            var operand = parseOperandService.GetOperand();
            if (operand == OperandType.None)
            {
                outputService.Print("Wrong operand. Good bye!");
                return;
            }

            // Calculation 
            var result = calculateService.Compute(number1, number2, operand);
            if (result is not null)
            {
                outputService.Print(result.Value.ToString("F"));
            }
        }

    }
}
