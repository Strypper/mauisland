using DiscordRPC;
using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class BlazorWebViewPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ CTor ]
    public BlazorWebViewPageViewModel(IAppNavigator appNavigator,
                                      IGitHubService gitHubService,
                                      DiscordRpcClient discordRpcClient,
                                      IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                            : base(appNavigator,
                                                    gitHubService,
                                                    discordRpcClient,
                                                    gitHubIssueLocalDbService)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    int counter;

    [ObservableProperty]
    ObservableCollection<string> navigationPageName = new()
    {
        "Main Page",
        "Counter",
        "Weather Page"
    };

    [ObservableProperty]
    string blazorWebViewStartPath = "/blazor-web-view/";

    [ObservableProperty]
    string csprojChanges = "<Project Sdk=\"Microsoft.NET.Sdk.Razor\">";

    [ObservableProperty]
    string blazorWebViewXamlCode = "<ContentPage xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n             xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n             xmlns:local=\"clr-namespace:MyBlazorApp\"\r\n             x:Class=\"MyBlazorApp.MainPage\">\r\n\r\n    <BlazorWebView HostPage=\"wwwroot/index.html\">\r\n        <BlazorWebView.RootComponents>\r\n            <RootComponent Selector=\"#app\" ComponentType=\"{x:Type local:Main}\" />\r\n        </BlazorWebView.RootComponents>\r\n    </BlazorWebView>\r\n\r\n</ContentPage>";

    [ObservableProperty]
    string blazorWebViewConfig = "public static class MauiProgram\r\n{\r\n    public static MauiApp CreateMauiApp()\r\n    {\r\n        var builder = MauiApp.CreateBuilder();\r\n        builder\r\n            .UseMauiApp<App>()\r\n            .ConfigureFonts(fonts =>\r\n            {\r\n                fonts.AddFont(\"OpenSans-Regular.ttf\", \"OpenSansRegular\");\r\n            });\r\n\r\n        builder.Services.AddMauiBlazorWebView();\r\n#if DEBUG\r\n        builder.Services.AddBlazorWebViewDeveloperTools();\r\n#endif\r\n        // Register any app services on the IServiceCollection object\r\n        // e.g. builder.Services.AddSingleton<WeatherForecastService>();\r\n\r\n        return builder.Build();\r\n    }\r\n}";
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
    public void CounterButton()
    {
        this.Counter++;
    }

    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    Task NavigatePageAsync(string route)
        => AppNavigator.NavigateAsync(route);

    [RelayCommand]
    async Task RefreshAsync()
    {
        if (ControlInformation is null)
            return;

        await RefreshControlIssues(true,
                                   ControlInformation.ControlName,
                                   ControlInformation.GitHubAuthorIssueName,
                                   ControlInformation.GitHubRepositoryIssueName,
                                   ControlInformation.GitHubIssueLabels);
    }
    #endregion
}
