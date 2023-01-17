namespace MAUIsland;

public partial class SwitchPage : IControlPage
{
    #region [CTor]
    public SwitchPage(SwitchPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    #endregion
}