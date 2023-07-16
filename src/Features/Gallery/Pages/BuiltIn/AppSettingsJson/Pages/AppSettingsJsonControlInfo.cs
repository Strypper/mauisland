namespace MAUIsland.Gallery.BuiltIn;
class AppSettingsJsonControlInfo : IControlInfo
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
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/AppSettingsJson";
    public string DocumentUrl => $"https://montemagno.com/dotnet-maui-appsettings-json-configuration/";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}