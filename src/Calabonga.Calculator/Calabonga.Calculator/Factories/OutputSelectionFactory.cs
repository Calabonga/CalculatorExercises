using System.Collections.Generic;
using System.Linq;
using Calabonga.Calculator.Services;
using Calabonga.Calculator.Services.Base;

namespace Calabonga.Calculator.Factories
{
    public class OutputSelectionFactory
    {
        private readonly IEnumerable<IOutputService> _outputServices;

        public OutputSelectionFactory(IEnumerable<IOutputService> outputServices)
        {
            _outputServices = outputServices;
        }

        public IOutputService GetOutputService(bool isUserConsole = true)
        {
            if (isUserConsole)
            {
                return _outputServices.First(x => x.GetType() == typeof(ConsoleOutputService));
            }
            return _outputServices.First(x => x.GetType() == typeof(MessageBoxOutputService));
        }
    }
}
