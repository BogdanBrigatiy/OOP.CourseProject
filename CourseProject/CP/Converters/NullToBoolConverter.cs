﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace CP.Converters
{
    //null Значення в bool
    public class NullToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value==null)
            {
                return false;
            }
            else
                return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;//throw new NotImplementedException();// (bool)value ? "Ні" : "Так";
        }
    }
}
