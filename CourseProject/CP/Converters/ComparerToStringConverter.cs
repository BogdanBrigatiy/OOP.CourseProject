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
    public class ComparerToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //System.Windows.MessageBox.Show("Converting " + value.ToString());
            switch ((SimpleComparer)value)
            {
                case SimpleComparer.Equal:
                    return "=";
                case SimpleComparer.Bigger:
                    return ">";
                case SimpleComparer.Smaller:
                    return "<";
                case SimpleComparer.NotBigger:
                    return "<=";
                case SimpleComparer.NotSmaller:
                    return ">=";
                default:
                    return "[x]";
            }//return (bool)value ? "Так" : "Ні";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //System.Windows.MessageBox.Show("Converting back " + value.ToString());
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
            }
        }
    }
}
