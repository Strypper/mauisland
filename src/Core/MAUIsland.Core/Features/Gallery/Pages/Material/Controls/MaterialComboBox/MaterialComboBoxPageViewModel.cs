namespace MAUIsland.Core;
public partial class MaterialComboBoxPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public MaterialComboBoxPageViewModel(
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
    string comboBoxXamlCode = "<mdc:ComboBox Style=\"{DynamicResource FilledComboBoxStyle}\">\r\n\t<mdc:ComboBoxItem Text=\"item 1\" />\r\n\t<mdc:ComboBoxItem Text=\"item 2\" />\r\n</mdc:ComboBox>\r\n<mdc:ComboBox Style=\"{DynamicResource OutlinedComboBoxStyle}\">\r\n\t<mdc:ComboBoxItem Text=\"item 1\" />\r\n\t<mdc:ComboBoxItem Text=\"item 2\" />\r\n</mdc:ComboBox>\r\n";
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
            new(){ Name = "SelectedIndex", DataType = "int", DefaultValue = "-1" },
            new(){ Name = "SelectedItem", DataType = "MenuItem", DefaultValue = string.Empty },
            new(){ Name = "LabelText", DataType = "string", DefaultValue = "Label text" },
            new(){ Name = "LabelFontColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "ActiveIndicatorHeight", DataType = "int", DefaultValue = "style" },
            new(){ Name = "ActiveIndicatorColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "BackgroundColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "IFontColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "FontFamily", DataType = "string", DefaultValue = string.Empty },
            new(){ Name = "FontSize", DataType = "float", DefaultValue = "14" },
            new(){ Name = "FontWeight", DataType = "Color", DefaultValue = "400" },
            new(){ Name = "FontIsItalic", DataType = "bool", DefaultValue = "false" },
            new(){ Name = "OutlineWidth", DataType = "int", DefaultValue = "style" },
            new(){ Name = "OutlineColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "StateLayerColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "RippleDuration", DataType = "int", DefaultValue = "0.5" },
            new(){ Name = "RippleEasing", DataType = "Easing", DefaultValue = "SinInOut" },
            new(){ Name = "ContextMenu", DataType = "ContextMenu", DefaultValue = string.Empty },
            new(){ Name = "Style", DataType = "Style", DefaultValue = "Filled" },
            new(){ Name = "Command", DataType = "ICommand", DefaultValue = string.Empty },
            new(){ Name = "CommandParameter", DataType = "object", DefaultValue = string.Empty },
        };

        Events = new List<MaterialComponentEvent>()
        {
            new() { Name = "SelectedChanged", DataType = "EventHandler<SelectedItemChangedEventArgs>" },
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