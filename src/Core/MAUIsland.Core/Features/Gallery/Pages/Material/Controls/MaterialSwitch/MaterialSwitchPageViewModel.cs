namespace MAUIsland.Core;
public partial class MaterialSwitchPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public MaterialSwitchPageViewModel(
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
    string switchXamlCode = "<mdc:Switch />\r\n<mdc:Switch HasIcon=\"False\" />\r\n<mdc:Switch IsChecked=\"True\" />\r\n";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

        Properties = new List<MaterialComponentProperty>()
        {
            new(){ Name = "IsSelected", DataType = "bool", DefaultValue = "false" },
            new(){ Name = "ThumbColor", DataType = "Color", DefaultValue = "OutlineColor" },
            new(){ Name = "IconData", DataType = "string", DefaultValue = string.Empty },
            new(){ Name = "IconColor", DataType = "Color", DefaultValue = "SurfaceContainerHighestColor" },
            new(){ Name = "BackgroundColor", DataType = "Color", DefaultValue = "SurfaceContainerHighestColor" },
            new(){ Name = "Shape", DataType = "Shape", DefaultValue = "full" },
            new(){ Name = "OutlineColor", DataType = "Color", DefaultValue = "OutlineColor" },
            new(){ Name = "StateLayerColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "Command", DataType = "ICommand", DefaultValue = string.Empty },
            new(){ Name = "CommandParameter", DataType = "object", DefaultValue = string.Empty },
        };

        Events = new List<MaterialComponentEvent>()
        {
            new() { Name = "SelectedChanged", DataType = "EventHandler<CheckedChangedEventArgs>" },
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