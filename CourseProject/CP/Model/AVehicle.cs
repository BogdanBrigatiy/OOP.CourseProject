using CP.Core;

namespace CP.Model
{
    public abstract class AVehicle : BaseNotifyingModel
    {
        //приватні поля
        private int _axles;
        private string _model;
        private EEngineType _engineType;
        //кількість осей
        public int Axles
        {
            get { return _axles; }
            set { _axles = value; OnPropertyChanged("Axles"); }
        }
        //марка ТЗ
        public string Model
        {
            get { return _model; }
            set { _model = value; OnPropertyChanged("Model"); }
        }
        //тип двигуна. Описаний в EENgineType
        public EEngineType EngineType
        {
            get { return _engineType; }
            set { _engineType = value; OnPropertyChanged("EngineType"); }
        }
    }
}
