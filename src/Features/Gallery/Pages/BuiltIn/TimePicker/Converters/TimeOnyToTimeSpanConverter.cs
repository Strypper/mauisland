namespace MAUIsland;

public class TimeOnyToTimeSpanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var timeOnly = (TimeOnly)value;
        return timeOnly.ToTimeSpan();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var timeSpan = (TimeSpan)value;
        return TimeOnly.FromTimeSpan(timeSpan);
    }
}
