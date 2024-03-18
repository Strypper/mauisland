﻿namespace MAUIsland;

class BorderControlInfo : IBuiltInGalleryCardInfo
{
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_checkbox_indeterminate_24_regular
    };
    public string ControlName => nameof(Border);
    public string ControlDetail => $"The .NET Multi-platform App UI (.NET MAUI) Border is a container control that draws a border, background, or both, around another control. A Border can only contain one child object. If you want to put a border around multiple objects, wrap them in a container object such as a layout.";
    public string ControlRoute => typeof(BorderPage).FullName;
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/BuiltIn/Controls{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/border?view=net-maui-9.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
    public BuiltInGalleryCardStatus Status => BuiltInGalleryCardStatus.Stable;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}