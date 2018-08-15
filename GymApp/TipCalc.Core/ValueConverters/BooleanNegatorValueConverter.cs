using System;
using System.Globalization;
using Xamarin.Forms;

namespace GymApp.Core.ValueConverters
{
    public class BooleanNegatorValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool toConvert = (bool)value;

            return !toConvert;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
