using CalculatorCS.Core;

namespace CalculatorCS.MVVM.ViewModels
{
    public class SimpleSidePanelViewModel
    {
        private CalculationServer Server { get; set; }
        public RelayCommand ClearCommand { get; set; }
        public RelayCommand BackspaceCommand { get; set; }

        public SimpleSidePanelViewModel()
        {
            Server = CalculationServer.GetInstance();

            ClearCommand = new RelayCommand(o =>
            {
                Server.Clear();
            });

            BackspaceCommand = new RelayCommand(o =>
            {
                Server.Backspace();
            });
        }
    }
}