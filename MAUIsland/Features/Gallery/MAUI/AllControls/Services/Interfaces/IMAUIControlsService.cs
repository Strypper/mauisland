
namespace MAUIsland;

public interface IMAUIControlsService
{
    Task<IEnumerable<ControlInfo>> GetAllControlInfoAsync();
}
