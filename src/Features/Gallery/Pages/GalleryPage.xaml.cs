namespace MAUIsland;

public partial class GalleryPage
{
    #region [CTor]
    public GalleryPage(GalleryPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}