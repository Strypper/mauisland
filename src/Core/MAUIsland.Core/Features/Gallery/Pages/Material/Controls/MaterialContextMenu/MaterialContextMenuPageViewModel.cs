namespace MAUIsland.Core;
public partial class MaterialContextMenuPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public MaterialContextMenuPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    List<MaterialComponentProperty> properties = default!;

    [ObservableProperty]
    List<MaterialComponentEvent> events = default!;

    [ObservableProperty]
    IGalleryCardInfo controlInformation = default!;

    [ObservableProperty]
    string contextMenuXamlCode = "<mdc:ContextMenu>\r\n\t<mdc:ContextMenu.Items>\r\n\t\t<mdc:ContextMenuFlyoutItem Text=\"Item 1\" />\r\n\t\t<mdc:ContextMenuFlyoutItem Text=\"Item 2\" />\r\n\t\t<mdc:ContextMenuFlyoutItem Text=\"Item 3\" />\r\n\t</mdc:ContextMenu.Items>\r\n</mdc:ContextMenu>\r\n";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

        Properties = new List<MaterialComponentProperty>()
        {
            new(){ Name = "Items", DataType = "ObservableCollection<MenuItem>", DefaultValue = string.Empty },
            new(){ Name = "ItemsSource", DataType = "IList", DefaultValue = string.Empty },
            new(){ Name = "Result", DataType = "object", DefaultValue = string.Empty },
            new(){ Name = "BackgroundColor", DataType = "Color", DefaultValue = "SurfaceContainerColor" },
            new(){ Name = "Shape", DataType = "Shape", DefaultValue = "4" },
            new(){ Name = "Elevation", DataType = "Elevation", DefaultValue = "Level2" },
        };

        Events = new List<MaterialComponentEvent>()
        {
            new() { Name = "Closed", DataType= "EventHandler<object>"}
        };
    }
    #endregion

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);
    #endregion
}