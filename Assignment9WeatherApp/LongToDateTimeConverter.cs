using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment9WeatherApp
{
    public class LongToDateTimeConverter : IValueConverter
    {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is long ticks)
                {
                    return new DateTime(ticks);
                }
                // Fallback value, could also be something else
                return DateTime.MinValue;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return Binding.DoNothing;
            }
    }
}
