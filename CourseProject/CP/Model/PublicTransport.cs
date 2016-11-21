using CP.Core;
using System;
using System.Text;

namespace CP.Model
{
    public class PublicTransport : AVehicle, ICloneable
    {
        #region private fields
        //приватні поля класу
        private int _doors, _passengersCapacity, _seats, _enginePower;
        private bool _lowClearance;
        #endregion

        #region properties
        //властивості класу, для доступу до приватних полів
        //кількість дверей
        public int Doors
        {
            get { return _doors; }
            set { _doors = value; OnPropertyChanged("Doors"); }
        }
        //пасажиромісткість
        public int PassengerCapacity
        {
            get { return _passengersCapacity; }
            set { _passengersCapacity = value; OnPropertyChanged("PassengerCapacity"); }
        }
        //місць для сидіння
        public int Seats
        {
            get { return _seats; }
            set { _seats = value; OnPropertyChanged("Seats"); }
        }
        //потужність двигуна
        public int EnginePower
        {
            get { return _enginePower; }
            set { _enginePower = value; OnPropertyChanged("EnginePower"); }
        }
        //низька підлгоа
        public bool LowClearance
        {
            get { return _lowClearance; }
            set { _lowClearance = value; OnPropertyChanged("LowClearance"); }
        }
        #endregion

        #region c-tors
        //конструктор за замовчуванням
        public PublicTransport()
        {

        }
        //конструктор з параметрами
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
        //копіювання об'єкта
        public object Clone()
        {
            return MemberwiseClone();
        }
        #endregion

        #region public members
        //публічні методи
        //збереження в файл
        public bool SaveToFile(string filepath)
        {
            var fm = new FileManager();
            //запис в файл
            return fm.WriteToFile(JsonHelper.Serialize(this), filepath, Encoding.UTF8);
        }
        //завантаження з файлу
        public bool LoadFromFile(string filepath)
        {
            var flag = true;
            var fm = new FileManager();
            try
            {
                //створюємо новий екземпляр транспорту
                var newInstance = (PublicTransport)JsonHelper.Deserealize<PublicTransport>(fm.ReadFromFile(filepath, Encoding.UTF8)).Clone();
                //заповнюємо поля
                Model = newInstance.Model;
                EngineType = newInstance.EngineType;
                Axles = newInstance.Axles;
                EnginePower = newInstance.EnginePower;
                PassengerCapacity = newInstance.PassengerCapacity;
                Seats = newInstance.Seats;
                Doors = newInstance.Doors;
                LowClearance = newInstance.LowClearance;
            }
            catch (Exception ex) //перехоплення виключних ситуацій
            {
                flag = false;
                //MessageBox.Show(ex.Message, "An error occured!");
            }
            return flag;
        }
        //перевизначення стандартного методу ToString
        public override string ToString()
        {
            return JsonHelper.Serialize(this);
        }
        #endregion
    }
}
