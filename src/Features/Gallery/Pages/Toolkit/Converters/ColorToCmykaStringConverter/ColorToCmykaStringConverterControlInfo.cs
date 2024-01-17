using CommunityToolkit.Maui.Converters;

namespace MAUIsland;

class ColorToCmykaStringConverterControlInfo : ICommunityToolkitGalleryCardInfo
{
    public string ControlName => nameof(ColorToCmykaStringConverter);

    public string ControlRoute => typeof(ColorToCmykaStringConverterPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The ColorToCmykaStringConverter is a one way converter that allows users to convert a Color value binding to its CMYKA string equivalent in the format: CMYKA(cyan,magenta,yellow,key,alpha) where cyan, magenta, yellow and key will be a value between 0% and 100%, and alpha will be a value between o and 1 (e.g. CMYKA(0%,100%,100%,0%,1) for Colors.Red.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Toolkit/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-cmyka-string-converter";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Converter;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}
