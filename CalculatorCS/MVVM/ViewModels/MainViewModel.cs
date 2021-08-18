using CalculatorCS.MVVM.ViewModels;

namespace CalculatorCS.MVVM.ViewModels
{
    public class MainViewModel
    {
        private object _currentSidePanel;

        public object CurrentSidePanel
        {
            get => _currentSidePanel;
            set => _currentSidePanel = value;
        }
        public BasicButtonsViewModel BasicButtonsVm { get; set; }

        public SimpleSidePanelViewModel SimpleSidePanelVm { get; set; }


        public MainViewModel()
        {
            BasicButtonsVm = new BasicButtonsViewModel();
            SimpleSidePanelVm = new SimpleSidePanelViewModel();
            CurrentSidePanel = SimpleSidePanelVm;
        }
    }
}