namespace MAUIsland;
public partial class ObservablePropertyPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public ObservablePropertyPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string observablePropertyFirstCSharpCode = "[ObservableProperty]\r\nprivate string? name;";

    [ObservableProperty]
    string observablePropertySecondCSharpCode = "public string? Name\r\n{\r\n    get => name;\r\n    set => SetProperty(ref name, value);\r\n}";
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
