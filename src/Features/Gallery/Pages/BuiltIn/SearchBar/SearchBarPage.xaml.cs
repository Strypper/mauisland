namespace MAUIsland;

public partial class SearchBarPage : IControlPage
{
    #region [ Fields ]
    private readonly SearchBarPageViewModel vm;
    #endregion

    #region [ CTor ]
    public SearchBarPage(SearchBarPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}