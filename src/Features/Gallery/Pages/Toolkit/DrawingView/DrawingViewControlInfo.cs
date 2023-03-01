using CommunityToolkit.Maui.Views;

namespace MAUIsland;
class DrawingViewControlInfo : IControlInfo 
{
    public string ControlName => nameof(DrawingView);
    public string ControlRoute => typeof(DrawingViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The DrawingView provides a surface that allows for the drawing of lines through the use of touch or mouse interaction. The result of a users drawing can be saved out as an image. A common use case for this is to provide a signature box in an application.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Toolkit/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/views/drawingview";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
}