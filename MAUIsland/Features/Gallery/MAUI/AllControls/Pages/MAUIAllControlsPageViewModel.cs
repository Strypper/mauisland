namespace MAUIsland;

public partial class MAUIAllControlsPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IMAUIControlsService mauiControlsService;
    #endregion

    #region [CTor]
    public MAUIAllControlsPageViewModel(IAppNavigator appNavigator,
                                        IMAUIControlsService mauiControlsService)
                                            : base(appNavigator)
    {
        this.mauiControlsService = mauiControlsService;
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    int span = 4;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<ControlInfo> items;
    #endregion

    #region [RelayCommand]
    [RelayCommand]
    Task NavigateToDetailAsync(string controlRoute) => AppNavigator.NavigateAsync(controlRoute);

    [RelayCommand]
    Task NavigateToDetailInNewWindowAsync(string controlRoute) 
    {
        var viewName = controlRoute[0].ToString().ToUpper() + controlRoute.Substring(1, controlRoute.Length - 1);

        var pageFullName = $"MAUIsland.{viewName}";
        var pageType = Type.GetType(pageFullName);
        var page = ServiceHelper.GetService<Page>(pageType);

        //var viewModelFullName = $"MAUIsland.{viewName}ViewModel";
        //var viewModelType = Type.GetType(viewModelFullName);
        //var viewModel = ServiceHelper.GetService(viewModelType);

        Window secondWindow = new(page);
        Application.Current.OpenWindow(secondWindow);

        return Task.CompletedTask;
    }
    #endregion

    #region [Methods]
    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();

        LoadDataAsync(true)
            .FireAndForget();
    }


    private async Task LoadDataAsync(bool forced)
    {
        if (IsBusy) return;
        IsBusy = true;


        var items = await mauiControlsService.GetAllControlInfoAsync();

        IsBusy = false;


        if (Items == null)
        {
            Items = new ObservableCollection<ControlInfo>(items);
            return;
        }

        if (forced)
        {
            Items.Clear();
        }

        foreach (var item in items)
        {
            Items.Add(item);
        }
    }
    #endregion
}
