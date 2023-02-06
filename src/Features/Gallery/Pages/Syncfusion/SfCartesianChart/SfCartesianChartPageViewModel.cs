namespace MAUIsland;
public partial class SfCartesianChartPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public SfCartesianChartPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    ObservableCollection<SfCartesianChartPersonModel> persons;

    [ObservableProperty]
    ControlGroupInfo controlGroup;

    [ObservableProperty]
    bool isBusy;
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlGroup = query.GetData<ControlGroupInfo>();

        LoadDataAsync(true)
            .FireAndForget();
    }
    #endregion

    #region [Methods]
    private async Task LoadDataAsync(bool forced)
    {
        if (IsBusy) return;
        IsBusy = true;

        var persons = new ObservableCollection<SfCartesianChartPersonModel>();
        persons.Add(new SfCartesianChartPersonModel() { Name = "Strypper", Exp = 100 });
        persons.Add(new SfCartesianChartPersonModel() { Name = "Tan", Exp = 50 });
        persons.Add(new SfCartesianChartPersonModel() { Name = "Hung", Exp = 40 });
        persons.Add(new SfCartesianChartPersonModel() { Name = "Long", Exp = 20 });

        IsBusy = false;

        if (Persons == null)
        {
            Persons = new(persons);
            return;
        }

        if (forced)
        {
            Persons.Clear();
        }

        foreach (var item in persons)
        {
            Persons.Add(item);
        }
    }
    #endregion
}