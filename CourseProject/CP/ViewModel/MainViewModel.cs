using GalaSoft.MvvmLight;
using CP.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CP.Core;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
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
        private readonly IDataService _dataService;

        #region fields
        //private:
        Order _orderFlag = Order.None;
        string _ordrBtnCaption = "Не впорядковано";
        double _avgPower;
        #endregion

        #region properties
        public double AvgPower
        {
            get { return _avgPower; }
            set { _avgPower = value; RaisePropertyChanged(() => AvgPower); }
        }
        public string ordrBtnText
        {
            get { return _ordrBtnCaption; }
            set { _ordrBtnCaption = value; RaisePropertyChanged(() => ordrBtnText); }
        }
        #endregion

        #region commands
        public ICommand OrderByCommand { get; private set; }

        void InitializeComands()
        {
            OrderByCommand = new RelayCommand(OrderBy);
        }
        void OrderBy()
        {
            switch(_orderFlag)
            {
                case Order.Ascending:
                    //RecoveryList = TransportList;
                    _orderFlag = Order.Descending;
                    TransportList = new ObservableCollection<PublicTransport>(TransportList.OrderByDescending(p => p.PassengerCapacity));
                    ordrBtnText = "9 > 0";
                    break;
                case Order.Descending:
                    TransportList = RecoveryList;
                    _orderFlag = Order.None;
                    ordrBtnText = "Не впорядковано";
                    break;
                default:
                    RecoveryList = TransportList;
                    TransportList = new ObservableCollection<PublicTransport>(TransportList.OrderBy(p => p.PassengerCapacity));// TransportList.OrderBy(p => p.PassengerCapacity) as ObservableCollection<PublicTransport>;
                    _orderFlag = Order.Ascending;
                    ordrBtnText = "0 > 9";
                    break;
            }
        }

        #endregion

        private ObservableCollection<PublicTransport> _vehicles;

        private ObservableCollection<PublicTransport> RecoveryList;

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
            _dataService = new DataService();

            //TransportList = new ObservableCollection<PublicTransport>();
            //TransportList = _dataService.GetTrasportList();
            InitializeComands();
            //_dataService = dataService;
            _dataService.GetTrasportList(
                (list, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    TransportList = new ObservableCollection<PublicTransport>(list);// (ObservableCollection<PublicTransport>)list;//item.Title;
                    CalculateAvgPower();
                });

            //var fm = new FileManager();
            //var json = fm.ReadFromFile(Constants.DefaultFilePath);
            //var vc = JsonHelper.Deserealize<List<PublicTransport>>(json);


            //MessageBox.Show(v.ToString());
            //v.LoadFromFile();//.SaveToFile();
            //MessageBox.Show(v.ToString());
            //TransportList.Add(v);
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
        #region private members
        void CalculateAvgPower()
        {
            AvgPower = TransportList.Average(p => p.EnginePower);
        }
        #endregion

    }
}