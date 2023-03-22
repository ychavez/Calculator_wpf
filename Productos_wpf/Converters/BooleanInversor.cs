﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Productos_wpf.Converters
{
    public class BooleanInversor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return "Hidden";

            return "Visible";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
