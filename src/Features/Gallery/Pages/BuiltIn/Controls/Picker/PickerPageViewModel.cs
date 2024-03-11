namespace MAUIsland;


public partial class PickerPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public PickerPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IGalleryCardInfo controlInformation;
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);


    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string memberPickerXamlCode =
        "<VerticalStackLayout Spacing=\"10\">\r\n" +
        "    <Label Style=\"{x:StaticResource DocumentSectionTitleStyle}\" Text=\"A simple Picker for selecting MAUIsland members\" />\r\n" +
        "    <Picker\r\n" +
        "        x:Name=\"picker\"\r\n" +
        "        Title=\"Select a MAUIsland members\"\r\n" +
        "        ItemsSource=\"{x:StaticResource MAUIMembers}\"\r\n" +
        "        SelectedIndex=\"3\" />\r\n" +
        "    <Button BackgroundColor=\"Black\"\r\n" +
        "        HorizontalOptions=\"Start\"\r\n" +
        "        Text=\"{x:Binding Source={x:Reference picker},\r\n" +
        "                     Path=SelectedItem}\"\r\n" +
        "        TextColor=\"{x:StaticResource White}\" />\r\n" +
        "    <app:SourceCodeExpander Code=\"{x:Binding MemberPickerXamlCode}\" />\r\n" +
        "</VerticalStackLayout>";
    #endregion
}
