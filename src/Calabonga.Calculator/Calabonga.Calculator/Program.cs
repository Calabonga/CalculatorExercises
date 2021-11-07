using System;
using System.Collections.Generic;
using System.Linq;
using Calabonga.Calculator.Factories;
using Calabonga.Calculator.Providers;
using Calabonga.Calculator.Services;
using Calabonga.Calculator.Services.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Registering objects
            var services = new ServiceCollection();
            services.AddTransient<IOutputService, ConsoleOutputService>();
            services.AddTransient<IOutputService, MessageBoxOutputService>();
            services.AddTransient<InputStringService>();
            services.AddTransient<InputFloatProvider>();
            services.AddTransient<InputOperandProvider>();
            services.AddTransient<CalculatorProvider>();
            services.AddTransient<OutputSelectionFactory>();

            // Creating ServiceProvider
            var serviceProvider = services.BuildServiceProvider();

            // Resolving objects
            var outputServices = serviceProvider.GetServices<IOutputService>();
            var inputFloatProvider = serviceProvider.GetRequiredService<InputFloatProvider>();
            var inputOperandProvider = serviceProvider.GetRequiredService<InputOperandProvider>();
            var calculatorProvider = serviceProvider.GetRequiredService<CalculatorProvider>();

            var outputService = ProcessArguments(args, outputServices);

            // Welcome
            outputService.Print("Calculator v4.0.0");

            // Getting first number
            outputService.Print("Enter first number (float)");
            var number1 = inputFloatProvider.GetNumber();

            // Getting second number
            outputService.Print("Enter second number (float)");
            var number2 = inputFloatProvider.GetNumber();

            // Getting Operand
            var operand = inputOperandProvider.GetOperand();
            if (operand == OperandType.None)
            {
                outputService.Print("Wrong operand. Good bye!");
                return;
            }

            // Calculation 
            var result = calculatorProvider.Compute(number1, number2, operand);
            if (result is not null)
            {
                outputService.Print(result.Value.ToString("F"));
            }
        }

        private static IOutputService ProcessArguments(string[] args, IEnumerable<IOutputService> outputServices)
        {
            if (!args.Any())
            {
                throw new ArgumentNullException();
            }

            var values = args[0].Split('=');
            if (values[1] == "console")
            {
                return outputServices.First(x => x.GetType() == typeof(ConsoleOutputService));
            }

            return outputServices.First(x => x.GetType() == typeof(MessageBoxOutputService));
        }
    }
}
