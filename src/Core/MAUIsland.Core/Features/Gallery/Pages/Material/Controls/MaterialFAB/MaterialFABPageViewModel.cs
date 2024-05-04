namespace MAUIsland.Core;
public partial class MaterialFABPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public MaterialFABPageViewModel(
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
    string fabXamlCode = "<mdc:FAB IconKind=\"Add\" Style=\"{DynamicResource SecondaryFABStyle}\" />\r\n                        <mdc:FAB IconKind=\"Add\" Style=\"{DynamicResource SurfaceFABStyle}\" />\r\n                        <mdc:FAB IconKind=\"Add\" Style=\"{DynamicResource TertiaryFABStyle}\" />\r\n                        <mdc:FAB\r\n                            IconKind=\"Add\"\r\n                            IsExtended=\"True\"\r\n                            Style=\"{DynamicResource SecondaryFABStyle}\"\r\n                            Text=\"Extended\" />\r\n                        <mdc:FAB IconKind=\"Add\" Style=\"{DynamicResource LargeSecondaryFABStyle}\" />";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();
        Properties = new List<MaterialComponentProperty>()
        {
            new(){ Name = "IconData", DataType = "string", DefaultValue = string.Empty },
            new(){ Name = "BackgroundColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "Shape", DataType = "Shape", DefaultValue = "Large" },
            new(){ Name = "Elevation", DataType = "Elevation", DefaultValue = "Level3" },
            new(){ Name = "StateLayerColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "RippleDuration", DataType = "float", DefaultValue = "0.5" },
            new(){ Name = "RippleEasing", DataType = "Easing", DefaultValue = "SinInOut" },
            new(){ Name = "ContextMenu", DataType = "ContextMenu", DefaultValue = string.Empty },
            new(){ Name = "Style", DataType = "Style", DefaultValue = "Surface" },
            new(){ Name = "Command", DataType = "ICommand", DefaultValue = string.Empty },
            new(){ Name = "CommandParameter", DataType = "object", DefaultValue = string.Empty },
        };


        Events = new List<MaterialComponentEvent>()
        {
            new() { Name = "Clicked", DataType = "EventHandler<TouchEventArgs>" },
            new() { Name = "Pressed", DataType = "EventHandler<TouchEventArgs>" },
            new() { Name = "Released", DataType = "EventHandler<TouchEventArgs>" },
            new() { Name = "LongPressed", DataType = "EventHandler<TouchEventArgs>" },
            new() { Name = "RightClicked (Desktop only)", DataType= "EventHandler<TouchEventArgs>"}
        };

    }
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);
    #endregion
}