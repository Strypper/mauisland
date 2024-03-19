namespace MAUIsland;
public partial class OverFlowerPage : IGalleryPage
{
    #region [CTor]
    public OverFlowerPage(OverFlowerPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}