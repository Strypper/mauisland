namespace MAUIsland;

public partial class CarouselViewPage : IGalleryPage
{
    #region [ Service ]
    protected readonly CarouselViewPageViewModel ViewModel;
    #endregion

    #region [CTor]
    public CarouselViewPage(CarouselViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = ViewModel = vm;
    }
    #endregion
}