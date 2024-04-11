using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;


public partial class TimePickerPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public TimePickerPageViewModel(IAppNavigator appNavigator,
                                   IGitHubService gitHubService,
                                   IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                    : base(appNavigator,
                                           gitHubService,
                                           gitHubIssueLocalDbService)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string simpleTimePickerXamlCode =
    "<TimePicker Time=\"4:15:26\" />";

    [ObservableProperty]
    string simpleTimePickerCSharpCode =
        "TimePicker timePicker = new TimePicker\r\n" +
        "{\r\n" +
        "    Time = new TimeSpan(4, 15, 26) // Time set to \"04:15:26\"\r\n" +
        "};";

    [ObservableProperty]
    string timeOnlyContrutorsExampleCSharpCode =
        "public TimeOnly(int hour, int minute)\r\n" +
        "public TimeOnly(int hour, int minute, int second)\r\n" +
        "public TimeOnly(int hour, int minute, int second, int millisecond)";

    [ObservableProperty]
    string timeOnlyExampleCSharpCode =
        "var startTime = new TimeOnly(10, 30);";

    [ObservableProperty]
    string timeOnyToTimeSpanConverterCSharpCode =
        "public class TimeOnyToTimeSpanConverter : IValueConverter\r\n" +
        "{\r\n" +
        "    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)\r\n" +
        "    {\r\n" +
        "        var timeOnly = (TimeOnly)value;\r\n" +
        "        return timeOnly.ToTimeSpan();\r\n" +
        "    }\r\n\r\n" +
        "    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)\r\n" +
        "    {\r\n" +
        "        var timeSpan = (TimeSpan)value;\r\n" +
        "        return TimeOnly.FromTimeSpan(timeSpan);\r\n" +
        "    }\r\n}";

    [ObservableProperty]
    TimeOnly timeOnlyTime = new(10, 30);


    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();

    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
        await RefreshAsync();
    }
    #endregion

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    async Task RefreshAsync()
    {
        await RefreshControlIssues(true,
                                   ControlInformation.ControlName,
                                   ControlInformation.GitHubAuthorIssueName,
                                   ControlInformation.GitHubRepositoryIssueName,
                                   ControlInformation.GitHubIssueLabels);
    }
    #endregion
}
