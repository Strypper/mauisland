namespace MAUIsland;

public class BrandCardTemplateSelector : DataTemplateSelector
{
    public DataTemplate BuiltInCardTemplate { get; set; }
    public DataTemplate GithubCardTemplate { get; set; }
    public DataTemplate MaterialUICardTemplate { get; set; }
    public DataTemplate SyncfustionCardTemplate { get; set; }
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var controlGroup = ((IControlInfo)item).GroupName;
        switch (controlGroup)
        {
            case ControlGroupInfo.SyncfusionControls:
                return SyncfustionCardTemplate;
            case ControlGroupInfo.GitHubCommunity:
                return GithubCardTemplate;
            case ControlGroupInfo.MaterialComponent:
                return MaterialUICardTemplate;
            default:
                return BuiltInCardTemplate;
        }
    }

}
