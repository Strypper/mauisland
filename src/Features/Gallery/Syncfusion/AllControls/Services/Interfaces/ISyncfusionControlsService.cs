
namespace MAUIsland;

public interface ISyncfusionControlsService
{
    Task<IEnumerable<ControlInfo>> GetAllControlInfoAsync();
}
