﻿namespace MAUIsland.Core;

public class ButtonControlInfo : IBuiltInGalleryCardInfo
{
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_add_circle_32_regular
    };
    public string ControlName => nameof(Button);
    public string ControlDetail => $"{ControlName} displays text and responds to a tap or click that directs the app to carry out a task. A {ControlName} usually displays a short text string indicating a command, but it can also display a bitmap image, or a combination of text and an image. When the {ControlName} is pressed with a finger or clicked with a mouse it initiates that command.";
    public string ControlRoute => $"MAUIsland.{ControlName}Page";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/BuiltIn/Controls/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}";
    public string GroupName => ControlGroupInfo.BuiltInControls;
    public BuiltInGalleryCardStatus Status => BuiltInGalleryCardStatus.Buggy;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
    public string GitHubAuthorIssueName => "dotnet";
    public string GitHubRepositoryIssueName => "maui";
    public List<string> GitHubIssueLabels => new List<string>() { "area-controls-button" };
}