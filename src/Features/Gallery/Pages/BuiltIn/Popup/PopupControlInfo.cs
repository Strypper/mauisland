namespace MAUIsland;
class PopupControlInfo : IControlInfo 
{
    public string ControlName => "Popup";
    public string ControlRoute => typeof(PopupPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "Displaying an alert, asking a user to make a choice, or displaying a prompt is a common UI task. .NET Multi-platform App UI (.NET MAUI) has three methods on the Page class for interacting with the user via a pop-up: DisplayAlert, DisplayActionSheet, and DisplayPromptAsync. Pop-ups are rendered with native controls on each platform.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pop-ups?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}