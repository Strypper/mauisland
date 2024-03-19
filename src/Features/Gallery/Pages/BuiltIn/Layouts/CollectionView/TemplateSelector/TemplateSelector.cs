using Syncfusion.Maui.ListView;

namespace MAUIsland;

public class TemplateSelector : DataTemplateSelector
{
    #region [ Properties ]
    public DataTemplate NormalTemplate { get; set; }
    public DataTemplate SelectedTemplate { get; set; }
    #endregion

    #region [ CTor ]
    public TemplateSelector()
    {
    }
    #endregion

    #region [ Override ]
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var collectionView = (CollectionView)container;
        var selectedItems = collectionView.SelectedItems;

        return selectedItems.Contains(item) ? SelectedTemplate : NormalTemplate;
    }
    #endregion
}
