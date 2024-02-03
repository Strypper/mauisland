namespace MAUIsland;

public interface IGithubGalleryCardInfo : IGalleryCardInfo
{
    string RepositoryName { get; }
    string AuthorName { get; }
}

