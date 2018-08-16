using System;
using System.Globalization;
using Xamarin.Forms;

namespace GymApp.Core.ValueConverters
{
    public class DateTimeToDateStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime toConvert = (DateTime)value;

            if(toConvert.Date == DateTime.Now.Date)
            {
                return "Today";
            }
            else
            {
                return toConvert.ToString("dddd, dd MMMM yyyy");
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
