namespace MAUIsland.Core;

public class LineBreakModeEnumToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {

        if (value is int)
        {
            return (LineBreakMode)value;
        }
        return LineBreakMode.WordWrap;
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
