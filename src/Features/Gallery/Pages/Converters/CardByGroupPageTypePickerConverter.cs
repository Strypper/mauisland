namespace MAUIsland;

public class CardByGroupPageTypePickerConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
            return new List<string>();

        var valueType = value.GetType();
        var items = value as ObservableCollection<IGalleryCardInfo>;
        if (items != null)
        {
            var enumValues = Enum.GetNames(typeof(GalleryCardType))
                                 .Select(name => name.EndsWith("s") ? name : name + "s")
                                 .ToList();
            enumValues.Insert(0, "All");
            return enumValues;
        }
        else
            return new List<string>();

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
