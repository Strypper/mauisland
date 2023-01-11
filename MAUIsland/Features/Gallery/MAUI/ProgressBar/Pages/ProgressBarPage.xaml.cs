namespace MAUIsland;

public class ArrayConverter<T> : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value.ToString().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => null;
}
public partial class ProgressBarPage
{
    #region [CTor]
    public ProgressBarPage(ProgressBarPageViewModel vm)
    {
        InitializeComponent();
        BindingContext= vm;
    }
    #endregion

}