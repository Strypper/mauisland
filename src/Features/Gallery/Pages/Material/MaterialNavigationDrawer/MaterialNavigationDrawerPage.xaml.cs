namespace MAUIsland;
public partial class MaterialNavigationDrawerPage : IControlPage
{
    #region [CTor]
    public MaterialNavigationDrawerPage(MaterialNavigationDrawerPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}