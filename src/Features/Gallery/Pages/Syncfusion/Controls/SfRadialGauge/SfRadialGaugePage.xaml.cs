namespace MAUIsland;
public partial class SfRadialGaugePage : IGalleryPage
{
    #region [CTor]
    public SfRadialGaugePage(SfRadialGaugePageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}