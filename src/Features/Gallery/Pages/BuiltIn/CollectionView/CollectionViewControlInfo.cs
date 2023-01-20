namespace MAUIsland.Gallery.BuiltIn;

class CollectionViewControlInfo : IControlInfo
{
    public string ControlName => nameof(CollectionView);
    public string ControlRoute => typeof(CollectionViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_apps_list_detail_24_regular
    };
    public string ControlDetail => "CollectionView is a view for presenting lists of data using different layout specifications.  ";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}
