namespace MAUIsland;

public partial class CarouselViewPage : IGalleryPage
{
    #region [ Fields ]

    protected readonly CarouselViewPageViewModel viewModel;
    #endregion

    #region [ CTor ]

    public CarouselViewPage(CarouselViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }
    #endregion


    #region [ Event Handlers ]

    private void BasePage_Loaded(object sender, EventArgs e)
    {
        if (NewWindowParameter is not null && viewModel.ControlInformation is null)
        {
            viewModel.SetControlInformation(NewWindowParameter);
            viewModel.RefreshCommand.Execute(null);
        }
    }
    private void CarouselViewCurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
    {
        var carouselItem = (CarouselItem)e.CurrentItem;
        var carouselView = (CarouselView)sender;
        ItemChangingEventHandlerLabelSpan.Text = carouselItem.Content;
        PositionItemChangingEventHandlerLabelSpan.Text = carouselView.Position.ToString();
    }
    #endregion
}