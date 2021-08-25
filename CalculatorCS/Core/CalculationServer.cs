using System;
using System.Text;
using System.Threading.Tasks;
using CalculatorCS.MVVM.Models;

namespace CalculatorCS.Core
{
    public class CalculationServer : ObservableObject
    {
        public delegate void Callback(string msg);
        public delegate string Arithmetic(string x, string y);

        public Modes CurrentMode { get; set; }
        
        private readonly StringBuilder _firstArgument = new StringBuilder();
        private readonly StringBuilder _secondArgument = new StringBuilder();
        private bool IsOperationActive => ActiveOperation.Length > 0;
        private string ActiveOperation { get; set; } = string.Empty;
        public Callback MainScreenCallback { get; set; }
        public Callback SecondaryScreenCallback { get; set; }

        private CalculationServer()
        {
            
        }

        public void ProvideNumber(string number)
        {
            if (IsOperationActive)
            {
                _secondArgument.Append(number);
                MainScreenCallback(_secondArgument.ToString());
                SecondaryScreenCallback(_firstArgument + ActiveOperation);
                return;
            }

            _firstArgument.Append(number);
            MainScreenCallback(_firstArgument.ToString());
        }

        public void ProvideArithmeticOperation(string operation)
        {
            if (CurrentMode == Modes.Basic)
            {
                if (IsOperationActive)
                {
                    var result =
                        SimpleCalculator.Calculate(_firstArgument.ToString(), _secondArgument.ToString(), ActiveOperation);

                    ActiveOperation = string.Empty;

                    MainScreenCallback(result.ResultValue);
                    SecondaryScreenCallback(result.Expression);
                    
                    if (result.IsError)
                    { 
                        Clear();
                        return;
                    }
                }

                ActiveOperation = operation;
                MainScreenCallback(string.Empty);
                SecondaryScreenCallback(_firstArgument.ToString() + ActiveOperation);
                _secondArgument.Clear();
                return;
            }

            _firstArgument.Append(operation);
        }

        public void Calculate(string operation = "simplify")
        {
            if (CurrentMode == Modes.Advanced)
            {
                if (_firstArgument.Length > 0)
                {
                    Task.Run(() =>
                    {
                        var res = NewtonApi.IssueCalculation(_firstArgument.ToString(), operation);
                        if (res.Result is null)
                        {
                            Console.WriteLine("NULL");
                            return;
                        }

                        Console.WriteLine("NOT NULL");
                        MainScreenCallback(res.Result.ResultValue);
                        SecondaryScreenCallback(res.Result.ResultValue);
                    });
                }
                return;
            }

            if (!IsOperationActive) return;
            var result =
                SimpleCalculator.Calculate(_firstArgument.ToString(), _secondArgument.ToString(), ActiveOperation);

            ActiveOperation = string.Empty;

            MainScreenCallback(result.ResultValue);
            SecondaryScreenCallback(result.Expression);
                    
            if (result.IsError)
            { 
                Clear();
            }
        }

        public void Clear()
        {
            _firstArgument.Clear();
            _secondArgument.Clear();
            ActiveOperation = string.Empty;
            MainScreenCallback(string.Empty);
            SecondaryScreenCallback(string.Empty);
        }

        public void Backspace()
        {
            if (IsOperationActive)
            {
                _secondArgument.Remove(_secondArgument.Length - 1, 1);
                MainScreenCallback(_secondArgument.ToString());

                return;
            }
            _firstArgument.Remove(_firstArgument.Length - 1, 1);
            MainScreenCallback(_firstArgument.ToString());
        }

        private static readonly CalculationServer Instance = new CalculationServer();

        public static CalculationServer GetInstance()
        {
            return Instance;
        }
    }
}