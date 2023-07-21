namespace MAUIsland;


public partial class RefreshViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public RefreshViewPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<DemoItem> items;

    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

        Items = new();
        Items.Add(new DemoItem("Item1", DateTime.Now));
    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    async Task RefreshAsync()
    {
        IsBusy = true;
        Items.Add(new DemoItem("new Item", DateTime.Now));
        await AppNavigator.ShowSnackbarAsync("You triggered refresh", null, "Ok");
        IsBusy = false;
    }
    #endregion
}

public record DemoItem(string name, DateTime time);