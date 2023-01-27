

namespace MAUIsland;

public partial class CarouselViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public CarouselViewPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {
        items = new()
        {
            new()
            {
                Title = "CarouselView Item",
                Content = "Number 1"

            },

            new()
            {
                Title = "CarouselView Item",
                Content = "Number 2"

            },

            new()
            {
                Title = "CarouselView Item",
                Content = "Number 3"

            },

            new()
            {
                Title = "CarouselView Item",
                Content = "Number 4"

            },

            new()
            {
                Title = "CarouselView Item",
                Content = "Number 5"

            }
        };
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    public ObservableCollection<CarouselItem> items;
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}
