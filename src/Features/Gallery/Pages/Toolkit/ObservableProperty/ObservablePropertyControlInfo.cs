using CommunityToolkit.Maui.Views;

namespace MAUIsland;

class ObservablePropertyControlInfo : IControlInfo 
{
    public string ControlName => "Observable Property";

    public string ControlRoute => typeof(ObservablePropertyPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The ObservableProperty type is an attribute that allows generating observable properties from annotated fields. Its purpose is to greatly reduce the amount of boilerplate that is needed to define observable properties.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Toolkit/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/observableproperty";
    public string GroupName => ControlGroupInfo.CommunityToolkit;

}