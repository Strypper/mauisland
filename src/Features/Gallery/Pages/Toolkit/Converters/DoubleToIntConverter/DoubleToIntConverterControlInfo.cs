using CommunityToolkit.Maui.Converters;

namespace MAUIsland;

class DoubleToIntConverterControlInfo : ICommunityToolkitGalleryCardInfo
{
    public string ControlName => nameof(DoubleToIntConverter);

    public string ControlRoute => typeof(DoubleToIntConverterPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The DoubleToIntConverter is a converter that allows users to convert an incoming double value to an int and vice-versa. Optionally the user can provide a multiplier to the conversion through the Ratio property.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Toolkit/Converters/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/double-to-int-converter";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Converter;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}
