namespace MAUIsland;

public partial class SfComboBoxPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public SfComboBoxPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    ObservableCollection<SocialMedia> items;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ControlGroupInfo controlGroupInfo;
    #endregion

    #region [Overrides]

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlGroupInfo = query.GetData<ControlGroupInfo>();

        LoadDataAsync(true)
            .FireAndForget();
    }
    #endregion

    #region [Methods]

    private async Task LoadDataAsync(bool forced)
    {
        if (IsBusy) return;
        IsBusy = true;

        var items = new List<SocialMedia>();
        items.Add(new SocialMedia() { Name = "Facebook", ID = 0 });
        items.Add(new SocialMedia() { Name = "Google Plus", ID = 1 });
        items.Add(new SocialMedia() { Name = "Instagram", ID = 2 });
        items.Add(new SocialMedia() { Name = "LinkedIn", ID = 3 });
        items.Add(new SocialMedia() { Name = "Skype", ID = 4 });
        items.Add(new SocialMedia() { Name = "Telegram", ID = 5 });
        items.Add(new SocialMedia() { Name = "Televzr", ID = 6 });
        items.Add(new SocialMedia() { Name = "Tik Tok", ID = 7 });
        items.Add(new SocialMedia() { Name = "Tout", ID = 8 });
        items.Add(new SocialMedia() { Name = "Tumblr", ID = 9 });
        items.Add(new SocialMedia() { Name = "Twitter", ID = 10 });
        items.Add(new SocialMedia() { Name = "Vimeo", ID = 11 });
        items.Add(new SocialMedia() { Name = "WhatsApp", ID = 12 });
        items.Add(new SocialMedia() { Name = "YouTube", ID = 13 });

        IsBusy = false;

        if (Items == null)
        {
            Items = new(items);
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

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion



}

public class SocialMedia
{
    public string Name { get; set; }
    public int ID { get; set; }
}

