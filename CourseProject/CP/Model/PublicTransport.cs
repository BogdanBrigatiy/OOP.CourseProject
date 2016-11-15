using CP.Core;
using System;
using System.Windows;

namespace CP.Model
{
    public class PublicTransport : AVehicle, ICloneable//, IComparable<PublicTransport>
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

        public PublicTransport(VModel model,
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

        #region public members
        public bool SaveToFile()
        {
            var fm = new FileManager();
            //var list = 
            return fm.WriteToFile(JsonHelper.Serialize(this), Constants.DefaultFilePath);
            //return true;
        }
        public void LoadFromFile()
        {
            var fm = new FileManager();
            try
            {
                var newInstance = (PublicTransport)JsonHelper.Deserealize<PublicTransport>(fm.ReadFromFile(Constants.DefaultFilePath)).Clone();
                Model = newInstance.Model;
                EngineType = newInstance.EngineType;
                Axles = newInstance.Axles;
                EnginePower = newInstance.EnginePower;
                PassengerCapacity = newInstance.PassengerCapacity;
                Seats = newInstance.Seats;
                Doors = newInstance.Doors;
                LowClearance = newInstance.LowClearance;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured!");
            }            
        }
        public override string ToString()
        {
            return JsonHelper.Serialize(this);
        }
        //public int CompareTo(PublicTransport cmpr)
        //{
        //    int flag = 0;
        //    if (cmpr.PassengerCapacity > this.PassengerCapacity) flag = 1;
        //    if (cmpr.PassengerCapacity < this.PassengerCapacity) flag = -1;
        //    return flag;
        //}
        #endregion
    }
}
