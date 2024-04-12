namespace MAUIsland;
public partial class DataGridPage : IGalleryPage
{
    #region [CTor]
    public DataGridPage(DataGridPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}