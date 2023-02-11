namespace MAUIsland;
public partial class SfListViewPage : IControlPage
{
    public SfListViewPage(SfListViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}