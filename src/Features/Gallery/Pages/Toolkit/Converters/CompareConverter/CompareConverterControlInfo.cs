using CommunityToolkit.Maui.Converters;

namespace MAUIsland;

class CompareConverterControlInfo : ICommunityToolkitGalleryCardInfo
{
    public string ControlName => nameof(CompareConverter);

    public string ControlRoute => typeof(CompareConverterPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The CompareConverter is a one way converter that take an incoming value implementing IComparable, compares to a specified value, and returns the comparison result. The result will default to a bool if no objects were specified through the TrueObject and/or FalseObject properties. If values are assigned to the TrueObject and/or FalseObject properties, the CompareConverter returns the respective object assigned.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Toolkit/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/compare-converter";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Converter;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}
