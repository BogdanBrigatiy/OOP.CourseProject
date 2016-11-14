using GalaSoft.MvvmLight;
using CP.Model;
using System.Collections.ObjectModel;
using System.Windows;
using CP.Core;
using System.Collections.Generic;
//using /*Main*/.Model;

namespace CP.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        //private readonly IDataService _dataService;

        private ObservableCollection<PublicTransport> _vehicles;

        public ObservableCollection<PublicTransport> TransportList
        {
            get { return _vehicles; }
            set { _vehicles = value; RaisePropertyChanged(() => TransportList); }
        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            TransportList = new ObservableCollection<PublicTransport>();
            //var fm = new FileManager();
            //var json = fm.ReadFromFile(Constants.DefaultFilePath);
            //var vc = JsonHelper.Deserealize<List<PublicTransport>>(json);
            
            var v = new PublicTransport() { Axles = 10, PassengerCapacity = 30 };
            //MessageBox.Show(v.ToString());
            //v.LoadFromFile();//.SaveToFile();
            //MessageBox.Show(v.ToString());
            TransportList.Add(new PublicTransport() { Axles = 10, PassengerCapacity = 30 });
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}