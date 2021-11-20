using System;
using Calabonga.Calculator.Contracts;

namespace Calabonga.Calculator.ExponentialOperations
{
    public class ExponentialOperation: IOperation
    {
        public string ShortName => "e";
        public string Name => "Exponential";
        public string Description => "Exponential operation between two numbers";
        public float Execute(float number1, float number2)
        {
            var int1 = Convert.ToInt16(number1);
            var int2 = Convert.ToInt16(number2);
            return (float)Math.Pow(int1, int2);
        }
    }
}
