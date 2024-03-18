namespace MAUIsland;

public partial class TableViewPage : IGalleryPage
{
    #region [CTor]
    public TableViewPage(TableViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

}