using CP.Core;
using System;
using System.Globalization;
using System.Windows.Data;

namespace CP.Converters
{
    public class ComparerToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
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
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
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
            }
        }
    }
}
