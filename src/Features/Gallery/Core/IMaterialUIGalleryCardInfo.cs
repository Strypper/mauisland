using IconPacks.Material;
using Material.Components.Maui;

namespace MAUIsland;

public interface IMaterialUIGalleryCardInfo : IGalleryCardInfo
{
    IconKind MaterialIcon { get; }
    List<PlatformInfo> SupportedPlatformsInfo { get; }
}
