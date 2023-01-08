namespace MAUIsland;

public partial class TableViewPage
{
    #region [CTor]
    public TableViewPage(ActivityIndicatorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

}