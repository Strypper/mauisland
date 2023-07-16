namespace MAUIsland;

class ButtonControlInfo : IControlInfo
{
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_add_circle_32_regular
    };
    public string ControlName => nameof(Button);
    public string ControlDetail => $"{ControlName} displays text and responds to a tap or click that directs the app to carry out a task. A {ControlName} usually displays a short text string indicating a command, but it can also display a bitmap image, or a combination of text and an image. When the {ControlName} is pressed with a finger or clicked with a mouse it initiates that command.";
    public string ControlRoute => typeof(ButtonPage).FullName;
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}