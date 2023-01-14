namespace MAUIsland.Gallery.BuiltIn;

class SearchBarControlInfo : IControlInfo
{
    public string ControlName => nameof(SearchBar);
    public string ControlRoute => typeof(SearchBarPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_search_24_regular
    };
    public string ControlDetail => "SearchBar is a user input control used to initiating a search.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}
