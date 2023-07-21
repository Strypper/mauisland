namespace MAUIsland;
public partial class DrawingViewPage : IGalleryPage
{
    #region [CTor]
    public DrawingViewPage(DrawingViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}