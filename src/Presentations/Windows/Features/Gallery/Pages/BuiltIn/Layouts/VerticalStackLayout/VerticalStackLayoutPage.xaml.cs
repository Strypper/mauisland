namespace MAUIsland;
public partial class VerticalStackLayoutPage : IGalleryPage
{
    #region [CTor]
    public VerticalStackLayoutPage(VerticalStackLayoutPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}