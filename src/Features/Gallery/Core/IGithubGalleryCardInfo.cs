namespace MAUIsland;

public interface IGithubGalleryCardInfo : IGalleryCardInfo
{
    string RepositoryUrl { get; }
    string AuthorUrl { get; }
    string AuthorAvatar { get; }
    int Stars { get; }
    int Forks { get; }
    int Issues { get; }
    string License { get; }
    List<PlatformInfo> SupportedPlatformsInfo { get; }
}

