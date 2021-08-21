using System;

namespace CalculatorCS.Core
{
    public class CalculationServer
    {
        //public delegate void Callback(string msg);

        private CalculationServer()
        {
            
        }

        public void ProvideNumber(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Calculate()
        {
            
        }

        private static readonly CalculationServer Instance = new CalculationServer();

        public static CalculationServer GetInstance()
        {
            return Instance;
        }
    }
}