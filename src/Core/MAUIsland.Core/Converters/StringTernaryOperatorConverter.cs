namespace MAUIsland.Core;

public class StringTernaryOperatorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolValue &&
            parameter is string[] messages)
        {
            return boolValue ? messages[0] : messages[1];
        }

        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
