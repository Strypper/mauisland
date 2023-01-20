namespace MAUIsland;

public partial class SwipeViewPage : IControlPage
{
    #region [CTor]
    public SwipeViewPage(SwipeViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}