namespace MAUIsland;

public partial class GridLayoutPage
{
    #region [CTor]

    public GridLayoutPage(ActivityIndicatorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}