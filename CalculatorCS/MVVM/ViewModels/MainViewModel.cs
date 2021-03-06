using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using CalculatorCS.Core;
using CalculatorCS.MVVM.Models;
using CalculatorCS.MVVM.ViewModels;

namespace CalculatorCS.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private ObservableObject _currentPanelVm;
        
        public ObservableObject CurrentPanelVm
        {
            get => _currentPanelVm;
            set
            {
                _currentPanelVm = value;
                OnPropertyChanged();
            }
        }

        private string _selectedMode = "Basic";

        public string SelectedMode
        {
            get => _selectedMode;
            set
            {
                _selectedMode = value;
                OnPropertyChanged();
                ChangeMode();
            }
        }

        private void ChangeMode()
        {
            if (SelectedMode == Modes.Advanced.ToString())
            {
                CurrentPanelVm = new AdvancedModeViewModel();
                CalculationServer.GetInstance().CurrentMode = Modes.Advanced;
                return;
            }
            CurrentPanelVm = new BasicModeViewModel();
            CalculationServer.GetInstance().CurrentMode = Modes.Basic;

        }

        public ScreenViewModel ScreenVm { get; set; }

        public MainViewModel()
        {
            CurrentPanelVm = new BasicModeViewModel();
            ScreenVm = new ScreenViewModel();
        }
    }
}