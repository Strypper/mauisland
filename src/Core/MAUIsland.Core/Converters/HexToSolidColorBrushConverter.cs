namespace MAUIsland.Core;

public class HexToSolidColorBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var hex = value as String;

        if (hex != null && !string.IsNullOrWhiteSpace(hex) && !string.IsNullOrEmpty(hex))
        {
            hex = hex.Replace("#", string.Empty);
            // from #RRGGBB string
            var r = (byte)System.Convert.ToUInt32(hex.Substring(0, 2), 16);
            var g = (byte)System.Convert.ToUInt32(hex.Substring(2, 2), 16);
            var b = (byte)System.Convert.ToUInt32(hex.Substring(4, 2), 16);

            return Color.FromRgb(r, g, b);
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
