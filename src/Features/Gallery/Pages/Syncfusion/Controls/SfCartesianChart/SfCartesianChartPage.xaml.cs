namespace MAUIsland;
public partial class SfCartesianChartPage : IGalleryPage
{
    #region [Services]
    private readonly SfCartesianChartPageViewModel viewModel;
    #endregion

    #region [CTor]
    public SfCartesianChartPage(SfCartesianChartPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }
    #endregion
}