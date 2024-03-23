namespace MAUIsland.Core;

public interface IGithubGalleryCardInfo : IGalleryCardInfo
{
    string RepositoryName { get; }
    string AuthorName { get; }
}

