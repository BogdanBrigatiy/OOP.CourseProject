using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CP.Converters
{
    public class ZeroToMsgConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 0) return "All"; else return (int)value;
            //return (bool)value ? "Так" : "Ні";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "All") return 0; else return (string)value; //return (bool)value ? "Ні" : "Так";
        }
    }
}
