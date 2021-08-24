using System;
using System.Windows.Controls;
using CalculatorCS.Core;

namespace CalculatorCS.MVVM.ViewModels
{
    public class AdvancedSidePanelViewModel
    {
        private CalculationServer Server { get; set; }
    
        public RelayCommand OperationCommand { get; set; }

        public AdvancedSidePanelViewModel()
        {
            Server = CalculationServer.GetInstance();
            OperationCommand = new RelayCommand(o =>
            {
                var button = o as Button;
                Console.WriteLine("Performing: {0}", button?.Content);
                Server.Calculate(button?.Content.ToString());
            });
        }
    }
}