namespace MAUIsland.Gallery.BuiltIn;

class StepperControlInfo : IControlInfo
{
    public string ControlName => nameof(Stepper);
    public string ControlRoute => typeof(StepperPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_add_24_regular
    };
    public string ControlDetail => "Stepper enables a numeric value to be selected from a range of values. It consists of two buttons labeled with minus and plus signs.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}
