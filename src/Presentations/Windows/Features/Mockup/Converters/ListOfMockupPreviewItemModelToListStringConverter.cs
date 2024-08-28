
namespace MAUIsland.Mockup;

public class ListOfMockupPreviewItemModelToListStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var previewImages = value as List<ScreenshotModel>;
        if (previewImages is null)
            return new ObservableCollection<string>();

        return new ObservableCollection<string>(previewImages.Select(x => x.ImageSource));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
