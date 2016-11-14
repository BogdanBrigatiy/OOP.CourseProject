using CP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Model
{
    public abstract class AVehicle : BaseNotifyingModel
    {
        private int _axles;
        private string _model;
        private EEngineType _engineType;

        protected int Axles
        {
            get { return _axles; }
            set { _axles = value; OnPropertyChanged("Axles"); }
        }
        protected string Model
        {
            get { return _model; }
            set { _model = value; OnPropertyChanged("Model"); }
        }
        protected EEngineType EngineType
        {
            get { return _engineType; }
            set { _engineType = value; OnPropertyChanged("EngineType"); }
        }
    }


}
