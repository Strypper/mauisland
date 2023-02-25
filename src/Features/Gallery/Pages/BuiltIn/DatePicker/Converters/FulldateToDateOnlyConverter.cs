
namespace MAUIsland;

public class FulldateToDateOnlyConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var birthDay = (DateTime?)value;
        return birthDay?.Date.ToString("MM/dd/yyyy");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
