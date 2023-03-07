namespace MAUIsland;
public partial class SfMapsViewPage : IControlPage
{
    #region [CTor]
    public SfMapsViewPage(SfMapsViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}