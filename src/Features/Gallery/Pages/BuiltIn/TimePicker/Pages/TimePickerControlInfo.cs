namespace MAUIsland.Gallery.BuiltIn;

class TimePickerControlInfo : IControlInfo
{
    public string ControlName => nameof(TimePicker);
    public string ControlRoute => typeof(TimePickerPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_clock_24_regular
    };
    public string ControlDetail => "TimePicker invokes the platform's time-picker control and allows you to select a time.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}
