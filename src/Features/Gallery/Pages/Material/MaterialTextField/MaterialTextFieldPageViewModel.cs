namespace MAUIsland;
public partial class MaterialTextFieldPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public MaterialTextFieldPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string textFieldXamlCode = "<mdc:TextField IconKind=\"Search\" WidthRequest=\"250\" Style=\"{DynamicResource FilledTextFieldStyle}\"/>\r\n<mdc:TextField IconKind=\"Password\" IsError=\"True\" WidthRequest=\"300\" SupportingText=\"Incorrect password\" TextChanged=\"OnTextChanged\" TrailingIconKind=\"Close\" TrailingIconClicked=\"OnTrailingIconClicked\" Style=\"{DynamicResource OutlinedTextFieldStyle}\" />\r\n";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}