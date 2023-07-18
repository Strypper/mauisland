using IconPacks.Material;
using Material.Components.Maui;

namespace MAUIsland;

public interface IMaterialUIControlInfo : IControlInfo
{
    IconKind MaterialIcon { get; }
    List<PlatformInfo> SupportedPlatformsInfo { get; }
}
