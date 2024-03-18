namespace MAUIsland;
public partial class HorizontalStackLayoutPage : IGalleryPage
{
    #region [CTor]
    public HorizontalStackLayoutPage(HorizontalStackLayoutPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}