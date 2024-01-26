using CommunityToolkit.Maui.Converters;

namespace MAUIsland;

class ImageResourceConverterControlInfo : ICommunityToolkitGalleryCardInfo
{
    public string ControlName => nameof(ImageResourceConverter);

    public string ControlRoute => typeof(ImageResourceConverterPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The ImageResourceConverter is a converter that converts embedded image resource ID to its ImageSource. An embedded image resource is when an image has been added to a project with the Build Action set to Embedded Resource.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Toolkit/Converters/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/image-resource-converter";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Converter;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}
