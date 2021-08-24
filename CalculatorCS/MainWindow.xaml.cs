using System;
using System.Windows;
using CalculatorCS.Core;
using CalculatorCS.MVVM.Models;

namespace CalculatorCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ModeComboBox.ItemsSource = Enum.GetNames(typeof(Modes));
        }
    }
}
