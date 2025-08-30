using System.Globalization;

namespace Weather_App.maui
{
    public class ScreenProportionalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double screenWidth && parameter is string percentageStr)
            {
                
                if (double.TryParse(percentageStr, out double percentage))
                {
                    
                    return screenWidth * (percentage / 100.0);
                }
            }
            return 20; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}