using Calabonga.Calculator.Contracts;

namespace Calabonga.Calculator.AdditionOperations
{
    public class AdditionOperation : IOperation
    {
        public string Name => "Addition";

        public string ShortName => "+";

        public string Description => "Adds two number operation";

        public float Execute(float number1, float number2)
        {
            return number1 + number1;
        }
    }
}