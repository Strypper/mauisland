namespace MAUIsland;

public partial class TableViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public TableViewPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string standardTableViewXamlCode = "<TableView Intent=\"Menu\">\r\n    <TableRoot>\r\n        <TableSection Title=\"Chapters\">\r\n            <TextCell Text=\"1. Introduction to .NET MAUI\"\r\n                      Detail=\"Learn about .NET MAUI and what it provides.\" />\r\n            <TextCell Text=\"2. Anatomy of an app\"\r\n                      Detail=\"Learn about the visual elements in .NET MAUI\" />\r\n            <TextCell Text=\"3. Text\"\r\n                      Detail=\"Learn about the .NET MAUI controls that display text.\" />\r\n            <TextCell Text=\"4. Dealing with sizes\"\r\n                      Detail=\"Learn how to size .NET MAUI controls on screen.\" />\r\n            <TextCell Text=\"5. XAML vs code\"\r\n                      Detail=\"Learn more about creating your UI in XAML.\" />\r\n        </TableSection>\r\n    </TableRoot>\r\n</TableView>";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}
