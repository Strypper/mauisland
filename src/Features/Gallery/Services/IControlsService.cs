
namespace MAUIsland;

public interface IControlsService
{
    Task<IEnumerable<ControlGroupInfo>> GetControlGroupsAsync();
    Task<IEnumerable<IControlInfo>> GetControlsAsync(string groupName);
    Task<IControlInfo> GetControlByNameAsync(string groupName, string controlName);
}
