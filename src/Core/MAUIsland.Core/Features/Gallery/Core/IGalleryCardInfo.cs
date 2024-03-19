namespace MAUIsland.Core;

public interface IGalleryCardInfo
{
    ImageSource ControlIcon { get; }
    string ControlName { get; }
    string ControlDetail { get; }
    string ControlRoute { get; }
    string GitHubUrl { get; }
    string DocumentUrl { get; }
    string GroupName { get; }
    GalleryCardType CardType { get; }
    GalleryCardStatus CardStatus { get; }
    DateTime LastUpdate { get; }
    List<string> DoList { get; }
    List<string> DontList { get; }
}

