namespace MAUIsland;
public partial class MaterialButtonPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public MaterialButtonPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    List<MaterialComponentProperty> properties;

    [ObservableProperty]
    List<MaterialComponentEvent> events;

    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string buttonXamlCode = "<mdc:Button Style=\"{DynamicResource ElevatedButtonStyle}\" Text=\"Elevated\" />\r\n<mdc:Button Style=\"{DynamicResource FilledButtonStyle}\" Text=\"Filled\" />\r\n<mdc:Button Style=\"{DynamicResource FilledTonalButtonStyle}\" Text=\"FilledTonal\" />\r\n<mdc:Button Style=\"{DynamicResource OutlinedButtonStyle}\" Text=\"Outlined\" />\r\n<mdc:Button Style=\"{StaticResource TextButtonStyle}\" Text=\"Text\" />\r\n";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

        Properties = new List<MaterialComponentProperty>()
        {
            new(){ Name = "Text", DataType = "string", DefaultValue = "Empty" },
            new(){ Name = "IconData", DataType = "string", DefaultValue = "Empty" },
            new(){ Name = "BackgroundColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "FontColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "FontSize", DataType = "float", DefaultValue = "14" },
            new(){ Name = "FontFamily", DataType = "string", DefaultValue = string.Empty },
            new(){ Name = "FontWeight", DataType = "FontWeight", DefaultValue = "Regular" },
            new(){ Name = "FontIsItalic", DataType = "bool", DefaultValue = "false" },
            new(){ Name = "Shape", DataType = "Shape", DefaultValue = "style" },
            new(){ Name = "Elevation", DataType = "Elevation", DefaultValue = "14" },
            new(){ Name = "OutlineWidth", DataType = "int", DefaultValue = "style" },
            new(){ Name = "OutlineColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "StateLayerColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "RippleDuration", DataType = "float", DefaultValue = "0.5" },
            new(){ Name = "RippleEasing", DataType = "Easing", DefaultValue = "SinInOut" },
            new(){ Name = "Style", DataType = "Style", DefaultValue = "Filled" },
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