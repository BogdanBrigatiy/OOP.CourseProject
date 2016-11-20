using System.Windows;
using CP.ViewModel;
using System.Windows.Controls;

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
            //var gv = (GridView)listView.View;
            //var column = gv.Columns[4];
            //column
            //((System.ComponentModel.INotifyPropertyChanged)column).PropertyChanged += (sender, e) =>
            //{
            //    if (e.PropertyName == "ActualWidth")
            //    {
            //        //do something here...
            //    }
            //};
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void GridViewColumn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //MessageBox.Show("sdssdds");
        }

        private void textBox_Copy1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ViewModel.ViewModelLocator.Main.CalculateAvgPower();
        }
    }
}