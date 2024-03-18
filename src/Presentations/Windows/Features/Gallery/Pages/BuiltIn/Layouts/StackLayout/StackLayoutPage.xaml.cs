namespace MAUIsland;
public partial class StackLayoutPage : IGalleryPage
{
    #region [CTor]
    public StackLayoutPage(StackLayoutPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}