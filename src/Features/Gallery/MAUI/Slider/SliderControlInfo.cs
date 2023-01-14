namespace MAUIsland.Gallery.BuiltIn;

class SliderControlInfo : IControlInfo
{
    public string ControlName => nameof(Slider);
    public string ControlRoute => typeof(SliderPage).FullName;
    public ImageSource ControlIcon => "fluenticon_options_white.png";
    public string ControlDetail => "Slider is a horizontal bar that you can manipulate to select a double value from a continuous range.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}
