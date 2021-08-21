using CalculatorCS.Core;
using CalculatorCS.MVVM.Models;

namespace CalculatorCS.MVVM.ViewModels
{
    public class AdvancedModeViewModel  : ObservableObject
    {
        public BasicButtonsViewModel BasicButtonsVm { get; set; }
        public AdvancedSidePanelViewModel AdvancedSidePanelVm { get; set; }

        public AdvancedModeViewModel()
        {
            BasicButtonsVm = new BasicButtonsViewModel();
            AdvancedSidePanelVm = new AdvancedSidePanelViewModel();
        }
    }
}