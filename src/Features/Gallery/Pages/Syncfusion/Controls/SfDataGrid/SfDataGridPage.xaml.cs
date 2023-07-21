namespace MAUIsland;
public partial class SfDataGridPage : IGalleryPage
{
    #region [CTor]
    public SfDataGridPage(SfDataGridPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}