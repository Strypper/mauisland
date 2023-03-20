namespace MAUIsland;
public partial class SfCircularChartPage : IControlPage
{
    #region [CTor]
    public SfCircularChartPage(SfCircularChartPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}