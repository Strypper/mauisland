using CommunityToolkit.Maui.Core.Extensions;

namespace MAUIsland;

public partial class CardsByGroupPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IControlsService mauiControlsService;


    private Timer? _debounceTimer;
    private const int DebouncePeriodInMilliseconds = 500;
    #endregion

    #region [ CTor ]
    public CardsByGroupPageViewModel(IAppNavigator appNavigator,
                                     IControlsService mauiControlsService)
        : base(appNavigator)
    {
        this.mauiControlsService = mauiControlsService;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string searchText = string.Empty;

    [ObservableProperty]
    int span = 4;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    bool isGalleryDetailVisible;

    [ObservableProperty]
    string selectedItem;

    [ObservableProperty]
    ObservableCollection<IGalleryCardInfo> controlGroupList;

    [ObservableProperty]
    ObservableCollection<IGalleryCardInfo> filteredControlGroupList;

    [ObservableProperty]
    ControlGroupInfo controlGroup;

    #endregion

    #region [ RelayCommand ]

    [RelayCommand]
    Task NavigateToDetailAsync(IGalleryCardInfo control)
        => AppNavigator.NavigateAsync(control.ControlRoute, args: control);

    [RelayCommand]
    Task NavigateToDetailInNewWindowAsync(IGalleryCardInfo control)
        => AppNavigator.NavigateAsync(control.ControlRoute, inNewWindow: true, args: control);

    [RelayCommand]
    async Task OpenUrlAsync(string url)
    {
        IsBusy = true;
        await AppNavigator.OpenUrlAsync(url);
        IsBusy = false;
    }
    #endregion

    #region [ Overrides ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlGroup = query.GetData<ControlGroupInfo>();
    }

    public override async Task OnAppearingAsync()
    {
        CommunityToolkit.Diagnostics.Guard.IsNotNull(ControlGroup);
        await LoadDataAsync(true);
        await RefreshAsync();
    }
    #endregion

    #region [ Data ]
    private async Task LoadDataAsync(bool forced)
    {
        if (IsBusy) return;
        IsBusy = true;

        var items = await mauiControlsService.GetControlsAsync(ControlGroup.Name);

        IsBusy = false;

        if (ControlGroupList is null)
        {
            ControlGroupList = new ObservableCollection<IGalleryCardInfo>(items);
            FilteredControlGroupList = new ObservableCollection<IGalleryCardInfo>(items);
            SelectedItem = "All";
            return;
        }

        if (forced)
        {
            ControlGroupList.Clear();
        }
    }
    #endregion

    #region [ Methods ]

    partial void OnSelectedItemChanged(string value)
        => FilterControls(value, SearchText);

    partial void OnSearchTextChanged(string value)
    {
        _debounceTimer?.Dispose(); // Cancel any existing timer
        _debounceTimer = new Timer(_ =>
        {
            // This code runs after the debounce period elapses
            // Ensure you're on the UI thread if necessary, especially if modifying UI elements directly
            Device.BeginInvokeOnMainThread(() =>
            {
                FilterControls(SelectedItem, value);
            });
        }, null, DebouncePeriodInMilliseconds, Timeout.Infinite); // Timeout.Infinite ensures the timer runs only once
    }
    void FilterControls(string pickerValue, string searchValue)
    {
        IsBusy = true;
        var trimmedValue = pickerValue.TrimEnd('s');

        if (trimmedValue == "All")
        {
            FilteredControlGroupList = ControlGroupList
                                            .Where(x => x.ControlName.Contains(searchValue))
                                            .ToObservableCollection();
            IsBusy = false;
        }
        else
        {
            var controlItems = ControlGroupList.Where(x => x.CardType.ToString() == trimmedValue
                                                        && x.ControlName.Contains(searchValue))
                                                        .ToObservableCollection();
            if (controlItems.Count() == 0)
            {
                FilteredControlGroupList = new ObservableCollection<IGalleryCardInfo>();
            }
            else
            {
                FilteredControlGroupList = controlItems;
            }
            IsBusy = false;
        }
    }

    async Task RefreshAsync()
    {

    }
    async Task OnControlCardNavigation(IGalleryCardInfo control)
    {
        try
        {
            var source = control.ControlIcon;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    #endregion
}
