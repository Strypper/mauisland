namespace MAUIsland;


public partial class RefreshViewPage : IControlPage
{
    #region [CTor]
    public RefreshViewPage(RefreshViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

}