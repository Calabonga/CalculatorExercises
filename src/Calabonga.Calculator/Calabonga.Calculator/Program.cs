using Calabonga.Calculator.Shell.Factories;
using Calabonga.Calculator.Shell.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Calculator.Shell
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating ServiceProvider
            var serviceProvider = DependencyContainer.GetContainer();

            // Resolving objects
            var inputFloatProvider = serviceProvider.GetRequiredService<InputFloatProvider>();
            var inputOperandProvider = serviceProvider.GetRequiredService<InputOperandProvider>();
            var outputSelectionFactory = serviceProvider.GetRequiredService<OutputSelectionFactory>();
            var outputService = outputSelectionFactory.GetOutputService();

            // Welcome
            outputService.Print("Calculator v6.0.0");

            // Getting first number
            outputService.Print("Enter first number (float)");
            var number1 = inputFloatProvider.GetNumber();

            // Getting second number
            outputService.Print("Enter second number (float)");
            var number2 = inputFloatProvider.GetNumber();

            // Getting Operand
            var operation = inputOperandProvider.GetOperand();
            if (operation is null)
            {
                outputService.Print("Wrong operand. Good bye!");
                return;
            }

            // Calculation 
            var result = operation.Execute(number1, number2);
            outputService.Print(result.ToString("F"));
        }
    }
}
