namespace MAUIsland;
public partial class GridPage : IControlPage
{
    #region [CTor]
    public GridPage(GridPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}