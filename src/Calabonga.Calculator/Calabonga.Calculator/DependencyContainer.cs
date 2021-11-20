using System;
using Calabonga.Calculator.Contracts;
using Calabonga.Calculator.Shell.Factories;
using Calabonga.Calculator.Shell.Providers;
using Calabonga.Calculator.Shell.Services;
using Calabonga.Calculator.Shell.Services.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Calculator.Shell
{
    internal static class DependencyContainer
    {
        internal static IServiceProvider GetContainer()
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
            services.AddTransient<OutputProvider>();
            services.AddTransient<OutputSelectionFactory>();
            services.AddOptions<ApplicationSettings>();
            services.Configure<ApplicationSettings>(configuration.GetSection(nameof(ApplicationSettings)));

            // Registration operations
            services.AddTransient<IOperation, AdditionOperation>();
            services.AddTransient<IOperation, DivisionOperation>();
            services.AddTransient<IOperation, SubtractOperation>();
            services.AddTransient<IOperation, MultiplicationOperation>();

            // Creating ServiceProvider
            return services.BuildServiceProvider();
        }
    }
}