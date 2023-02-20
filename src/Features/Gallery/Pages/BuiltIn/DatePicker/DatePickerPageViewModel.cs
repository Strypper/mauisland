namespace MAUIsland;

public partial class DatePickerPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public DatePickerPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    string simpleDatePickerXamlCode = "<DatePicker />";

    [ObservableProperty]
    string datePickerUseDateOnlyConverterXamlCode = "<DatePicker x:Name=\"DateOnlyDatePicker\" />\r\n <Label Text=\"{x:Binding Source={x:Reference DateOnlyDatePicker}, Path=Date, Converter={x:StaticResource FulldateToDateOnlyConverter}}\" />";

    [ObservableProperty]
    string fulldateToDateOnlyConverterCsharpCode = "public class FulldateToDateOnlyConverter : IValueConverter\r\n{\r\n    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)\r\n    {\r\n        var birthDay = (DateTime?)value;\r\n        return birthDay?.Date.ToString(\"MM/dd/yyyy\");\r\n    }\r\n\r\n    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)\r\n    {\r\n        throw new NotImplementedException();\r\n    }\r\n}";

    [ObservableProperty]
    IControlInfo controlInformation;
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}
