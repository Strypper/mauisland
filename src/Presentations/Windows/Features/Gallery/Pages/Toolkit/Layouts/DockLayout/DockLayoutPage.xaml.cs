namespace MAUIsland;

public partial class DockLayoutPage : IGalleryPage
{
    #region [CTor]
    public DockLayoutPage(DockLayoutPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}