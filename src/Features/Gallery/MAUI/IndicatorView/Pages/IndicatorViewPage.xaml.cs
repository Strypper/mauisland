namespace MAUIsland;

public partial class IndicatorViewPage : IControlPage
{
    #region [CTor]
    public IndicatorViewPage(IndicatorViewPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    #endregion

}