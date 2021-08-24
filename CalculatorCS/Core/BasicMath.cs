namespace CalculatorCS.Core
{
    public static class BasicMath
    {
        public static double Add(double x, double y) => (x + y);
        public static double Subtract(double x, double y) => (x - y);
        public static double Multiply(double x, double y) => (x * y);
        public static double Divide(double x, double y) => (x / y);
        public static double DoNothing(double x, double y) => 0;
    }
}