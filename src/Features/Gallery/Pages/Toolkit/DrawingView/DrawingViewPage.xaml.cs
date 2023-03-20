namespace MAUIsland;
public partial class DrawingViewPage : IControlPage
{
    #region [CTor]
    public DrawingViewPage(DrawingViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}