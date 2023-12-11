using System.Globalization;

namespace MAUIsland;

public class NewActivityToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var newActivity = (NewActivity)value;
        return newActivity switch 
        {
            NewActivity.Enhancement => "Enhance",
            NewActivity.AddFeature => "Add",
            _ => "None"
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
