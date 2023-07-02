namespace MAUIsland;
public partial class AcrylicViewPage : IControlPage
{
    #region [CTor]
    public AcrylicViewPage(AcrylicViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}