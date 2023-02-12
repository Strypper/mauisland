namespace MAUIsland;

public partial class EntryPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public EntryPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string standardEntryXamlCode = "<Entry x:Name=\"Entry\"\r\n                               Placeholder=\"Enter text here\"\r\n                               PlaceholderColor=\"LightSlateGray\"\r\n                               HorizontalTextAlignment=\"Start\"\r\n                               VerticalTextAlignment=\"Center\"/> ";

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
