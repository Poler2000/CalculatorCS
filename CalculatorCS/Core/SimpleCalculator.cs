using System;
using System.Globalization;

namespace CalculatorCS.Core
{
    public static class SimpleCalculator
    {
        private static bool IsBeyondRange(double result)
        {
            return double.IsInfinity(result) || double.MaxValue - Math.Abs(result) < 0;
        }

        public static Result Calculate(string x, string y, string operation)
        {
            var arithmeticResult = new Result();
            double dblX = double.Parse(x);
            double dblY = double.Parse(y);
            
            var arithmetic = MathParser.ToArithmetic(operation);
            double result = arithmetic(dblX, dblY);
            
            if (IsBeyondRange(result))
            {
                arithmeticResult.ResultValue = "Result is beyond calculator range";
                arithmeticResult.IsError = true;
                return arithmeticResult;
            }

            if (double.IsNaN(result))
            {
                arithmeticResult.ResultValue = "Not a number";
                arithmeticResult.IsError = true;
                return arithmeticResult;
            }
            
            arithmeticResult.ResultValue = result.ToString(CultureInfo.InvariantCulture);
            arithmeticResult.IsError = false;

            return arithmeticResult;
        }
    }
}