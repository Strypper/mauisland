namespace MAUIsland.Gallery.Community;
class AdaptivePropertiesControlInfo : IControlInfo 
{
    public string ControlName => "AdaptiveProperties";
    public string ControlRoute => typeof(AdaptivePropertiesPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "A nuget that help MAUI developer adapt their mobile UI application orientations more efficent for simple case";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Community/{ControlName}";
    public string DocumentUrl => $"https://github.com/rudyspano/MAUI-Adaptive-Properties";
    public string GroupName => ControlGroupInfo.GitHubCommunity;
}