namespace MAUIsland;
public partial class PopupPage : IControlPage
{
    #region [CTor]
    public PopupPage(PopupPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}