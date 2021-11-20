using System;
using System.IO;
using System.Linq;
using System.Reflection;
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
            var pluginsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            if (!Directory.Exists(pluginsFolder))
            {
                return services.BuildServiceProvider();
            }

            var files = Directory.GetFiles(pluginsFolder, "*.dll");
            if (!files.Any())
            {
                return services.BuildServiceProvider();
            }

            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file);
                var types = assembly.GetExportedTypes().Where(x => x.IsAssignableTo(typeof(IOperation))).ToList();
                foreach (var type in types)
                {
                    services.AddTransient(typeof(IOperation), type);
                }
            }

            // Creating ServiceProvider
            return services.BuildServiceProvider();
        }
    }
}