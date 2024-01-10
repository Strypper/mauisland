namespace MAUIsland;

public class AgeToMemeImageConverter : IValueConverter
{
    #region [ Services ]
    private readonly IMrIncreadibleMemeService MemeService;
    #endregion

    #region [ CTor ]
    public AgeToMemeImageConverter()
    {
        MemeService = DependencyService.Get<IMrIncreadibleMemeService>();
    }
    #endregion

    #region [ Methods ]
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var age = (double)value;
        return MemeService.GetMemeImage(age);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
    #endregion
}
