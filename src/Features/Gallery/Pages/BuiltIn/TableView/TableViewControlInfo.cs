namespace MAUIsland.Gallery.BuiltIn;

class TableViewControlInfo : IControlInfo
{
    public string ControlName => nameof(TableView);
    public string ControlRoute => typeof(TableViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_clock_24_regular
    };
    public string ControlDetail => "TimePicker invokes the platform's time-picker control and allows you to select a time.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}
