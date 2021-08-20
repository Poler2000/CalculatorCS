using System;
using CalculatorCS.Core;
using CalculatorCS.MVVM.Models;
using CalculatorCS.MVVM.Views;

namespace CalculatorCS.MVVM.ViewModels
{
    public class BasicModeViewModel: ObservableObject
    {
        public BasicButtonsViewModel BasicButtonsVm { get; set; }
        public SimpleSidePanelViewModel SimpleSidePanelVm { get; set; }
        
        private string _selectedMode = Modes.Basic.ToString();
        public string SelectedMode
        {
            get => _selectedMode;
            set
            {
                Console.WriteLine("I Change it!");
                if (_selectedMode == value) return;
                _selectedMode = value;
                OnPropertyChanged("SelectedMode");
                Console.WriteLine(_selectedMode);
            }
        }

        public BasicModeViewModel()
        {
            BasicButtonsVm = new BasicButtonsViewModel();
            SimpleSidePanelVm = new SimpleSidePanelViewModel();
        }
    }
}