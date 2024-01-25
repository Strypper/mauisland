using CommunityToolkit.Maui.Converters;

namespace MAUIsland;

class DateTimeOffsetConverterControlInfo : ICommunityToolkitGalleryCardInfo
{
    public string ControlName => nameof(DateTimeOffsetConverter);

    public string ControlRoute => typeof(DateTimeOffsetConverterPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The DateTimeOffsetConverter is a converter that allows users to convert a DateTimeOffset to a DateTime. Sometimes a DateTime value is stored with the offset on a backend to allow for storing the timezone in which a DateTime originated from. Controls like the Microsoft.Maui.Controls.DatePicker only work with DateTime. This converter can be used in those scenarios.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Toolkit/Converters/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/datetimeoffsetconverter";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Converter;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}
