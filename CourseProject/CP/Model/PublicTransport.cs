using System;

namespace CP.Model
{
    public class PublicTransport : AVehicle, ICloneable
    {
        #region private fields
        private int _doors, _passengersCapacity, _seats, _enginePower;
        private bool _lowClearance;
        #endregion

        #region properties
        public int Doors
        {
            get { return _doors; }
            set { _doors = value; OnPropertyChanged("Doors"); }
        }
        public int PassengerCapacity
        {
            get { return _passengersCapacity; }
            set { _passengersCapacity = value; OnPropertyChanged("PassengerCapacity"); }
        }
        public int Seats
        {
            get { return _seats; }
            set { _seats = value; OnPropertyChanged("Seats"); }
        }
        public int EnginePower
        {
            get { return _enginePower; }
            set { _enginePower = value; OnPropertyChanged("EnginePower"); }
        }
        public bool LowClearance
        {
            get { return _lowClearance; }
            set { _lowClearance = value; OnPropertyChanged("LowClearance"); }
        }
        #endregion

        #region c-tors
        public PublicTransport()
        {

        }

        public PublicTransport(string model,
            EEngineType eType,
            int power,
            int axles,
            int capacity,
            int seats,
            int doors,
            bool lowClearance )
        {
            Model = model;
            EngineType = eType;
            Axles = axles;
            EnginePower = power;
            PassengerCapacity = capacity;
            Seats = seats;
            Doors = doors;
            LowClearance = lowClearance;
        }
        
        //clone "constructor" method
        public object Clone()
        {
            return MemberwiseClone();
        }
        #endregion

        #region members

        #endregion
    }
}
