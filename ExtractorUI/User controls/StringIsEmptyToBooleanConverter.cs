using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace app.User_controls
{

    [ValueConversion(typeof(String), typeof(bool))]
    public class StringIsEmptyToBooleanConverter : IValueConverter
    {



        public static StringIsEmptyToBooleanConverter Instance = new StringIsEmptyToBooleanConverter();

        static StringIsEmptyToBooleanConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is String))
            {
                return false;
            }

            return String.IsNullOrEmpty(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
            {
                return "a";
            }

            return "";
        }
    }
}
