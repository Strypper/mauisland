using Syncfusion.Maui.Data;

namespace MAUIsland;

public class CarouselViewItemDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate HighlightedTemplate { get; set; }
    public DataTemplate NormalTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var selectedItem = (CarouselItem)item;
        return selectedItem.Id.Equals("1") ? HighlightedTemplate : NormalTemplate;
    }
}
