namespace MAUIsland;
class StackLayoutControlInfo : IBuiltInGalleryCardInfo
{
    public string ControlName => nameof(StackLayout);
    public string ControlRoute => typeof(StackLayoutPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_phone_vertical_scroll_20_regular
    };
    public string ControlDetail => "The .NET Multi-platform App UI (.NET MAUI) StackLayout organizes child views in a one-dimensional stack, either horizontally or vertically. By default, a StackLayout is oriented vertically. In addition, a StackLayout can be used as a parent layout that contains other child layouts.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/stacklayout?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
    public BuiltInGalleryCardStatus Status => BuiltInGalleryCardStatus.Deprecated;
    public GalleryCardType CardType => GalleryCardType.Layout;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}