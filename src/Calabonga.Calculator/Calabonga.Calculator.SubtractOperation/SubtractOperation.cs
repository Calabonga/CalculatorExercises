using Calabonga.Calculator.Contracts;

namespace Calabonga.Calculator.SubtractOperations
{
    public class SubtractOperation : IOperation
    {
        public string ShortName => "-";

        public string Name => "Subtract";

        public string Description => "Subtract two numbers operation";

        public float Execute(float number1, float number2)
        {
            return number1 - number2;
        }
    }
}