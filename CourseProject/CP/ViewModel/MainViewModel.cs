using GalaSoft.MvvmLight;
using CP.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CP.Core;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using CP.Model.Filtering;
using System;

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
        //філтр та провайдер даних
        private readonly IDataService _dataService;
        private readonly Filter _filter = new Filter();
        
        #region fields
        //приватні поля
        private Order _orderFlag = Order.Ascending;
        private eOrderBy _orderByFlag = eOrderBy.None;
        private string _ordrBtnCaption = "Не впорядковано";
        private double _avgPower;
        private string _orderByButtonText = "0 > 9";
        private ObservableCollection<PublicTransport> _vehicles;
        private ObservableCollection<PublicTransport> RecoveryList;
        private ObservableCollection<PublicTransport> OrderRecoveryList;
        private int _skipValue = 0;
        private PublicTransport _selected;
        private bool _impExpSAllowed = false;

        //параметри фільтрації
        private SimpleFilterArgument<string> _modelArg;
        private SimpleFilterArgument<EEngineType> _engineTypeArg;
        private SimpleFilterArgument<int> _enginePowerArg;
        private SimpleFilterArgument<int> _axlesArg;
        private SimpleFilterArgument<int> _capacityArg;
        private SimpleFilterArgument<int> _seatsArg;
        private SimpleFilterArgument<int> _standsArg;
        private SimpleFilterArgument<bool> _lowClearanceArg;
        private SimpleFilterArgument<int> _doorsArg;
        #endregion

        //ініціалізація стартових параметрів фільтру
        void InitializeFilterParams()
        {
            ModelArg = new SimpleFilterArgument<string>() { Sample = "", Comparer = SimpleComparer.None };
            EngineTypeArg = new SimpleFilterArgument<EEngineType>() { Sample = EEngineType.Gas, Comparer = SimpleComparer.None };
            EnginePowerArg = new SimpleFilterArgument<int>() { Sample = 0, Comparer = SimpleComparer.None };
            AxlesArg = new SimpleFilterArgument<int>() { Sample = 0, Comparer = SimpleComparer.None };
            CapacityArg = new SimpleFilterArgument<int>() { Sample = 0, Comparer = SimpleComparer.None };
            SeatsArg = new SimpleFilterArgument<int>() { Sample = 0, Comparer = SimpleComparer.None };
            StandsArg = new SimpleFilterArgument<int>() { Sample = 0, Comparer = SimpleComparer.None };
            DoorsArg = new SimpleFilterArgument<int>() { Sample = 0, Comparer = SimpleComparer.None };
            LowClearanceArg = new SimpleFilterArgument<bool>() { Sample = true, Comparer = SimpleComparer.None };
        }

        #region properties
        //властивості для прив'язки даних
        public ObservableCollection<PublicTransport> TransportList
        {
            get { return _vehicles; }
            set { _vehicles = value; RaisePropertyChanged(() => TransportList); CalculateAvgPower(); }
        }
        public string OrderByButtonText
        {
            get { return _orderByButtonText; }
            set { _orderByButtonText = value; RaisePropertyChanged(() => OrderByButtonText); }
        }
        public eOrderBy OrderByFlag
        {
            get { return _orderByFlag; }
            set { _orderByFlag = value; RaisePropertyChanged(() => OrderByFlag); }
        }
        public int SkipValue
        {
            get { return _skipValue; }
            set { _skipValue = value; RaisePropertyChanged(() => SkipValue); }
        }
        public SimpleFilterArgument<string> ModelArg
        {
            get { return _modelArg; }
            set { _modelArg = value; RaisePropertyChanged(() => ModelArg); }
        }
        public SimpleFilterArgument<EEngineType> EngineTypeArg
        {
            get { return _engineTypeArg; }
            set { _engineTypeArg = value; RaisePropertyChanged(() => EngineTypeArg); }
        }
        public SimpleFilterArgument<int> EnginePowerArg
        {
            get { return _enginePowerArg; }
            set { _enginePowerArg = value; RaisePropertyChanged(() => EnginePowerArg); }
        }
        public SimpleFilterArgument<int> AxlesArg
        {
            get { return _axlesArg; }
            set { _axlesArg = value; RaisePropertyChanged(() => AxlesArg); }
        }
        public SimpleFilterArgument<int> CapacityArg
        {
            get { return _capacityArg; }
            set { _capacityArg = value; RaisePropertyChanged(() => CapacityArg); }
        }
        public SimpleFilterArgument<int> SeatsArg
        {
            get { return _seatsArg; }
            set { _seatsArg = value; RaisePropertyChanged(() => SeatsArg); }
        }
        public SimpleFilterArgument<int> StandsArg
        {
            get { return _standsArg; }
            set { _standsArg = value; RaisePropertyChanged(() => StandsArg); }
        }
        public SimpleFilterArgument<int> DoorsArg
        {
            get { return _doorsArg; }
            set { _doorsArg = value; RaisePropertyChanged(() => DoorsArg); }
        }
        public SimpleFilterArgument<bool> LowClearanceArg
        {
            get { return _lowClearanceArg; }
            set { _lowClearanceArg = value; RaisePropertyChanged(() => LowClearanceArg); }
        }
        //виділений елемент в listview
        public PublicTransport SelectedItem
        {
            get { return _selected; }
            set
            {
                _selected = value;
                RaisePropertyChanged(() => SelectedItem);
                CalculateAvgPower();
                if (value != null) ImportExportSingleAllowed = true;
                else ImportExportSingleAllowed = false;
            }
        }
        public bool ImportExportSingleAllowed
        {
            get { return _impExpSAllowed; }
            set { _impExpSAllowed = value; RaisePropertyChanged(() => ImportExportSingleAllowed); }
        }

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
        //ініціалізація команд
        void InitializeComands()
        {
            OrderByCommand = new RelayCommand(OrderBy);
            ImportAllCommand = new RelayCommand(ImportAll);
            ExportAllCommand = new RelayCommand(ExportAll);
            ImportSingleCommand = new RelayCommand(ImportSingle);
            ExportSingleCommand = new RelayCommand(ExportSingle);
            CreateNewTransportCommand = new RelayCommand(CreateNewTransport);
            DeleteTransportCommand = new RelayCommand(DeleteTransport);
            ShiftModelComparerCommand = new RelayCommand(() => {
                    ModelArg = new SimpleFilterArgument<string>() { Sample = ModelArg.Sample, Comparer = ShiftBinaryComparer(ModelArg.Comparer) };
                });
            //binary comparer
            ShiftEngineTypeCommand = new RelayCommand(() => {
                    EngineTypeArg = new SimpleFilterArgument<EEngineType>() { Sample = EngineTypeArg.Sample, Comparer = ShiftBinaryComparer(EngineTypeArg.Comparer) };
                });
            ShiftPowerComparerCommand = new RelayCommand(() => {
                    EnginePowerArg = new SimpleFilterArgument<int>() { Sample = EnginePowerArg.Sample, Comparer = ShiftComparer(EnginePowerArg.Comparer) };
                });
            ShiftAxlesComparerCommand = new RelayCommand(()=> {
                    AxlesArg = new SimpleFilterArgument<int>() { Sample = AxlesArg.Sample, Comparer = ShiftComparer(AxlesArg.Comparer) };
                });
            ShiftCapacityComparerCommand = new RelayCommand(() => {
                    CapacityArg = new SimpleFilterArgument<int>() { Sample = CapacityArg.Sample, Comparer = ShiftComparer(CapacityArg.Comparer) };
                });
            ShiftSeatsComparerCommand = new RelayCommand(() => {
                    SeatsArg = new SimpleFilterArgument<int>() { Sample = SeatsArg.Sample, Comparer = ShiftComparer(SeatsArg.Comparer) };
                });
            ShiftDoorsComparerCommand = new RelayCommand(() => {
                    DoorsArg = new SimpleFilterArgument<int>() { Sample = DoorsArg.Sample, Comparer = ShiftComparer(DoorsArg.Comparer) };
                });
            ShiftStandRoomComparerCommand = new RelayCommand(() => {
                    StandsArg = new SimpleFilterArgument<int>() { Sample = StandsArg.Sample, Comparer = ShiftComparer(StandsArg.Comparer) };
                });
            ShiftClearanceComparerCommand = new RelayCommand(() =>{
                    LowClearanceArg = new SimpleFilterArgument<bool>() { Sample = LowClearanceArg.Sample, Comparer = ShiftBinaryComparer(LowClearanceArg.Comparer) };
                });
            ApplyFilterCommand = new RelayCommand(ApplyFilter);
            CancelFilterCommand = new RelayCommand(CancelFilter);
            IncSkipValueCommand = new RelayCommand(() => { SkipValue++; });
            DecSkipValueCommand = new RelayCommand(() => { if (SkipValue!=0) SkipValue--; });
            ApplyOrderByCommand = new RelayCommand(ApplyOrderBy);
            CancelOrderByCommand = new RelayCommand(CancelOrderBy);
            ChangeOrderCommand = new RelayCommand(
                () =>
                {
                    if (_orderFlag == Order.Ascending)
                    {
                        _orderFlag = Order.Descending;
                        OrderByButtonText = "9 > 0";
                    }
                    else
                    {
                        _orderFlag = Order.Ascending;
                        OrderByButtonText = "0 > 9";
                    }
                }
                
                );
        }
        public ICommand ChangeOrderCommand { get; private set; }
        public ICommand OrderByCommand { get; private set; }
        public ICommand ExportAllCommand { get; private set; }
        public ICommand ImportAllCommand { get; private set; }
        public ICommand CreateNewTransportCommand { get; private set; }
        public ICommand ExportSingleCommand { get; private set; }
        public ICommand ImportSingleCommand { get; private set; }
        public ICommand DeleteTransportCommand { get; private set; }
        public ICommand ApplyFilterCommand { get; private set; }
        public ICommand CancelFilterCommand { get; private set; }
        //IncreaseModelComparer
        public ICommand ShiftModelComparerCommand { get; private set; }
        public ICommand ShiftEngineTypeCommand { get; private set; }
        public ICommand ShiftPowerComparerCommand { get; private set; }
        public ICommand ShiftAxlesComparerCommand { get; private set; }

        public ICommand ShiftCapacityComparerCommand { get; private set; }
        public ICommand ShiftSeatsComparerCommand { get; private set; }
        public ICommand ShiftDoorsComparerCommand { get; private set; }
        public ICommand ShiftStandRoomComparerCommand { get; private set; }
        public ICommand ShiftClearanceComparerCommand { get; private set; }
        public ICommand IncSkipValueCommand { get; private set; }
        public ICommand DecSkipValueCommand { get; private set; }
        public ICommand ApplyOrderByCommand { get; private set; } 
        public ICommand CancelOrderByCommand { get; private set; }
        //методи, виконувані командами
        //застосування сортування
        void ApplyOrderBy()
        {
            OrderRecoveryList = TransportList;

            switch (OrderByFlag)
            {
                case eOrderBy.Model: TransportList = new ObservableCollection<PublicTransport>( Sorter.ByModel(TransportList.ToList(), _orderFlag)); break;
                case eOrderBy.EngineType: TransportList = new ObservableCollection<PublicTransport>(Sorter.ByEngineType(TransportList.ToList(), _orderFlag)); break;
                case eOrderBy.EnginePower: TransportList = new ObservableCollection<PublicTransport>(Sorter.ByPower(TransportList.ToList(), _orderFlag)); break;
                case eOrderBy.Axles: TransportList = new ObservableCollection<PublicTransport>(Sorter.ByAxles(TransportList.ToList(), _orderFlag)); break;
                case eOrderBy.Doors: TransportList = new ObservableCollection<PublicTransport>(Sorter.ByDoors(TransportList.ToList(), _orderFlag)); break;
                case eOrderBy.PassengerCapacity: TransportList = new ObservableCollection<PublicTransport>(Sorter.ByCapacity(TransportList.ToList(), _orderFlag)); break;
                case eOrderBy.Seats: TransportList = new ObservableCollection<PublicTransport>(Sorter.BySeats(TransportList.ToList(), _orderFlag)); break;
                case eOrderBy.LowClearance: TransportList = new ObservableCollection<PublicTransport>(Sorter.ByClearance(TransportList.ToList(), _orderFlag)); break;
                default:
                    TransportList = OrderRecoveryList;
                    break;
            }

            var take = SkipValue;
            if (SkipValue == 0) { take = TransportList.Count; }
            TransportList = new ObservableCollection<PublicTransport>(TransportList.Take(take));
        }
        //зкидання сортування
        void CancelOrderBy()
        {
            TransportList = OrderRecoveryList;
            SkipValue = 0;
        }
        //зкидання фільтру
        void CancelFilter()
        {
            TransportList = RecoveryList;
            _orderFlag = Order.None;
            ordrBtnText = "Не впорядковано";
        }
        //застосування фільтру
        void ApplyFilter()
        {
            if (RecoveryList == null)
                RecoveryList = TransportList;

            _orderFlag = Order.None;
            ordrBtnText = "Не впорядковано";

            List<PublicTransport> result;

            result = _filter.ByModel(ModelArg, TransportList.ToList());//_ft.ByModel

            result = _filter.ByEngineType(EngineTypeArg, result);
            result = _filter.ByEnginePower(EnginePowerArg, result);
            result = _filter.ByAxles(AxlesArg, result);
            result = _filter.ByDoors(DoorsArg, result);
            result = _filter.ByCapacity(CapacityArg, result);
            result = _filter.BySeats(SeatsArg, result);
            result = _filter.ByStandingRoom(StandsArg, result);
            result = _filter.ByClearance(LowClearanceArg, result);

            TransportList = new ObservableCollection<PublicTransport>(result);
        }
        //імпорт однойго екземпляру
        void ImportSingle() 
        {
            SelectedItem = _dataService.ImportSingle(SelectedItem);
            TransportList.Add(SelectedItem);
        }
        //експорт 1 екземпляру
        void ExportSingle()
        {
            _dataService.ExportSingle(SelectedItem);
        }
        //видалення
        void DeleteTransport()
        {
            TransportList.Remove(SelectedItem);
        }
        //створення нового
        void CreateNewTransport()
        {
            TransportList.Add(new PublicTransport());
            SelectedItem = TransportList.LastOrDefault();
        }
        //експорт всіх
        void ExportAll()
        {
            _dataService.ExportTransportList(TransportList.ToList());
        }
        //імпорт всіх
        void ImportAll()
        {
            TransportList = new ObservableCollection<PublicTransport>(_dataService.ImportTransportList());
            _orderFlag = Order.None;
            ordrBtnText = "Не впорядковано";
        }
        //впорядкуваняя
        void OrderBy()
        {

        }
        //зміна компаратора
        SimpleComparer ShiftComparer(SimpleComparer a)
        {
            if ((int)a == 5) return 0;
            else return ++a;
        }
        //зміна бінарного компаратора
        SimpleComparer ShiftBinaryComparer(SimpleComparer a)
        {
            if ((int)a == 0) { a = (SimpleComparer)3; return a; }
            else return 0;
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        
        //конструктор
        public MainViewModel()
        {
            TransportList = new ObservableCollection<PublicTransport>();
            _dataService = new DataService();
            InitializeComands();
            InitializeFilterParams();
            OrderByFlag = eOrderBy.None;
            SkipValue = 0;
        }
        //розрахунок середньої потужності
        public void CalculateAvgPower()
        {
            try { AvgPower = TransportList.Average(p => p.EnginePower); }
            catch (Exception ex)
            {
                //MessageBox.Show("Error during calculating avg value! \r\nAdditional info:\r\n" + ex.Message, Constants.DefaultErrorHeader);
            }
        }
        public void SaveBeforeExit()
        {
            ExportAll();
        }
        ~MainViewModel()
        {
            //Logger.getInstance().EndLog();
        }
    }
}
