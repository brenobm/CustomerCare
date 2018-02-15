using System;
using System.Globalization;
using Xamarin.Forms;

namespace CustomerCare.Converters
{
    public class DecimalConverter : IValueConverter
    {
        public DecimalConverter()
        {

        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal val = (decimal)value;

            if (val == 0)
                return string.Empty;

            return val.ToString(culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value.ToString();
            decimal decimalValue = 0;

            decimal.TryParse(val, NumberStyles.Any, culture, out decimalValue);

            return decimalValue;
        }
    }
}
