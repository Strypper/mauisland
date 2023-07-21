namespace MAUIsland;

public partial class CarouselViewPage : IGalleryPage
{
    #region [CTor]
    public CarouselViewPage(CarouselViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}