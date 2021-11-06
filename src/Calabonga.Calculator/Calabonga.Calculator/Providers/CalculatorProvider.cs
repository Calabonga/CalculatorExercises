﻿using Calabonga.Calculator.Services;

namespace Calabonga.Calculator.Providers
{
    public class CalculatorProvider
    {
        private readonly OutputService _outputService;

        public CalculatorProvider(OutputService outputService)
        {
            _outputService = outputService;
        }

        /// <summary>
        /// Returns calculation result
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="operand"></param>
        /// <returns></returns>
        public float? Compute(float number1, float number2, OperandType operand)
        {

            switch (operand)
            {
                case OperandType.Addition:
                    return number1 + number2;
                case OperandType.Subtraction:
                    return number1 - number2;
                case OperandType.Multiplication:
                    return number1 * number2;

                case OperandType.Division:
                    if (number2 == 0)
                    {
                        _outputService.Print("Divide by zero. Error.");
                        return null;
                    }
                    return number1 / number2;

            }
            
            return null;
        }
    }
}