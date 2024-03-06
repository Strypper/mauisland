namespace MAUIsland;

public partial class DockLayoutPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public DockLayoutPageViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string xamlDockLayout =
        "<toolkit:DockLayout>\r\n" +
        "    <Button toolkit:DockLayout.DockPosition=\"Top\" Text=\"Top\" HeightRequest=\"50\" />\r\n" +
        "    <Button toolkit:DockLayout.DockPosition=\"Bottom\" Text=\"Bottom\" HeightRequest=\"70\" />\r\n" +
        "    <Button toolkit:DockLayout.DockPosition=\"Left\" Text=\"Left\" WidthRequest=\"80\" />\r\n" +
        "    <Button toolkit:DockLayout.DockPosition=\"Right\" Text=\"Right\" WidthRequest=\"90\" />\r\n" +
        "    <Button Text=\"Center\" />\r\n" +
        "</toolkit:DockLayout>";

    [ObservableProperty]
    string csharpDockLayout =
    "using CommunityToolkit.Maui.Layouts;\r\n" +
    "\r\n" +
    "var page = new ContentPage\r\n" +
    "{\r\n" +
    "    Content = new DockLayout\r\n" +
    "    {\r\n" +
    "        { new Button { Text = \"Top\", HeightRequest = 50 }, DockPosition.Top },\r\n" +
    "        { new Button { Text = \"Bottom\", HeightRequest = 70 }, DockPosition.Bottom },\r\n" +
    "        { new Button { Text = \"Left\", WidthRequest = 80 }, DockPosition.Left },\r\n" +
    "        { new Button { Text = \"Right\", WidthRequest = 90 }, DockPosition.Right },\r\n" +
    "        { new Button { Text = \"Center\" } },\r\n" +
    "    }\r\n" +
    "};";

    [ObservableProperty]
    string settingDockLayoutPosition =
    "var button = new Button { Text = \"Top\", HeightRequest = 50 };\r\n" +
    "DockLayout.SetDockPosition(button, DockPosition.Top);";

    [ObservableProperty]
    string xamlCustomizeDockLayout =
    "<ContentPage xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
    "             xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
    "             xmlns:toolkit=\"http://schemas.microsoft.com/dotnet/2022/maui/toolkit\"\r\n" +
    "             x:Class=\"MyProject.MyContentPage\">\r\n" +
    "\r\n" +
    "    <toolkit:DockLayout HeightRequest=\"400\"\r\n" +
    "                    WidthRequest=\"600\"\r\n" +
    "                    Padding=\"10,20,30,40\"\r\n" +
    "                    VerticalSpacing=\"10\"\r\n" +
    "                    HorizontalSpacing=\"15\"\r\n" +
    "                    ShouldExpandLastChild=\"False\">\r\n" +
    "        ...\r\n" +
    "    </toolkit:DockLayout>\r\n" +
    "    \r\n" +
    "</ContentPage>";

    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
        ControlInformation = query.GetData<IGalleryCardInfo>();
    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}
