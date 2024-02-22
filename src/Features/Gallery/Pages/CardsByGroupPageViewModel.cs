using CommunityToolkit.Maui.Core.Extensions;
using Microsoft.Maui.Controls;
using SkiaSharp;
using System.Dynamic;

namespace MAUIsland;

public partial class CardsByGroupPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]
    private readonly IControlsService mauiControlsService;
    private readonly ICardInfoSyncService cardInfoSyncService;
    private readonly ILocalControlService localControlService;
    #endregion

    #region [ CTor ]
    public CardsByGroupPageViewModel( IAppNavigator appNavigator,
                                      IControlsService mauiControlsService,
                                      ICardInfoSyncService cardInfoSyncService,
                                      ILocalControlService localControlService) 
        : base(appNavigator)
    {
        this.mauiControlsService = mauiControlsService;
        this.localControlService = localControlService;
        this.cardInfoSyncService = cardInfoSyncService;
    }
    #endregion

    #region [ Properties ]
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

        CommunityToolkit.Diagnostics.Guard.IsNotNull(ControlGroup);

        LoadDataAsync(true).FireAndForget();

        RefreshAsync().GetAwaiter();
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
    {
        var trimmedValue = value.TrimEnd('s');

        if (trimmedValue == "All")
        {
            FilteredControlGroupList = ControlGroupList;
        }
        else
        {
            var controlItems = ControlGroupList.Where(x => x.CardType.ToString() == trimmedValue).ToObservableCollection();
            if (controlItems.Count() == 0)
            {
                FilteredControlGroupList = new ObservableCollection<IGalleryCardInfo>();
            }
            else
            {
                FilteredControlGroupList = controlItems;
            }
        }
    }

    async Task RefreshAsync()
    {
        var controls = await localControlService.GetAllAsync();
        var hello = controls.Select(x => x.ControlName).ToList();
    }
    async Task OnControlCardNavigation(IGalleryCardInfo control)
    {
        try 
        {
            var source = control.ControlIcon;

            var hello = new CardInfoLocalDbModel
            {
                ControlIcon = Convert.ToInt32(control.ControlIcon).ToString(),
                ControlName = control.GroupName,
                ControlDetail = control.ControlDetail,
                ControlRoute = control.ControlRoute,
                GitHubUrl = control.GitHubUrl,
                DocumentUrl = control.DocumentUrl,
                GroupName = control.GroupName,
                CardType = Convert.ToInt32(control.CardType),
                CardStatus = Convert.ToInt32(control.CardStatus),
                LastUpdate = DateTime.Now
            };
            await localControlService.AddAsync(hello);
        }
        catch(Exception ex) 
        {
            throw ex;
        }
        
    }
    #endregion
}
