namespace MAUIsland;
public partial class SfMapPage : IControlPage
{
    #region [CTor]
    public SfMapPage(SfMapPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}