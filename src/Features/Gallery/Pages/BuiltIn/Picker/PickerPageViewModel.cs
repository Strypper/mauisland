namespace MAUIsland;


public partial class PickerPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public PickerPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;
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

    #region [Properties]

    [ObservableProperty]
    string memberPickerXamlCode = "<Picker x:Name=\"picker\"\r\n                    Title=\"Select a MAUIsland members\" \r\n                    ItemsSource=\"{x:StaticResource MAUIMembers}\" />\r\n                    <Button \r\n                        HorizontalOptions=\"Start\"\r\n                        BackgroundColor=\"Black\"\r\n                        Text=\"{x:Binding Source={x:Reference picker}, Path=SelectedItem}\"\r\n                        TextColor=\"{x:StaticResource White}\" />";
    #endregion
}
