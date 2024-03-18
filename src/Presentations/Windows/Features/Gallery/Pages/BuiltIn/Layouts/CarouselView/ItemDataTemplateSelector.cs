namespace MAUIsland;

public class ItemDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate Highlighted { get; set; }
    public DataTemplate Other { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        return ((CarouselItem)item).Content.Contains("Number 1") ? Highlighted : Other;
    }
}
