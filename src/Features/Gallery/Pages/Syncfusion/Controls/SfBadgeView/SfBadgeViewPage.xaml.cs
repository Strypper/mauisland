namespace MAUIsland;
public partial class SfBadgeViewPage : IGalleryPage
{
    #region [CTor]
    public SfBadgeViewPage(SfBadgeViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}