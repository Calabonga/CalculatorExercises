using Calabonga.Calculator.Contracts;

namespace Calabonga.Calculator.MultiplicationOperations
{
    public class MultiplicationOperation : IOperation
    {
        public string ShortName => "*";

        public string Name => "Multiplication";

        public string Description => "Multiplication two numbers operation";

        public float Execute(float number1, float number2)
        {
            return number1 * number2;
        }
    }
}