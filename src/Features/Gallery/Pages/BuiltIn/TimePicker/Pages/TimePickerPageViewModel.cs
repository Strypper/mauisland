namespace MAUIsland;


public partial class TimePickerPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public TimePickerPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]

    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string simpleTimePickerXamlCode = "<TimePicker Time=\"4:15:26\" />";

    [ObservableProperty]
    string simpleTimePickerCSharpCode = "TimePicker timePicker = new TimePicker\r\n{\r\n  Time = new TimeSpan(4, 15, 26) // Time set to \"04:15:26\"\r\n};";

    [ObservableProperty]
    string timeOnlyContrutorsExampleCSharpCode = "public TimeOnly(int hour, int minute)\r\npublic TimeOnly(int hour, int minute, int second)\r\npublic TimeOnly(int hour, int minute, int second, int millisecond)";

    [ObservableProperty]
    string timeOnlyExampleCSharpCode = "var startTime = new TimeOnly(10, 30);";

    [ObservableProperty]
    string timeOnyToTimeSpanConverterCSharpCode = "public class TimeOnyToTimeSpanConverter : IValueConverter\r\n{\r\n    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)\r\n    {\r\n        var timeOnly = (TimeOnly)value;\r\n        return timeOnly.ToTimeSpan();\r\n    }\r\n\r\n    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)\r\n    {\r\n        var timeSpan = (TimeSpan)value;\r\n        return TimeOnly.FromTimeSpan(timeSpan);\r\n    }\r\n}";

    [ObservableProperty]
    TimeOnly timeOnlyTime = new(10, 30);


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

    #region [Methods]
    #endregion
}
