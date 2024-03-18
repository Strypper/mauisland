namespace MAUIsland;
public partial class MaterialProgressIndicatorPage : IGalleryPage
{
    #region [CTor]
    public MaterialProgressIndicatorPage(MaterialProgressIndicatorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}