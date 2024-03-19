namespace MAUIsland;

public partial class StateContainerPage : IGalleryPage
{
    #region [CTor]
    public StateContainerPage(StateContainerPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}