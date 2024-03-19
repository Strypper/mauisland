namespace MAUIsland;
public partial class SfCircularChartPage : IGalleryPage
{
    #region [CTor]
    public SfCircularChartPage(SfCircularChartPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}