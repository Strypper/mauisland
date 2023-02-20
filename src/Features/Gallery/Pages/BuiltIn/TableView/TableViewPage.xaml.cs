namespace MAUIsland;

public partial class TableViewPage : IControlPage
{
    #region [CTor]
    public TableViewPage(TableViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

}