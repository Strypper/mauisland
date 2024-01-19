using CommunityToolkit.Maui.Converters;

namespace MAUIsland;

class BoolToObjectConverterControlInfo : ICommunityToolkitGalleryCardInfo
{
    public string ControlName => nameof(BoolToObjectConverter);

    public string ControlRoute => typeof(BoolToObjectConverterPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The BoolToObjectConverter is a converter that allows users to convert a bool value binding to a specific object. By providing both a TrueObject and a FalseObject in the converter the appropriate object will be returned depending on the value of the binding.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Toolkit/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/bool-to-object-converter";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Converter;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}
