using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class EnumToIntConverterPageViewModel : BaseToolkitPageControlViewModel
{
    #region [ CTor ]
    public EnumToIntConverterPageViewModel(IAppNavigator appNavigator,
                                           IGitHubService gitHubService,
                                           IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                            : base(appNavigator,
                                                    gitHubService,
                                                    gitHubIssueLocalDbService)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    ObservableCollection<GalleryCardType> galleryCardTypes = default!;

    [ObservableProperty]
    GalleryCardType selectedItem;

    [ObservableProperty]
    string setupDescription =
    "In order to use the toolkit in XAML the following xmlns needs to be added into your page or view:";

    [ObservableProperty]
    string xamlNamespace =
        "xmlns:toolkit=\"http://schemas.microsoft.com/dotnet/2022/maui/toolkit\"";

    [ObservableProperty]
    string fullNamepaceExampleBefore =
        "<ContentPage\r\n" +
        "    x:Class=\"MAUIsland.MediaElementPage\"\r\n" +
        "    xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "    xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string fullNamepaceExampleAfter =
        "<ContentPage\r\n" +
        "    x:Class=\"MAUIsland.MediaElementPage\"\r\n" +
        "    xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "    xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "    xmlns:toolkit=\"http://schemas.microsoft.com/dotnet/2022/maui/toolkit\">\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlConverterTesting =
        "<Picker ItemsSource=\"{x:Binding GalleryCardTypes}\" \r\n" +
        "        SelectedIndex=\"{Binding SelectedItem, Converter={StaticResource EnumToIntConverter}, ConverterParameter={x:Type app:GalleryCardType}}\"\r\n" +
        "        BackgroundColor=\"LightGray\" />\r\n" +
        "<Label>\r\n" +
        "   <Label.FormattedText>\r\n" +
        "       <FormattedString>\r\n" +
        "           <Span Text=\"This is the index of the item that you have chosen:  \"/>\r\n" +
        "           <Span Text=\"{x:Binding SelectedItem, Converter={StaticResource EnumToIntConverter}}\"/>\r\n" +
        "       </FormattedString>\r\n" +
        "   </Label.FormattedText>\r\n" +
        "</Label>";

    [ObservableProperty]
    string xamlConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "        <toolkit:EnumToIntConverter x:Key=\"EnumToIntConverter\" />\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string cSharpxamlConverterTestingViewModel =
        "[ObservableProperty]\r\n" +
        "ObservableCollection<GalleryCardType> galleryCardTypes;\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "GalleryCardType selectedItem;";
    #endregion

    #region[ Relay Command ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    async Task RefreshAsync()
    {
        if (ControlInformation is null)
            return;
    }
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
        ControlInformation = query.GetData<ICommunityToolkitGalleryCardInfo>();
        LoadDataAsync().FireAndForget();
    }
    #endregion

    #region [ Data ]
    private async Task LoadDataAsync()
    {
        GalleryCardTypes = new ObservableCollection<GalleryCardType>(Enum.GetValues<GalleryCardType>());
    }
    #endregion

    #region [ Method ]
    #endregion
}
