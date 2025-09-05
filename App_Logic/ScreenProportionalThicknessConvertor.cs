using System.Globalization;

namespace Weather_App.maui
{

    public class ScreenProportionalThicknessConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not double parentWidth || parameter is not string marginPercentages)
            {
                return new Thickness(0);
            }

            var parts = marginPercentages.Split(',');
            if (parts.Length != 4)
            {
                return new Thickness(0);
            }

            try
            {
                double left = (parentWidth * double.Parse(parts[0], CultureInfo.InvariantCulture)) / 100;
                double top = (parentWidth * double.Parse(parts[1], CultureInfo.InvariantCulture)) / 100;
                double right = (parentWidth * double.Parse(parts[2], CultureInfo.InvariantCulture)) / 100;
                double bottom = (parentWidth * double.Parse(parts[3], CultureInfo.InvariantCulture)) / 100;

                return new Thickness(left, top, right, bottom);
            }
            catch
            {
                return new Thickness(0);
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}