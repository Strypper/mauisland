namespace MAUIsland;

public partial class SearchBarPage : IControlPage
{
    #region [CTor]
    public SearchBarPage(SearchBarPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}