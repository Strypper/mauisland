namespace MAUIsland;

public partial class TableViewPage : IControlPage
{
    #region [CTor]
    public TableViewPage(ActivityIndicatorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

}