namespace MAUIsland.Core;
public partial class MaterialRadioButtonPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public MaterialRadioButtonPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    List<MaterialComponentProperty> properties = default!;

    [ObservableProperty]
    List<MaterialComponentProperty> radioItemProperties = default!;

    [ObservableProperty]
    List<MaterialComponentEvent> events = default!;

    [ObservableProperty]
    List<MaterialComponentEvent> radioItemEvents = default!;

    [ObservableProperty]
    IGalleryCardInfo controlInformation = default!;

    [ObservableProperty]
    string radioButtonXamlCode = "<mdc:RadioButton Orientation=\"Horizontal\">\r\n                        <mdc:RadioItem Text=\"item 1\" />\r\n                        <mdc:RadioItem Text=\"item 2\" />\r\n                        <mdc:RadioItem Text=\"item 3\" />\r\n                    </mdc:RadioButton>\r\n                    <mdc:RadioButton Orientation=\"Vertical\">\r\n                        <mdc:RadioItem Text=\"item 1\" />\r\n                        <mdc:RadioItem Text=\"item 2\" />\r\n                        <mdc:RadioItem Text=\"item 3\" />\r\n                    </mdc:RadioButton>";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

        Properties = new List<MaterialComponentProperty>()
        {
            new(){ Name = "Items", DataType = "ObservableCollection<RadioItem>", DefaultValue = string.Empty },
            new(){ Name = "SelectedIndex", DataType = "int", DefaultValue = "-1" },
            new(){ Name = "SelectItem", DataType = "RadioItem", DefaultValue = string.Empty },
            new(){ Name = "Orientation", DataType = "StackOrientation", DefaultValue = "Horizontal" },
            new(){ Name = "Spacing", DataType = "double", DefaultValue = "0" },
            new(){ Name = "HorizontalSpacing", DataType = "double", DefaultValue = "0" },
            new(){ Name = "VerticalSpacing", DataType = "double", DefaultValue = "0" },
            new(){ Name = "Command", DataType = "ICommand", DefaultValue = string.Empty },
            new(){ Name = "CommandParameter", DataType = "object", DefaultValue = string.Empty },
        };

        Events = new List<MaterialComponentEvent>()
        {
            new() { Name = "SelectedIndexChanged", DataType= "EventHandler<SelectedItemChangedEventArgs>"}
        };

        RadioItemProperties = new List<MaterialComponentProperty>()
        {
            new(){ Name = "ActivedColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "IsSelected", DataType = "bool", DefaultValue = "false" },
            new(){ Name = "Text", DataType = "string", DefaultValue = string.Empty },
            new(){ Name = "FontColor", DataType = "Color", DefaultValue = "OnSurfaceVariantColor" },
            new(){ Name = "FontSize", DataType = "float", DefaultValue = "16" },
            new(){ Name = "FontFamily", DataType = "string", DefaultValue = string.Empty },
            new(){ Name = "FontWeight", DataType = "FontWeight", DefaultValue = "Medium" },
            new(){ Name = "FontIsItalic", DataType = "bool", DefaultValue = "false" },
            new(){ Name = "StateLayerColor", DataType = "Color", DefaultValue = "PrimaryColor" },
        };

        RadioItemEvents = new List<MaterialComponentEvent>()
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