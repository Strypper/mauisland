namespace MAUIsland;

public class EditorTextTransformPickerConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is TextTransform textTransform)
        {
            return textTransform;
        }

        return TextTransform.None;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is TextTransform textTransform)
        {
            return textTransform;
        }

        return TextTransform.None;
    }
}
