using System;
using System.Text;
using System.Threading.Tasks;
using CalculatorCS.MVVM.Models;

namespace CalculatorCS.Core
{
    public class CalculationServer : ObservableObject
    {
        public delegate void Callback(string mainMsg, string secondaryMsg);
        public delegate string Arithmetic(string x, string y);

        public Modes CurrentMode { get; set; }
        
        private readonly StringBuilder _firstArgument = new StringBuilder();
        private readonly StringBuilder _secondArgument = new StringBuilder();
        private bool IsOperationActive => ActiveOperation.Length > 0;
        private string ActiveOperation { get; set; } = string.Empty;
        public Callback OnResult { get; set; }
        public Callback OnError { get; set; }

        private CalculationServer()
        {
            
        }

        public void ProvideNumber(string number)
        {
            Console.WriteLine("Number");
            if (IsOperationActive)
            {
                _secondArgument.Append(number);
                OnResult(_firstArgument.ToString(), _secondArgument.ToString());
                return;
            }

            _firstArgument.Append(number);
            OnResult(_firstArgument.ToString(), _secondArgument.ToString());
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
                    
                    if (result.IsError)
                    { 
                        Clear();
                        OnError(result.ResultValue, result.Expression);
                        return;
                    }

                    OnResult(result.ResultValue, result.Operation);
                }

                ActiveOperation = operation;
                _secondArgument.Clear();
                return;
            }

            _firstArgument.Append(operation);
        }

        public void Calculate(string operation = "simplify")
        {
            if (_firstArgument.Length > 0)
            {
                Task.Run(() =>
                {
                    Console.WriteLine("Hello");
                    var res = NewtonApi.IssueCalculation(_firstArgument.ToString(), operation);
                    if (res.Result is null)
                    {
                        Console.WriteLine("NULL");
                        return;
                    }
                    Console.WriteLine("Hello You: {0}", res.Result.ResultValue);
                });
            }
        }

        public void Clear()
        {
            _firstArgument.Clear();
            _secondArgument.Clear();
            ActiveOperation = string.Empty;
        }

        public void Backspace()
        {
            if (IsOperationActive)
            {
                _secondArgument.Remove(_secondArgument.Length - 1, 1);
                return;
            }
            _firstArgument.Remove(_firstArgument.Length - 1, 1);
        }

        private static readonly CalculationServer Instance = new CalculationServer();

        public static CalculationServer GetInstance()
        {
            return Instance;
        }
    }
}