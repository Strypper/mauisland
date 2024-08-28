using CommunityToolkit.Mvvm.Messaging;

#if WINDOWS
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
#endif


namespace MAUIsland.Mockup;

public partial class MockupPageViewModel(IAppNavigator appNavigator,
        Core.IFilePicker filePicker,
        IDialogService dialogService) : NavigationAwareBaseViewModel(appNavigator)
{
    #region [ Fields ]

    private readonly Core.IFilePicker filePicker = filePicker;
    private readonly IDialogService dialogService = dialogService;
    #endregion

    #region [ Overrides ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        WeakReferenceMessenger.Default.Unregister<DropImageMessage>(this);
        WeakReferenceMessenger.Default.Register<DropImageMessage>(this, async (r, m) =>
        {
            await DropImage(m.Value.Sender, m.Value.Args, m.Value.CollectionViewId);
        });

        WeakReferenceMessenger.Default.Unregister<DeleteScreenShotMessage>(this);
        WeakReferenceMessenger.Default.Register<DeleteScreenShotMessage>(this, async (r, m) =>
        {
            await RemoveScreenShot(m.Value);
        });

        RefreshAsync().FireAndForget();
    }

    protected override void OnActivated()
    {
        base.OnActivated();
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    ObservableCollection<DeviceItemModel> deviceList;

    [ObservableProperty]
    ObservableCollection<ScreenshotModel> screenshots;

    [ObservableProperty]
    ScreenshotModel selectedScreenshot;

    #endregion

    #region [ Properties - Selected Tabs ]

    [ObservableProperty]
    List<string> pageTabs;

    [ObservableProperty]
    bool canPageTabsChangeState;

    [ObservableProperty]
    string selectedTab;

    #endregion

    #region [ Properties - Mockup Keys ]

    [ObservableProperty]
    List<string> devicesList;

    [ObservableProperty]
    bool canMockupFrameChangeState;

    [ObservableProperty]
    string selectedDevice;

    [ObservableProperty]
    string iphone13Mini = "iPhone 13 Mini";

    [ObservableProperty]
    string appleIphone15ProMax = "Apple iPhone 15 Pro Max";

    [ObservableProperty]
    string samsungGalaxyS22Ultra = "Samsung Galaxy S22 Ultra";

    [ObservableProperty]
    string googlePixel6Pro = "Google Pixel 6 Pro";

    [ObservableProperty]
    string googlePixel5 = "Google Pixel 5";
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    async Task OpenFileAsync()
    {

    }

    [RelayCommand]
    async Task AddDeviceAsync()
        => AddDevice();

    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    Task RemoveMockups()
    {
        var freshMockup = Screenshots.Where(x => x.IsAddButton);
        Screenshots = new(freshMockup);

        return Task.CompletedTask;
    }

    #endregion

    #region [ Methods ]

    async Task RefreshAsync()
    {
        string mockupItemGuid = Guid.NewGuid().ToString();

        Screenshots = new()
        {
            new()
            {
                CollectionViewId = mockupItemGuid,
                IsAddButton = true,
            }
        };

        DeviceList = new()
        {
            new()
            {
                Id = mockupItemGuid,
                DeviceModel = Iphone13Mini,
                Screenshots = Screenshots
            }
        };

        DevicesList = new()
        {
            Iphone13Mini,
            AppleIphone15ProMax,
            SamsungGalaxyS22Ultra,
            GooglePixel6Pro,
            GooglePixel5
        };
        CanMockupFrameChangeState = true;
        SelectedDevice = DevicesList.FirstOrDefault();

        PageTabs = new()
        {
            "Devices",
            "Showcase information"
        };
        CanPageTabsChangeState = true;
        SelectedTab = PageTabs.FirstOrDefault();

    }

    partial void OnSelectedDeviceChanged(string value)
    {

    }

    async Task DropImage(Object sender, DropEventArgs e, string collectionViewId)
    {
#if WINDOWS
        var args = e.PlatformArgs!.DragEventArgs;

        var dv = e.PlatformArgs!.DragEventArgs.DataView;
        if (!dv.Contains(StandardDataFormats.StorageItems))
            return;

        var items = await dv.GetStorageItemsAsync();
        List<FileResult> filePaths = [];
        items.OfType<StorageFile>().ToList().ForEach(f => filePaths.Add(new(f.Path)));

        if (filePaths.Count > 0)
        {
            var mockupItem = DeviceList.FirstOrDefault(x => x.Id == collectionViewId);
            if (mockupItem is null)
                return;

            mockupItem.Screenshots.Add(new()
            {
                Id = new Guid().ToString(),
                ImageSource = filePaths.First().FullPath,
                IsAddButton = false,
                CollectionViewId = mockupItem.Id
            });
            SelectedScreenshot = Screenshots.LastOrDefault();
            e.Handled = true;
        }
        else
            return;
#endif
    }

    async Task AddDevice()
    {
        string newMockupCollectionViewId = Guid.NewGuid().ToString();
        DeviceList.Add(new()
        {
            Id = newMockupCollectionViewId,
            DeviceModel = Iphone13Mini,
            Screenshots = new()
            {
                new()
                {
                    CollectionViewId = newMockupCollectionViewId,
                    IsAddButton = true
                }
            }
        });
    }

    async Task RemoveScreenShot(ScreenshotModel screenshot)
    {
        string dialogTitle = "Do you want to remove this screenshot ?";
        string dialogMessage = "This screenshot will be removed";
        var wantToScreenShot = await this.dialogService.ShowConfirmationAsync(dialogTitle, dialogMessage);
        if (!wantToScreenShot)
            return;

        if (screenshot.CollectionViewId is null)
            return;

        var mockupItem = DeviceList.FirstOrDefault(x => x.Id == screenshot.CollectionViewId);
        if (mockupItem is null)
            return;


        mockupItem.Screenshots.Remove(screenshot);
    }


    #endregion
}