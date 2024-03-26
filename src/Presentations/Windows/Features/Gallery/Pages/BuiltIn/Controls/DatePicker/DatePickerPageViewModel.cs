using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class DatePickerPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public DatePickerPageViewModel(IAppNavigator appNavigator,
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
    IBuiltInGalleryCardInfo controlInformation;

    [ObservableProperty]
    string simpleDatePickerXamlCode = "<DatePicker />";

    [ObservableProperty]
    string datePickerUseDateOnlyConverterXamlCode =
        "<DatePicker x:Name=\"DateOnlyDatePicker\" />\r\n" +
        "<Label Text=\"{x:Binding Source={x:Reference DateOnlyDatePicker}, Path=Date, Converter={x:StaticResource FulldateToDateOnlyConverter}}\" />";

    [ObservableProperty]
    string fulldateToDateOnlyConverterCsharpCode =
        "public class FulldateToDateOnlyConverter : IValueConverter\n" +
        "{\n" +
        "    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)\n" +
        "    {\n" +
        "        var birthDay = (DateTime?)value;\n" +
        "        return birthDay?.Date.ToString(\"MM/dd/yyyy\");\n" +
        "    }\n" +
        "\n" +
        "    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)\n" +
        "    {\n" +
        "        throw new NotImplementedException();\n" +
        "    }\n" +
        "}";

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
