namespace MAUIsland;

public partial class CarouselViewPage : IControlPage
{
    #region [CTor]
    public CarouselViewPage(CarouselViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}