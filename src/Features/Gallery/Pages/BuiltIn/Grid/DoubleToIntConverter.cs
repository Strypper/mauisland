namespace MAUIsland.Gallery.BuiltIn;

public class DoubleToIntConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        double doubleValue = (double)value*100;
        int intValue = (int)doubleValue;
        return intValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
