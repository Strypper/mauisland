namespace MAUIsland;

public class StringToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var stringValue = value as String;

        if (stringValue != null && !string.IsNullOrWhiteSpace(stringValue) && !string.IsNullOrEmpty(stringValue))
        {
            var color = System.Drawing.Color.FromName(stringValue);
            return Color.FromRgb(color.R, color.G, color.B);
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
