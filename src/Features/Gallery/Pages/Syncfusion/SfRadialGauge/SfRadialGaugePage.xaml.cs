namespace MAUIsland;
public partial class SfRadialGaugePage : IControlPage
{
    #region [CTor]
    public SfRadialGaugePage(SfRadialGaugePageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}