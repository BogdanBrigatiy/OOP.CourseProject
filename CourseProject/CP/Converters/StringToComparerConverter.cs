using CP.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CP.Converters
{
    public class StringToComparerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "=":
                    return SimpleComparer.Equal;
                case ">":
                    return SimpleComparer.Bigger;
                case "<":
                    return SimpleComparer.Smaller;
                case "<=":
                    return SimpleComparer.NotBigger;
                case ">=":
                    return SimpleComparer.NotSmaller;
                default:
                    return SimpleComparer.None;
            }//return (bool)value ? "Так" : "Ні";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();//return (bool)value ? "Ні" : "Так";
        }
    }
}
