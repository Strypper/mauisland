namespace MAUIsland;

public partial class SwipeViewPage : IGalleryPage
{
    #region [CTor]
    public SwipeViewPage(SwipeViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}