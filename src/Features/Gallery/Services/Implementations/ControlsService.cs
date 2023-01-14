namespace MAUIsland;

public class ControlsService : IControlsService
{
    private readonly IControlInfo[] controlInfos;

    public ControlsService(IEnumerable<IControlInfo> controlInfos)
    {
        this.controlInfos = controlInfos.ToArray();
    }

    private readonly IList<ControlGroupInfo> controlGroupInfos = new List<ControlGroupInfo>()
    {
        new ControlGroupInfo
        {
            Name = ControlGroupInfo.BuiltInControls,
            Title = "Built-in Controls",
            IconUrl = "dotnet_bot.png",
        },
        new ControlGroupInfo
        {
            Name = ControlGroupInfo.SyncfusionControls,
            Title = "Syncfusion Controls",
            IconUrl = "syncfusion_logo.png",
        },
    };

    public Task<IEnumerable<ControlGroupInfo>> GetControlGroupsAsync()
    {
        return Task.Run(() =>
        {
            return (IEnumerable<ControlGroupInfo>)controlGroupInfos;
        });
    }

    public Task<IEnumerable<IControlInfo>> GetControlsAsync(string groupName)
    {
        return Task.Run(() =>
        {
            IEnumerable<IControlInfo> result = controlInfos
                .Where(x => x.GroupName == groupName);

            return string.IsNullOrWhiteSpace(groupName)
                    ? controlInfos
                    : controlInfos
                        .Where(x => x.GroupName == groupName);
        });
    }
}
