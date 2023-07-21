namespace MAUIsland;
public partial class MaterialNavigationDrawerPage : IGalleryPage
{
    #region [CTor]
    public MaterialNavigationDrawerPage(MaterialNavigationDrawerPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}