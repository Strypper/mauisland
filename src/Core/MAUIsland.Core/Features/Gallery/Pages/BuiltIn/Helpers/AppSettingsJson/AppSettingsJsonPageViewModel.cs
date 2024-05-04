using DiscordRPC;
using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class AppSettingsJsonPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ CTor ]
    public AppSettingsJsonPageViewModel(IAppNavigator appNavigator,
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
    string appSettingsJsonContent =
        "{\r\n" +
        "  \"Settings\": {\r\n" +
        "    \"KeyOne\": 1,\r\n" +
        "    \"KeyTwo\": true,\r\n" +
        "    \"KeyThree\": {\r\n" +
        "      \"Message\": \"Oh, that's nice...\"\r\n" +
        "    }\r\n" +
        "  }\r\n" +
        "}";

    [ObservableProperty]
    string appSettingsCSharpClasses =
        "public class Settings\r\n" +
        "{\r\n" +
        "    public int KeyOne { get; set; }\r\n" +
        "    public bool KeyTwo { get; set; }\r\n" +
        "    public NestedSettings KeyThree { get; set; } = null!;\r\n" +
        "}\r\n\r\n" +
        "public class NestedSettings\r\n" +
        "{\r\n" +
        "    public string Message { get; set; } = null!;\r\n" +
        "}";

    [ObservableProperty]
    string packageReferencesCode =
        "<ItemGroup>\r\n" +
        "    <PackageReference Include=\"Microsoft.Extensions.Configuration.Binder\" Version=\"6.0.0\" />\r\n" +
        "    <PackageReference Include=\"Microsoft.Extensions.Configuration.Json\" Version=\"6.0.0\" />\r\n" +
        "</ItemGroup>";

    [ObservableProperty]
    string setUpConfigBuilder =
        "var a = Assembly.GetExecutingAssembly();\r\n" +
        "using var stream = a.GetManifestResourceStream(\"MauiApp27.appsettings.json\");\r\n\r\n" +
        "var config = new ConfigurationBuilder()\r\n" +
        "\t\t\t.AddJsonStream(stream)\r\n" +
        "\t\t\t.Build();\r\n\r\n\r\n" +
        "builder.Configuration.AddConfiguration(config);";

    [ObservableProperty]
    string registerMainPageToServiceCollection =
        "builder.Services.AddTransient<MainPage>();";

    [ObservableProperty]
    string injectMainPageService =
        "public App(MainPage page)\r\n" +
        "\t{\r\n" +
        "\t\tInitializeComponent();\r\n\r\n" +
        "\t\tMainPage = page;\r\n\t}";

    [ObservableProperty]
    string mainPageWithCounterClickEvent =
        "int count = 0;\r\n" +
        "\tIConfiguration configuration;\r\n" +
        "\tpublic MainPage(IConfiguration config)\r\n" +
        "\t{\r\n" +
        "\t\tInitializeComponent();\r\n\r\n" +
        "\t\tconfiguration = config;\r\n\r\n\t}\r\n\r\n" +
        "\tprivate async void OnCounterClicked(object sender, EventArgs e)\r\n" +
        "\t{\r\n" +
        "\t\tcount++;\r\n" +
        "\t\tCounterLabel.Text = $\"Current count: {count}\";\r\n\r\n\t\t" +
        "SemanticScreenReader.Announce(CounterLabel.Text);\r\n\r\n\r\n\t\t" +
        "var settings = configuration.GetRequiredSection(\"Settings\").Get<Settings>();\r\n\t\t" +
        "await DisplayAlert(\"Config\", $\"{nameof(settings.KeyOne)}: {settings.KeyOne}\" +\r\n" +
        "            $\"{nameof(settings.KeyTwo)}: {settings.KeyTwo}\" +\r\n" +
        "            $\"{nameof(settings.KeyThree.Message)}: {settings.KeyThree.Message}\", \"OK\");\r\n\t}";

    [ObservableProperty]
    string serviceProviderExample =
        "public static class MauiProgram\r\n" +
        "{\r\n" +
        "    public static MauiApp CreateMauiApp()\r\n" +
        "    {\r\n" +
        "        //normal builder stuff\r\n\r\n" +
        "        var app = builder.Build();\r\n" +
        "        Services = app.Services;\r\n\r\n" +
        "        return app;\r\n    }\r\n\r\n" +
        "    public static IServiceProvider Services { get; private set; }\r\n}";

    #endregion

    #region [ Overrides ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();

    }
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);

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