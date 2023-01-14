namespace MAUIsland.Gallery.BuiltIn;

class CheckBoxControlInfo : IControlInfo
{
    public string ControlName => nameof(CheckBox);
    public string ControlRoute => typeof(CheckBoxPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_checkbox_checked_24_regular
    };
    public string ControlDetail => "CheckBox is a type of button that can either be checked or empty. When a checkbox is checked, it's considered to be on. When a checkbox is empty, it's considered to be off.";
    public string GitHubUrl => "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/CheckBox";
    public string DocumentUrl => "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/checkbox?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}
