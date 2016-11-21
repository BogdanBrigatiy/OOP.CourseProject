using System;
using System.Globalization;
using System.Windows.Data;

namespace CP.Converters
{
    public class ListLengthToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value > 0)
            {
                return true;
            }
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;//throw new NotImplementedException();// (bool)value ? "Ні" : "Так";
        }
    }
}
