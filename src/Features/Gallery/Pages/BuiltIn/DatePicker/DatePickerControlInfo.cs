namespace MAUIsland.Gallery.BuiltIn;

class DatePickerControlInfo : IControlInfo
{
    public string ControlName => nameof(DatePicker);
    public string ControlRoute => typeof(DatePickerPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_calendar_ltr_24_regular
    };
    public string ControlDetail => "DatePicker invokes the platform's date-picker control and allows you to select a date.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}
