namespace MAUIsland;

public partial class SwitchPage : IGalleryPage
{
    #region [CTor]
    public SwitchPage(SwitchPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    #endregion
}