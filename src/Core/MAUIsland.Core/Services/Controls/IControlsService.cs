
namespace MAUIsland.Core;

public interface IControlsService
{
    Task<IEnumerable<ControlGroupInfo>> GetControlGroupsAsync();
    Task<IEnumerable<IGalleryCardInfo>> GetControlsAsync(string groupName);
    Task<IGalleryCardInfo> GetControlByNameAsync(string groupName, string controlName);
    Task<ControlIssueModel> GetControlIssues(string controlGroup, IEnumerable<string> labels);
}
