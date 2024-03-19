namespace MAUIsland.Core;

public interface IMaterialUIGalleryCardInfo : IGalleryCardInfo
{
    string MaterialIcon { get; }
    List<PlatformInfo> SupportedPlatformsInfo { get; }
}
