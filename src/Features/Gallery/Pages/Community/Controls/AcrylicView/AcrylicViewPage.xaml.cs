namespace MAUIsland;
public partial class AcrylicViewPage : IGalleryPage
{
    #region [CTor]
    public AcrylicViewPage(AcrylicViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}