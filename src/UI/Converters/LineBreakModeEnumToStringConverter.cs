namespace MAUIsland;

public class LineBreakModeEnumToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {

        if (value is int)
        {
            return (LineBreakMode)value;
        }
        return LineBreakMode.NoWrap;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is LineBreakMode)
        {
            return (int)value;
        }
        return 0;
    }
}
