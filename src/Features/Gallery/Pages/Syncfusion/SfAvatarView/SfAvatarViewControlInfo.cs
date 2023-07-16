using Syncfusion.Maui.Core;

namespace MAUIsland.Gallery.Syncfusion;
class SfAvatarViewControlInfo : IControlInfo 
{
    public string ControlName => nameof(SfAvatarView);
    public string ControlRoute => typeof(SfAvatarViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_person_32_regular
    };
    public string ControlDetail => "The .NET MAUI Avatar View control provides a graphical representation of user image that allows you to customize the view by adding image, background color, icon, text, etc.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Syncfusion/{ControlName}";
    public string DocumentUrl => $"https://help.syncfusion.com/maui/avatar-view/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;
}