using CommunityToolkit.Maui.Converters;

namespace MAUIsland.Core;

class EnumToIntConverterControlInfo : ICommunityToolkitGalleryCardInfo
{
    public string ControlName => nameof(EnumToIntConverter);

    public string ControlRoute => "MAUIsland.EnumToIntConverterPage";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The EnumToIntConverter is a converter that allows you to convert a standard Enum (extending int) to its underlying primitive int type. It is useful when binding a collection of values representing an enumeration type with default numbering to a control such as a Picker.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/Toolkit/Converters/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/enum-to-int-converter";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Converter;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}
