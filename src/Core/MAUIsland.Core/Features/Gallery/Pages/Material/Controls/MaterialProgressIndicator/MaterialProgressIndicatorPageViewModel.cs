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
    List<MaterialComponentProperty> properties = default!;

    [ObservableProperty]
    List<MaterialComponentEvent> events = default!;

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

        Properties = new List<MaterialComponentProperty>()
        {
            new(){ Name = "Percent", DataType = "float", DefaultValue = "-1" },
            new(){ Name = "AnimationDuration", DataType = "float", DefaultValue = "1.5" },
            new(){ Name = "ActiveIndicatorHeight", DataType = "int", DefaultValue = "4" },
            new(){ Name = "ActiveIndicatorColor", DataType = "Color", DefaultValue = "PrimaryColor" },
            new(){ Name = "BackgroundColor", DataType = "Color", DefaultValue = "style" },
            new(){ Name = "Command", DataType = "ICommand", DefaultValue = string.Empty },
            new(){ Name = "CommandParameter", DataType = "object", DefaultValue = string.Empty },
        };

        Events = new List<MaterialComponentEvent>()
        {
            new() { Name = "PercentChanged", DataType= "EventHandler<ValueChangedEventArgs>"}
        };

    }
    #endregion

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);
    #endregion
}