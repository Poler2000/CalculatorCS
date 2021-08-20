using System;
using System.ComponentModel;
using System.Diagnostics;
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
            }
        }

        public void ChangeMode()
        {
            if (SelectedMode == Modes.Advanced.ToString())
            {
                SelectedMode = Modes.Basic.ToString();
                CurrentPanelVm = new BasicModeViewModel();
                return;
            }
            SelectedMode = Modes.Advanced.ToString();
            CurrentPanelVm = new AdvancedModeViewModel();
            CurrentPanelVm.PropertyChanged += (sender, args) =>
            {
                ChangeMode();
            };
        }

        public ScreenViewModel ScreenVm { get; set; }

        public MainViewModel()
        {
            Console.WriteLine("Hello");

            CurrentPanelVm = new BasicModeViewModel();
            CurrentPanelVm.PropertyChanged += (sender, args) =>
            {
                Console.WriteLine(sender.ToString());
                Console.WriteLine("Hello");

                ChangeMode();
            };
            ScreenVm = new ScreenViewModel();
            Console.WriteLine("Hello");

        }
    }
}