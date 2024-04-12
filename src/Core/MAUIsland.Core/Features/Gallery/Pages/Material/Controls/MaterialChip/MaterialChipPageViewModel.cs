namespace MAUIsland.Core;
public partial class MaterialChipPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public MaterialChipPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IGalleryCardInfo controlInformation = default!;

    [ObservableProperty]
    string chipXamlCode = "<mdc:Chip Text=\"chip\" Style=\"{DynamicResource AssistChipStyle}\" />\r\n<mdc:Chip Text=\"chip\" Style=\"{DynamicResource AssistElevatedChipStyle}\" />\r\n<mdc:Chip Text=\"chip\" Style=\"{DynamicResource FilterChipStyle}\" />\r\n<mdc:Chip Text=\"chip\" Style=\"{DynamicResource FilterElevatedChipStyle}\" />\r\n<mdc:Chip Text=\"chip\" Style=\"{DynamicResource InputChipStyle}\" />\r\n<mdc:Chip Text=\"chip\" Style=\"{DynamicResource SuggestionChipStyle}\" />\r\n<mdc:Chip Text=\"chip\" Style=\"{DynamicResource SuggestionElevatedChipStyle}\" />\r\n";
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