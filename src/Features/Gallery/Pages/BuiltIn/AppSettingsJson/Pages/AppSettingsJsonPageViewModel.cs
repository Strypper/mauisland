namespace MAUIsland;
public partial class AppSettingsJsonPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public AppSettingsJsonPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string appSettingsJsonContent = "{\r\n  \"Settings\": {\r\n    \"KeyOne\": 1,\r\n    \"KeyTwo\": true,\r\n    \"KeyThree\": {\r\n      \"Message\": \"Oh, that's nice...\"\r\n    }\r\n  }\r\n}";

    [ObservableProperty]
    string appSettingsCSharpClasses = "public class Settings\r\n{\r\n\tpublic int KeyOne { get; set; }\r\n\tpublic bool KeyTwo { get; set; }\r\n\tpublic NestedSettings KeyThree { get; set; } = null!;\r\n}\r\n\r\npublic class NestedSettings\r\n{\r\n\tpublic string Message { get; set; } = null!;\r\n}";

    [ObservableProperty]
    string packageReferencesCode = "<ItemGroup>\r\n    <PackageReference Include=\"Microsoft.Extensions.Configuration.Binder\" Version=\"6.0.0\" />\r\n    <PackageReference Include=\"Microsoft.Extensions.Configuration.Json\" Version=\"6.0.0\" />\r\n</ItemGroup>";

    [ObservableProperty]
    string setUpConfigBuilder = "var a = Assembly.GetExecutingAssembly();\r\nusing var stream = a.GetManifestResourceStream(\"MauiApp27.appsettings.json\");\r\n\r\nvar config = new ConfigurationBuilder()\r\n\t\t\t.AddJsonStream(stream)\r\n\t\t\t.Build();\r\n\r\n\r\nbuilder.Configuration.AddConfiguration(config);";

    [ObservableProperty]
    string registerMainPageToServiceCollection = "builder.Services.AddTransient<MainPage>();";

    [ObservableProperty]
    string injectMainPageService = "public App(MainPage page)\r\n\t{\r\n\t\tInitializeComponent();\r\n\r\n\t\tMainPage = page;\r\n\t}";

    [ObservableProperty]
    string mainPageWithCounterClickEvent = "int count = 0;\r\n\tIConfiguration configuration;\r\n\tpublic MainPage(IConfiguration config)\r\n\t{\r\n\t\tInitializeComponent();\r\n\r\n\t\tconfiguration = config;\r\n\r\n\t}\r\n\r\n\tprivate async void OnCounterClicked(object sender, EventArgs e)\r\n\t{\r\n\t\tcount++;\r\n\t\tCounterLabel.Text = $\"Current count: {count}\";\r\n\r\n\t\tSemanticScreenReader.Announce(CounterLabel.Text);\r\n\r\n\r\n\t\tvar settings = configuration.GetRequiredSection(\"Settings\").Get<Settings>();\r\n\t\tawait DisplayAlert(\"Config\", $\"{nameof(settings.KeyOne)}: {settings.KeyOne}\" +\r\n            $\"{nameof(settings.KeyTwo)}: {settings.KeyTwo}\" +\r\n            $\"{nameof(settings.KeyThree.Message)}: {settings.KeyThree.Message}\", \"OK\");\r\n\t}";

    [ObservableProperty]
    string serviceProviderExample = "public static class MauiProgram\r\n{\r\n    public static MauiApp CreateMauiApp()\r\n    {\r\n        //normal builder stuff\r\n\r\n        var app = builder.Build();\r\n        Services = app.Services;\r\n\r\n        return app;\r\n    }\r\n\r\n    public static IServiceProvider Services { get; private set; }\r\n}";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion
}