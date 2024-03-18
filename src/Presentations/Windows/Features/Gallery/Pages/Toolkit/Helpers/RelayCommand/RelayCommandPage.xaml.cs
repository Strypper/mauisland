namespace MAUIsland;

public partial class RelayCommandPage : IGalleryPage
{
    #region [CTor]
    public RelayCommandPage(RelayCommandPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}