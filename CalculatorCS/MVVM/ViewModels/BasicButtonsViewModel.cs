using System;
using System.Windows.Controls;
using CalculatorCS.Core;

namespace CalculatorCS.MVVM.ViewModels
{
    public class BasicButtonsViewModel : ObservableObject
    {
        private RelayCommand _numberCommand;
        private RelayCommand _arithmeticCommand;
        private RelayCommand _equalsCommand;
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
        
        public RelayCommand ArithmeticCommand
        {
            get => _arithmeticCommand;
            set
            {
                _arithmeticCommand = value;
                OnPropertyChanged();
            }
        }
        
        public RelayCommand EqualsCommand
        {
            get => _equalsCommand;
            set
            {
                _equalsCommand = value;
                OnPropertyChanged();
            }
        }

        public BasicButtonsViewModel()
        {
            Server = CalculationServer.GetInstance();
            NumberCommand = new RelayCommand(o =>
            {
                var button = o as Button;
                Server.ProvideNumber(button?.Content.ToString());
            });

            ArithmeticCommand = new RelayCommand(o =>
            {
                var button = o as Button;
                Server.ProvideArithmeticOperation(button?.Content.ToString());
            });

            EqualsCommand = new RelayCommand(o =>
            {
                Server.Calculate();
            });
        }
    }
}