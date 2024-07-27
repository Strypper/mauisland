
namespace MAUIsland.Core;

public class InnerFrameDimensionConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double frameWidth && parameter is string)
        {
            if (double.TryParse((string)parameter, out double subtractAmount))
            {
                return frameWidth - subtractAmount;
            }
        }

        return Binding.DoNothing; // or return value, depending on what you want in case of conversion failure
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
