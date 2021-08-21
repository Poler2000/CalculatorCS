using System;
using System.Windows.Controls;
using CalculatorCS.Core;

namespace CalculatorCS.MVVM.ViewModels
{
    public class BasicButtonsViewModel : ObservableObject
    {
        private RelayCommand _numberCommand;
        private CalculationServer Server { get; set; }
    
        public RelayCommand NumberCommand
        {
            get => _numberCommand;
            set
            {
                _numberCommand = value;
                OnPropertyChanged();
            }
        }

        public BasicButtonsViewModel()
        {
            Server = CalculationServer.GetInstance();
            NumberCommand = new RelayCommand(o =>
            {
                Console.WriteLine(o == null);
                Console.WriteLine(o?.ToString());
                var button = o as Button;
                Server.ProvideNumber(button?.Content.ToString());
            });
        }
    }
}