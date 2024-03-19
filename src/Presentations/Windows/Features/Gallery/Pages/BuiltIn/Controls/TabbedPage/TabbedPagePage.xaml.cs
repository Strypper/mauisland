namespace MAUIsland;
public partial class TabbedPagePage : IGalleryPage
{
    #region [CTor]
    public TabbedPagePage(TabbedPagePageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}