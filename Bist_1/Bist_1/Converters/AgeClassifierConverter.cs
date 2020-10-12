using System;
using System.Globalization;
using Xamarin.Forms;

namespace Bist_1.Converters
{
    public class AgeClassifierConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue)
            {
                if (intValue <= 20)
                {
                    return 0;
                }
                return intValue <= 30 ? 1 : 2;

                return intValue <= 20
                       ? 0
                       : intValue <= 30 
                           ? 1 
                           : 2;
            }

            throw new ArgumentException($"{nameof(AgeClassifierConverter)}: check parameter");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
