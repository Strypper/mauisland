namespace MAUIsland;
public partial class LiveCharts2Page : IGalleryPage
{
    #region [CTor]
    public LiveCharts2Page(LiveCharts2PageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}