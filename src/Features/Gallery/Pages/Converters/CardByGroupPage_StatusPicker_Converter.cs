namespace MAUIsland;

public class CardByGroupPage_StatusPicker_Converter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
            return new List<string>();

        var valueType = value.GetType();
        var items = value as ObservableCollection<IGalleryCardInfo>;
        if (items != null)
        {
            return Enum.GetValues(typeof(GalleryCardType))
                       .Cast<GalleryCardType>()
                       .ToList();
        }
        else
            return new List<string>();

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
