﻿
namespace MAUIsland.Mockup;

public class SelectedScreenshotModelToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var selectedImage = value as ScreenshotModel;
        if (selectedImage is null || selectedImage.ImageSource is null)
            return string.Empty;

        return selectedImage.ImageSource;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
