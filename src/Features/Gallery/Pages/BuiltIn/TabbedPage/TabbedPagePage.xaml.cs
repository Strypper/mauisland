namespace MAUIsland;
public partial class TabbedPagePage : IControlPage
{
    #region [CTor]
    public TabbedPagePage(TabbedPagePageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}