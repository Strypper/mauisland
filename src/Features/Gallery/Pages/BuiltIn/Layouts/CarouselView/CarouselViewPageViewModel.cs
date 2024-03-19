

namespace MAUIsland;

public partial class CarouselViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public CarouselViewPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {
        
    }
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    CarouselItem currentSelectedItem;

    [ObservableProperty]
    ObservableCollection<CarouselItem> items;

    [ObservableProperty]
    ObservableCollection<CarouselItem> itemEmptyList;
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

        LoadDataAsync(true).FireAndForget();
    }
    #endregion

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    void SwipeViewFavorite(CarouselItem carouselItem)
    {
        carouselItem.IsFavorite = !carouselItem.IsFavorite;
    }

    [RelayCommand]
    void SwipeViewDelete(CarouselItem carouselItem)
    {
        if (Items.Contains(carouselItem))
            Items.Remove(carouselItem);
    }

    [RelayCommand]
    void Refresh()
    {
        IsRefreshing = true;

        LoadDataAsync(true).FireAndForget();

        IsRefreshing = false;
    }
    #endregion

    #region [ Methods ]
    private async Task LoadDataAsync(bool forced)
    {
        var items = new List<CarouselItem>()
        {
            new()
            {
                Id = "1",
                Title = "CarouselView Item",
                Content = "Number 1"
                
            },

            new()
            {
                Id = "2",
                Title = "CarouselView Item",
                Content = "Number 2"

            },

            new()
            {
                Id = "3",
                Title = "CarouselView Item",
                Content = "Number 3"

            },

            new()
            {
                Id = "4",
                Title = "CarouselView Item",
                Content = "Number 4"

            },

            new()
            {
                Id = "5",
                Title = "CarouselView Item",
                Content = "Number 5"

            }
        };

        if (forced || Items is null || ItemEmptyList is null)
        {
            Items = new();
            ItemEmptyList = new();
        }

        foreach (var item in items)
        {
            Items.Add(item);
        }

        CurrentSelectedItem = Items.First();
    }
    #endregion
}
