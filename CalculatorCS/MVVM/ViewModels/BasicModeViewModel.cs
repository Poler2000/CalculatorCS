using System;
using System.Windows.Controls;
using CalculatorCS.Core;
using CalculatorCS.MVVM.Models;
using CalculatorCS.MVVM.Views;

namespace CalculatorCS.MVVM.ViewModels
{
    public class BasicModeViewModel: ObservableObject
    {
        public BasicButtonsViewModel BasicButtonsVm { get; set; }
        public SimpleSidePanelViewModel SimpleSidePanelVm { get; set; }

        public BasicModeViewModel()
        {
            BasicButtonsVm = new BasicButtonsViewModel();
            SimpleSidePanelVm = new SimpleSidePanelViewModel();
        }
    }
}