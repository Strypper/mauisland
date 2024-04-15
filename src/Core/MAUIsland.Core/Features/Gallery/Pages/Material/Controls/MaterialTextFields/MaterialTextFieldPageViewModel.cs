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
    List<MaterialComponentProperty> properties = default!;

    [ObservableProperty]
    List<MaterialComponentEvent> events = default!;

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

        Properties = new List<MaterialComponentProperty>()
        {
            new(){ Name = "InputType", DataType = "InputType", DefaultValue = "None" },
            new(){ Name = "Text", DataType = "string", DefaultValue = string.Empty },
            new(){ Name = "FontColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "FontSize", DataType = "float", DefaultValue = "16" },
            new(){ Name = "FontFamily", DataType = "string", DefaultValue = string.Empty },
            new(){ Name = "FontWeight", DataType = "FontWeight", DefaultValue = "Regular" },
            new(){ Name = "FontIsItalic", DataType = "bool", DefaultValue = "false" },
            new(){ Name = "CaretColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "SelectionRange", DataType = "TextRange", DefaultValue = "0" },
            new(){ Name = "TextAlignment", DataType = "TextAlignment", DefaultValue = "Start" },
            new(){ Name = "IconData", DataType = "string", DefaultValue = string.Empty },
            new(){ Name = "IconColor", DataType = "Color", DefaultValue = "OnSurfaceVariantColor" },
            new(){ Name = "TrailingIconData", DataType = "string", DefaultValue = string.Empty },
            new(){ Name = "TrailingIconColor", DataType = "Color", DefaultValue = "OnSurfaceVariantColor" },
            new(){ Name = "ActiveIndicatorHeight", DataType = "int", DefaultValue = string.Empty },
            new(){ Name = "ActiveIndicatorColor", DataType = "Color", DefaultValue = "OnSurfaceVariantColor" },
            new(){ Name = "LabelText", DataType = "string", DefaultValue = string.Empty },
            new(){ Name = "LabelFontColor", DataType = "Color", DefaultValue = "OnSurfaceVariantColor" },
            new(){ Name = "SupportingText", DataType = "string", DefaultValue = string.Empty },
            new(){ Name = "SupportingFontColor", DataType = "Color", DefaultValue = "OnSurfaceVariantColor" },
            new(){ Name = "BackgroundColor", DataType = "Color", DefaultValue = "SurfaceContainerHighestColor" },
            new(){ Name = "Shape", DataType = "Shape", DefaultValue = "ExtraSmallTop" },
            new(){ Name = "StateLayerColor", DataType = "Color", DefaultValue = "OnSurfaceVariantColor" },
        };


        Events = new List<MaterialComponentEvent>()
        {
            new() { Name = "TextChanged", DataType = "EventHandler<TextChangedEventArgs>" },
            new() { Name = "TrailingIconClicked", DataType = "EventHandler<EventArgs>" },
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