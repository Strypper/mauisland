namespace MAUIsland;

public class ControlsService : IControlsService
{
    private readonly IControlInfo[] controlInfos;

    #region [CTor]
    public ControlsService(IEnumerable<IControlInfo> controlInfos)
    {
        this.controlInfos = controlInfos.ToArray();
    }
    #endregion

    private readonly IList<ControlGroupInfo> controlGroupInfos = new List<ControlGroupInfo>()
    {
        new ControlGroupInfo
        {
            Name = ControlGroupInfo.SyncfusionControls,
            Title = "Syncfusion",
            IconUrl = "syncfusion_logo.png",
            Banner = "syncfusionbanner.png"
        },
        new ControlGroupInfo
        {
            Name = ControlGroupInfo.BuiltInControls,
            Title = "Built-in",
            LottieUrl = "dotnetbot.json",
            Banner = "builtinbanner.png"
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

    public Task<IControlInfo> GetControlByNameAsync(string groupName, string controlName)
    {

        return Task.Run(() =>
        {
            IEnumerable<IControlInfo> result = controlInfos
                .Where(x => x.GroupName == groupName);

            return controlInfos
                        .Where(x => x.GroupName == groupName
                                 && x.ControlName == controlName)
                        .FirstOrDefault();
        });
    }
}
