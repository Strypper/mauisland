namespace MAUIsland.Core;
public partial class MaterialTextFieldPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public MaterialTextFieldPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IGalleryCardInfo controlInformation = default!;

    [ObservableProperty]
    string textFieldXamlCode = "<mdc:TextField\r\n IconData=\"{Static icon:Material.Search}\"\r\n Style=\"{DynamicResource FilledTextFieldStyle}\"\r\n WidthRequest=\"250\" />\r\n     <mdc:TextField\r\n   IconData=\"{Static icon:Material.Password}\"\r\n  IsError=\"True\"\r\n  Style=\"{DynamicResource OutlinedTextFieldStyle}\"\r\n  SupportingText=\"Incorrect password\"\r\n                            TrailingIconData=\"Close\"\r\n                            WidthRequest=\"300\" />";
    #endregion

    #region [ Overrides ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);
    #endregion
}