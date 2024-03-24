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

    private void CarouselViewCurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
    {
        var carouselItem = (CarouselItem)e.CurrentItem;
        var carouselView = (CarouselView)sender;
        ItemChangingEventHandlerLabelSpan.Text = carouselItem.Content;
        PositionItemChangingEventHandlerLabelSpan.Text = carouselView.Position.ToString();
    }
}