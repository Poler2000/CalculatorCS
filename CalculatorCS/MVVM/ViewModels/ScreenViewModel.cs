using CalculatorCS.Core;

namespace CalculatorCS.MVVM.ViewModels
{
    public class ScreenViewModel : ObservableObject
    {
        private string _mainMsg;
        private string _secondaryMsg;

        public string MainMsg
        {
            get => _mainMsg;
            set
            {
                _mainMsg = value;
                OnPropertyChanged();
            }
        }

        public string SecondaryMsg
        {
            get => _secondaryMsg;
            set
            {
                _secondaryMsg = value;
                OnPropertyChanged();
            }
        }
        
        public ScreenViewModel()
        {
            CalculationServer.GetInstance().OnResult = ((msg, secondaryMsg) =>
            {
                MainMsg = msg;
                SecondaryMsg = secondaryMsg;
            });
        }
    }
}