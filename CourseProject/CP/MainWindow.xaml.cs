using System.Windows;
using CP.ViewModel;
using System.Windows.Input;
using CP.Core;

namespace CP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void GridViewColumn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }

        private void textBox_Copy1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ViewModel.ViewModelLocator.Main.CalculateAvgPower();
        }

        private void textBox1_Copy1_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                case Key.NumLock:
                case Key.NumPad0:
                case Key.NumPad1:
                case Key.NumPad2:
                case Key.NumPad3:
                case Key.NumPad4:
                case Key.NumPad5:
                case Key.NumPad6:
                case Key.NumPad7:
                case Key.NumPad8:
                case Key.NumPad9:
                case Key.Back:
                case Key.Left:
                case Key.Right:
                case Key.Delete:
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            switch (MessageBox.Show("Зберегти внесені зміни?", Constants.DefaultWarningHeader, MessageBoxButton.YesNoCancel))
            {
                case MessageBoxResult.Cancel: e.Cancel = true; break;
                case MessageBoxResult.Yes: ViewModelLocator.Main.SaveBeforeExit(); break;
                case MessageBoxResult.No: break;
            }
                
                
        }
    }
}