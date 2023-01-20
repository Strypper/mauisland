namespace MAUIsland.Gallery.BuiltIn;

class LabelControlInfo : IControlInfo
{
    public string ControlName => nameof(Label);
    public string ControlRoute => typeof(LabelPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_text_case_title_24_regular
    };
    public string ControlDetail => "Label displays single-line and multi-line text. Text displayed by a Label can be colored, spaced, and can have text decorations.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}
