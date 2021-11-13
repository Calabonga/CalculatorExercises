using System;
using System.Collections.Generic;
using System.Linq;
using Calabonga.Calculator.Services;
using Calabonga.Calculator.Services.Base;
using Microsoft.Extensions.Options;

namespace Calabonga.Calculator.Factories
{
    public class OutputSelectionFactory
    {
        private readonly IEnumerable<IOutputService> _outputServices;
        private readonly ApplicationSettings _applicationSettings;

        public OutputSelectionFactory(IEnumerable<IOutputService> outputServices, IOptions<ApplicationSettings> options)
        {
            _outputServices = outputServices;
            _applicationSettings = options.Value;
        }

        public IOutputService GetOutputService()
        {
            var value = _applicationSettings.DefaultService;
            return value switch
            {
                "Console" => _outputServices.First(x => x.GetType() == typeof(ConsoleOutputService)),
                "File" => _outputServices.First(x => x.GetType() == typeof(FileOutputService)),
                _ => throw new ArgumentNullException()
            };
        }
    }
}
