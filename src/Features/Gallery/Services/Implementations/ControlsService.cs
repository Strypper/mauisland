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
        new (){
            Name = ControlGroupInfo.SyncfusionControls,
            Title = "Syncfusion",
            IconUrl = "syncfusionlogo.png",
            Banner = "syncfusionbanner.png",
            ProviderUrl = "https://help.syncfusion.com/maui/introduction/overview",
            MicrosoftStoreLink="https://www.microsoft.com/store/productId/9P2P4D2BK270"
        },
        new (){
            Name = ControlGroupInfo.BuiltInControls,
            Title = "Built-in",
            LottieUrl = "island.json",
            Banner = "builtinbanner.png",
            ProviderUrl = "https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui?view=net-maui-7.0"
        },
        new (){
            Name = ControlGroupInfo.CommunityToolkit,
            Title = "Toolkit",
            IconUrl = "communitytoolkitlogo.png",
            Banner = "mauitoolkitbanner.png",
            ProviderUrl = "https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/"
        },
        new (){
            Name = ControlGroupInfo.GitHubCommunity,
            Title = "Community",
            IconUrl = "githublogo.png",
            Banner = "builtinbanner.png",
            ProviderUrl = "https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/"
        },
        new() {
            Name = ControlGroupInfo.MaterialComponent,
            Title = "Material",
            IconUrl = "materialuilogo.png",
            Banner = "materialuibanner.png",
            ProviderUrl = "https://mdc-maui.github.io/"
        }
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
