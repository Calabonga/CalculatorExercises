using System;
using System.Collections.Generic;
using System.Linq;
using Calabonga.Calculator.Factories;
using Calabonga.Calculator.Providers;
using Calabonga.Calculator.Services;
using Calabonga.Calculator.Services.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Calabonga.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Registering objects
            var services = new ServiceCollection();
            services.AddTransient<IOutputService, ConsoleOutputService>();
            services.AddTransient<IOutputService, FileOutputService>();
            services.AddTransient<InputStringService>();
            services.AddTransient<InputFloatProvider>();
            services.AddTransient<InputOperandProvider>();
            services.AddTransient<CalculatorProvider>();
            services.AddTransient<OutputProvider>();
            services.AddTransient<OutputSelectionFactory>();
            services.AddOptions<ApplicationSettings>();
            services.Configure<ApplicationSettings>(configuration.GetSection(nameof(ApplicationSettings)));
            
            // Creating ServiceProvider
            var serviceProvider = services.BuildServiceProvider();

            // Resolving objects
            var outputServices = serviceProvider.GetServices<IOutputService>();
            var inputFloatProvider = serviceProvider.GetRequiredService<InputFloatProvider>();
            var inputOperandProvider = serviceProvider.GetRequiredService<InputOperandProvider>();
            var calculatorProvider = serviceProvider.GetRequiredService<CalculatorProvider>();
            var outputSelectionFactory = serviceProvider.GetRequiredService<OutputSelectionFactory>();

            var outputService = outputSelectionFactory.GetOutputService();

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
                var provider = serviceProvider.GetRequiredService<OutputProvider>();
                provider.Print(result.Value.ToString("F"));
            }
        }
    }
}
