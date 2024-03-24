using Syncfusion.Maui.Data;

namespace MAUIsland;

public class ItemDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate HighlightedTemplate { get; set; }
    public DataTemplate NormalTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var carouselView = (CarouselView)container;
        var selectedItem = (CarouselItem)item;
        var itemSource = carouselView.ItemsSource.ToList<CarouselItem>();
        var chosenItem = itemSource.Where(x => x.Id == "1").FirstOrDefault();

        return selectedItem.Equals(chosenItem) ? HighlightedTemplate : NormalTemplate;
    }
}
