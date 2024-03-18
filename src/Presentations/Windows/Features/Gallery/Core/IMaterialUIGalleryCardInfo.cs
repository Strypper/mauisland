namespace MAUIsland;

public interface IMaterialUIGalleryCardInfo : IGalleryCardInfo
{
    string MaterialIcon { get; }
    List<PlatformInfo> SupportedPlatformsInfo { get; }
}
