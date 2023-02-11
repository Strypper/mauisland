namespace MAUIsland;
public partial class SfBadgeViewPage : IControlPage
{
    #region [CTor]
    public SfBadgeViewPage(SfBadgeViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}