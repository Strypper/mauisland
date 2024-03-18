namespace MAUIsland;
public partial class SfBarcodeGeneratorPage : IGalleryPage
{
    #region [CTor]
    public SfBarcodeGeneratorPage(SfBarcodeGeneratorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}