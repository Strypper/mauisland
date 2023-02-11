namespace MAUIsland;

public class BrandCardTemplateSelector : DataTemplateSelector
{
    public DataTemplate BuiltInCardTemplate { get; set; }
    public DataTemplate SyncfustionCardTemplate { get; set; }
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        return ((IControlInfo)item).GroupName == ControlGroupInfo.BuiltInControls
            ? BuiltInCardTemplate
            : SyncfustionCardTemplate;
    }
}
