namespace MAUIsland;

public partial class IndicatorViewPage
{
    #region [CTor]
    public IndicatorViewPage(IndicatorViewPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    #endregion

}