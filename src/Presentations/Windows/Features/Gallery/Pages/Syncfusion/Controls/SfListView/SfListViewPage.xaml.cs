namespace MAUIsland;
public partial class SfListViewPage : IGalleryPage
{
    public SfListViewPage(SfListViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}