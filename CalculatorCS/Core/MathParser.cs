using System.Net;
using System.Text;

namespace CalculatorCS.Core
{
    public class MathParser
    {
        public delegate double Arithmetic(double x, double y);

        public static Arithmetic ToArithmetic(string operation)
        {
            switch (operation)
            {
                case "+":
                    return BasicMath.Add;
                case "-":
                    return BasicMath.Subtract;
                case "*":
                    return BasicMath.Multiply;
                case "/":
                    return BasicMath.Divide;
                default:
                    return BasicMath.DoNothing;
            }
        }

        public static string Encode(string expression)
        {
            StringBuilder encoded = new StringBuilder(expression);
            encoded.Replace("/", "(over)");
            encoded.Replace("^", "%5E");
            encoded.Replace("+", "%2B");
            return encoded.ToString();
        }
    }
}