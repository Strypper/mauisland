namespace MAUIsland;

public class RatioValueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double size && size > 0 && parameter is double ratio && ratio > 0)
        {
            return new GridLength(size * ratio, GridUnitType.Absolute);
        }

        return new GridLength(0, GridUnitType.Absolute);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}