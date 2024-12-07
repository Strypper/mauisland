namespace MAUIsland.Core;

public class ChartTemplateSelector : DataTemplateSelector
{
    public DataTemplate? NormalTemplate { get; set; }
    public DataTemplate? SelectedTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var collectionView = container as CollectionView;
        if (collectionView!.SelectedItem == item)
        {
            return SelectedTemplate!;
        }
        //var resource = collectionView!.SelectedItem == item ? SelectedTemplate! : NormalTemplate!;

        return NormalTemplate!;
    }
}

