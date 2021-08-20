using CalculatorCS.Core;
using CalculatorCS.MVVM.Models;

namespace CalculatorCS.MVVM.ViewModels
{
    public class AdvancedModeViewModel  : ObservableObject
    {
        public BasicButtonsViewModel BasicButtonsVm { get; set; }
        public AdvancedSidePanelViewModel AdvancedSidePanelVm { get; set; }
        
        private string _selectedMode = Modes.Advanced.ToString();
        public string SelectedMode
        {
            get => _selectedMode;
            set
            {
                if (_selectedMode == value) return;
                _selectedMode = value;
                OnPropertyChanged();
            }
        }

        public AdvancedModeViewModel()
        {
            BasicButtonsVm = new BasicButtonsViewModel();
            AdvancedSidePanelVm = new AdvancedSidePanelViewModel();
        }
    }
}