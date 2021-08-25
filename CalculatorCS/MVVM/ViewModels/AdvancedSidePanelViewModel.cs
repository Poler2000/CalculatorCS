using System;
using System.Windows.Controls;
using CalculatorCS.Core;

namespace CalculatorCS.MVVM.ViewModels
{
    public class AdvancedSidePanelViewModel
    {
        private CalculationServer Server { get; set; }
        public RelayCommand ClearCommand { get; set; }
        public RelayCommand BackspaceCommand { get; set; }
        public RelayCommand SpecialCharacterCommand { get; set; }
        public RelayCommand OperationCommand { get; set; }

        public AdvancedSidePanelViewModel()
        {
            Server = CalculationServer.GetInstance();
            OperationCommand = new RelayCommand(msg =>
            {
                Server.Calculate(msg.ToString());
            });
            
            ClearCommand = new RelayCommand(o =>
            {
                Server.Clear();
            });

            BackspaceCommand = new RelayCommand(o =>
            {
                Server.Backspace();
            });

            SpecialCharacterCommand = new RelayCommand(msg =>
            {
                Server.ProvideNumber(msg.ToString());
            });
        }
    }
}