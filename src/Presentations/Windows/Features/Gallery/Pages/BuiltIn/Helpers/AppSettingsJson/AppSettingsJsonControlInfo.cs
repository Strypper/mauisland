namespace MAUIsland.Features.Gallery.Pages.BuiltIn.Helpers.AppSettingsJson;
class AppSettingsJsonControlInfo : IBuiltInGalleryCardInfo
{
    public string ControlName => "Application Settings JSON";
    public string ControlRoute => typeof(AppSettingsJsonPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_braces_24_regular
    };
    public string ControlDetail => "Use appsettings.json inside your application thanks to MauiAppBuilder, we can use the ConfigurationManager that is built into configure settings in our .NET MAUI app";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/BuiltIn/Helpers/AppSettingsJson";
    public string DocumentUrl => $"https://montemagno.com/dotnet-maui-appsettings-json-configuration/";
    public string GroupName => ControlGroupInfo.BuiltInControls;
    public BuiltInGalleryCardStatus Status => BuiltInGalleryCardStatus.Unverified;
    public GalleryCardType CardType => GalleryCardType.Helper;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
    public string GitHubAuthorIssueName => "dotnet";
    public string GitHubRepositoryIssueName => "maui";
    public List<string> GitHubIssueLabels => new List<string>() { "area/hosting 🧩" };
}