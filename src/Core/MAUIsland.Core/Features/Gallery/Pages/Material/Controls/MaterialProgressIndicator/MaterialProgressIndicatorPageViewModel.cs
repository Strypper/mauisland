namespace MAUIsland.Core;
public partial class MaterialProgressIndicatorPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public MaterialProgressIndicatorPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IGalleryCardInfo controlInformation = default!;

    [ObservableProperty]
    string progressIndicatorXamlCode = "<mdc:ProgressIndicator Style=\"{DynamicResource CircularProgressIndicatorStyle}\" />\r\n <mdc:ProgressIndicator Style=\"{DynamicResource LinearProgressIndicatorStyle}\" />";
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