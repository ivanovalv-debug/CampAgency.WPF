using System;
using System.Globalization;
using System.Windows.Data;

namespace CampAgency.WPF.Converters
{
    public class RadioIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue && parameter is string paramString)
            {
                if (int.TryParse(paramString, out int paramInt))
                    return intValue == paramInt;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue && boolValue && parameter is string paramString)
            {
                if (int.TryParse(paramString, out int paramInt))
                    return paramInt;
            }
            return 0;
        }
    }
}