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
        };
    }

    protected override void OnActivated()
    {
        base.OnActivated();

    }
    #endregion

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);
    #endregion
}