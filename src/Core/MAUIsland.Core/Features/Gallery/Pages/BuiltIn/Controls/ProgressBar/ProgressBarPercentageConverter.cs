namespace MAUIsland.Core;

public class ProgressBarPercentageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        double temp = (double)value * 100;
        return $"{temp:N1}%";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        double temp = (double)value / 100;
        return $"{temp:N1}%";
    }
}
