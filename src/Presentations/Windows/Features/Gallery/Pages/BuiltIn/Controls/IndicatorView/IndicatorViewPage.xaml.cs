namespace MAUIsland;

public partial class IndicatorViewPage : IGalleryPage
{
    #region [ CTor ]
    public IndicatorViewPage(IndicatorViewPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    #endregion

}