namespace MAUIsland;
class FrameControlInfo : IBuiltInGalleryCardInfo
{
    public string ControlName => nameof(Frame);
    public string ControlRoute => typeof(FramePage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_square_shadow_20_regular
    };
    public string ControlDetail => "Frame is used to wrap a view or layout with a border that can be configured with color, shadow, and other options. Frames can be used to create borders around controls but can also be used to create more complex UI.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/frame?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
    public BuiltInGalleryCardStatus Status => BuiltInGalleryCardStatus.Buggy;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}