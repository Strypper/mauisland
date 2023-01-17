namespace MAUIsland.Gallery.BuiltIn;

class EditorControlInfo : IControlInfo
{
    public string ControlName => nameof(Editor);
    public string ControlRoute => typeof(EditorPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_code_text_edit_20_regular
    };
    public string ControlDetail => "ActivityIndicator displays an animation to show that the application is engaged in a lengthy activity. Unlike ProgressBar, ActivityIndicator gives no indication of progress.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}
