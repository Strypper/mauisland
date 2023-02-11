namespace MAUIsland;
public partial class SfDataGridPage : IControlPage
{
    #region [CTor]
    public SfDataGridPage(SfDataGridPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}