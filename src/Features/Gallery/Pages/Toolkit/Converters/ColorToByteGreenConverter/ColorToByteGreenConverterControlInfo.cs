﻿using CommunityToolkit.Maui.Converters;

namespace MAUIsland;

class ColorToByteGreenConverterControlInfo : ICommunityToolkitGalleryCardInfo
{
    public string ControlName => nameof(ColorToByteGreenConverter);

    public string ControlRoute => typeof(ColorToByteGreenConverterPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The ColorToByteGreenConverter is a one way converter that allows users to convert an incoming Color to the green component as a value between 0 and 255.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Toolkit/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-byte-green-converter";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Converter;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}