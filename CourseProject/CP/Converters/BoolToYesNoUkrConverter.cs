using System;
using System.Globalization;
using System.Windows.Data;

namespace CP.Converters
{
    //бульове значення в Так/Ні
    public class BoolToYesNoUkrConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "Так" : "Ні";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "Ні" : "Так";
        }
    }
}
