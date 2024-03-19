namespace MAUIsland;
public partial class MaterialContextMenuPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public MaterialContextMenuPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string contextMenuXamlCode = "<mdc:ContextMenu>\r\n\t<mdc:ContextMenu.Items>\r\n\t\t<mdc:ContextMenuFlyoutItem Text=\"Item 1\" />\r\n\t\t<mdc:ContextMenuFlyoutItem Text=\"Item 2\" />\r\n\t\t<mdc:ContextMenuFlyoutItem Text=\"Item 3\" />\r\n\t</mdc:ContextMenu.Items>\r\n</mdc:ContextMenu>\r\n";
    #endregion

    #region [Overrides]
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