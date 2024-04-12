using CommunityToolkit.Maui.Converters;

namespace MAUIsland.Core;

class ByteArrayToImageSourceConverterControlInfo : ICommunityToolkitGalleryCardInfo
{
    public string ControlName => nameof(ByteArrayToImageSourceConverter);

    public string ControlRoute => "MAUIsland.ByteArrayToImageSourceConverterPage";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The ByteArrayToImageSourceConverter is a converter that allows the user to convert an incoming value from a byte array and returns an ImageSource. This object can then be used as the Source of an Image control.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/Toolkit/Converters/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/byte-array-to-image-source-converter";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Converter;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}
