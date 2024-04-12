using CommunityToolkit.Maui.Converters;

namespace MAUIsland.Core;

class EnumToBoolConverterControlInfo : ICommunityToolkitGalleryCardInfo
{
    public string ControlName => nameof(EnumToBoolConverter);

    public string ControlRoute => "MAUIsland.EnumToBoolConverterPage";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The EnumToBoolConverter is a one way converter that allows you to convert an Enum to a corresponding bool based on whether it is equal to a set of supplied enum values. It is useful when binding a collection of values representing an enumeration type to a boolean control property like the IsVisible property.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/Toolkit/Converters/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/enum-to-bool-converter";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Converter;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}
