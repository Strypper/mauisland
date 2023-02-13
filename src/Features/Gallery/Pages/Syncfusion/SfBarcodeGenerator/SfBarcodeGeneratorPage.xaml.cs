namespace MAUIsland;
public partial class SfBarcodeGeneratorPage : IControlPage
{
    #region [CTor]
    public SfBarcodeGeneratorPage(SfBarcodeGeneratorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}