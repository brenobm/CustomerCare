using System;
using System.Globalization;
using Xamarin.Forms;

namespace CustomerCare.Converters
{
    public class IntegerConverter : IValueConverter
    {
        public IntegerConverter()
        {

        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int val = (int)value;

            if (val == 0)
                return string.Empty;

            return val.ToString(culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value.ToString();
            int intValue = 0;

            int.TryParse(val, NumberStyles.Any, culture, out intValue);

            return intValue;
        }
    }
}
