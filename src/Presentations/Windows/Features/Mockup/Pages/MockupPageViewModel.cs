namespace MAUIsland.Mockup;

public partial class MockupPageViewModel(IAppNavigator appNavigator,
        Core.IFilePicker filePicker) : NavigationAwareBaseViewModel(appNavigator)
{
    #region [ Fields ]

    private readonly Core.IFilePicker filePicker = filePicker;
    #endregion

    #region [ Overrides ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        RefreshAsync().FireAndForget();
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    ObservableCollection<MockupPreviewItemModel> previewImages;

    [ObservableProperty]
    MockupPreviewItemModel selectedMockUp;

    [ObservableProperty]
    bool canMockupFrameChangeState;

    [ObservableProperty]
    string currentMockupFrameState;

    [ObservableProperty]
    List<string> mockupList;
    #endregion

    #region [ Properties - Mockup Keys ]

    [ObservableProperty]
    string iphone13Mini = "iPhone 13 Mini";

    [ObservableProperty]
    string samsungGalaxyS22Ultra = "Samsung Galaxy S22 Ultra";
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    private async Task OpenFileAsync()
    {

    }

    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);

    #endregion

    #region [ Methods ]

    async Task RefreshAsync()
    {
        PreviewImages = new()
        {
            new()
            {
                IsAddButton = true,
            }
        };

        MockupList = new()
        {
            Iphone13Mini,
            SamsungGalaxyS22Ultra
        };

        CanMockupFrameChangeState = true;

        CurrentMockupFrameState = Iphone13Mini;
    }

    partial void OnCurrentMockupFrameStateChanged(string value)
    {
        System.Diagnostics.Debug.WriteLine(value);
    }
    #endregion
}