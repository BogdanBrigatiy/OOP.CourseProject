using System.ComponentModel;

namespace CP.Core
{
    //базовий клас-модель, імплементує OnPropertyChanged метод, який дозволяє сповіщати додаток про зміни в даних
    public class BaseNotifyingModel : INotifyPropertyChanged
    {
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

    }
}
