using System;
using System.Windows.Controls;
using CalculatorCS.MVVM.Models;

namespace CalculatorCS.MVVM.Views
{
    public partial class AdvancedModeView : UserControl
    {
        public AdvancedModeView()
        {
            InitializeComponent();
            ModeComboBox.ItemsSource = Enum.GetNames(typeof(Modes));
        }
    }
}