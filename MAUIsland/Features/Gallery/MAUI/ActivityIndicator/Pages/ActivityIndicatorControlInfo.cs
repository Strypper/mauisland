namespace MAUIsland;

class ActivityIndicatorControlInfo : IControlInfo
{
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };

    public string ControlName => nameof(ActivityIndicator);

    public string ControlDetail => $"{ControlName} displays an animation to show that the application is engaged in a lengthy activity. Unlike {nameof(ProgressBar)}, {ControlName} gives no indication of progress.";

    public string ControlRoute => nameof(ActivityIndicatorPage);

    public string GitHubUrl => "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/ActivityIndicator";

    public string DocumentUrl => "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/activityindicator?view=net-maui-7.0";

    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}