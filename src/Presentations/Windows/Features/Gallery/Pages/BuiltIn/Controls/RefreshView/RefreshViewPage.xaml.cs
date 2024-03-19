namespace MAUIsland;


public partial class RefreshViewPage : IGalleryPage
{
    #region [CTor]
    public RefreshViewPage(RefreshViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

}