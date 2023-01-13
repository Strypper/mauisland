
namespace MAUIsland;

public interface IControlsService
{
    Task<IEnumerable<ControlGroupInfo>> GetControlGroupsAsync();
    Task<IEnumerable<IControlInfo>> GetControlsAsync(string groupName);
}
