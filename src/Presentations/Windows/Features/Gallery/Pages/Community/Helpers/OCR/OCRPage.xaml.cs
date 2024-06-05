namespace MAUIsland;

public partial class OCRPage : IGalleryPage
{

    #region [ CTor ]

    public OCRPage(OCRPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}