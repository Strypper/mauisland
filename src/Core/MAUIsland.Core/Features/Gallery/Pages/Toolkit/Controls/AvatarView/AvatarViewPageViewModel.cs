using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class AvatarViewPageViewModel : BaseToolkitPageControlViewModel
{
    #region [ CTor ]
    public AvatarViewPageViewModel(IAppNavigator appNavigator,
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
        "    xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\">\"\r\n" +
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
    string xamlAvatarViewText =
        "<toolkit:AvatarView Text=\"ZS\" \r\n" +
        "                    BorderColor=\"Black\"/>";

    [ObservableProperty]
    string xamlAvatarViewTextColor =
        "<toolkit:AvatarView BorderColor=\"Black\" \r\n" +
        "                    Text=\"TC\" \r\n" +
        "                    TextColor=\"Green\"/>\r\n" +
        "<toolkit:AvatarView BorderColor=\"Black\" \r\n" +
        "                    Text=\"TC\" \r\n" +
        "                    TextColor=\"{x:Static core:AppColors.BlackGrey}\"/>\r\n" +
        "<toolkit:AvatarView BorderColor=\"Black\" \r\n" +
        "                    Text=\"TC\" \r\n" +
        "                    TextColor=\"#806e41\"/>";

    [ObservableProperty]
    string xamlAvatarViewBackgroundColor =
        "<toolkit:AvatarView BackgroundColor=\"Red\"\r\n" +
        "                    BorderColor=\"Black\"\r\n" +
        "                    Text=\"BC\"/>\r\n" +
        "<toolkit:AvatarView BackgroundColor=\"{x:Static core:AppColors.Green}\"\r\n" +
        "                    BorderColor=\"Black\"\r\n" +
        "                    Text=\"BC\"/>\r\n" +
        "<toolkit:AvatarView BackgroundColor=\"#ffe39e\"\r\n" +
        "                    BorderColor=\"Black\"\r\n" +
        "                    Text=\"BC\"/>";

    [ObservableProperty]
    string xamlAvatarViewBorderColor =
        "<toolkit:AvatarView BorderColor=\"Yellow\"\r\n" +
        "                    Text=\"BC\"/>\r\n" +
        "<toolkit:AvatarView BorderColor=\"{x:Static core:AppColors.LightBlue}\"\r\n" +
        "                    Text=\"BC\"/>\r\n" +
        "<toolkit:AvatarView BorderColor=\"#004b5c\"\r\n" +
        "                    Text=\"BC\" />";

    [ObservableProperty]
    string xamlAvatarViewPadding =
        "<toolkit:AvatarView BorderColor=\"Black\"\r\n" +
        "                    Padding=\"2\"\r\n" +
        "                    Text=\"PA\"/>";

    [ObservableProperty]
    string xamlAvatarViewBorderWidth =
        "<toolkit:AvatarView BorderColor=\"Black\"\r\n" +
        "                    BorderWidth=\" 2 \"\r\n" +
        "                    Text=\"BW\" />\r\n";

    [ObservableProperty]
    string xamlAvatarViewSingleCornerSet =
        "<toolkit:AvatarView CornerRadius=\" 8 \" \r\n" +
        "                    HeightRequest=\"48\" \r\n" +
        "                    WidthRequest=\"48\"\r\n" +
        "                    BorderColor=\"Black\"\r\n" +
        "                    Text=\"CR\" />";

    [ObservableProperty]
    string xamlAvatarViewFourCornerSet =
        "<toolkit:AvatarView CornerRadius=\"8, 12, 16, 20\" \r\n" +
        "                    HeightRequest=\"48\" \r\n" +
        "                    WidthRequest=\"48\"\r\n" +
        "                    BorderColor=\"Black\"\r\n" +
        "                    Text=\"CR\" />";

    [ObservableProperty]
    string xamlAvatarViewImageSource =
        "<!--<Add Padding=\"-4, 0, 0, 0\" if picture shifts to the right-->\r\n" +
        "<toolkit:AvatarView BorderColor=\"Black\"\r\n" +
        "                    BackgroundColor=\"Orange\"\r\n" +
        "                    HeightRequest=\"40\" \r\n" +
        "                    WidthRequest=\"40\"\r\n" +
        "                    Padding=\"-4, 0, 0, 0\">\r\n" +
        "   <toolkit:AvatarView.ImageSource>\r\n" +
        "       <FontImageSource Glyph=\"{x:Static core:FluentUIIcon.Ic_fluent_person_circle_24_regular}\" \r\n" +
        "                        FontFamily=\"{x:Static core:FontNames.FluentSystemIconsRegular}\"\r\n" +
        "                        Size=\"100\"\r\n" +
        "                        Color = \"{x:Static core:AppColors.White}\"/>\r\n" +
        "   </toolkit:AvatarView.ImageSource>\r\n" +
        "</toolkit:AvatarView>\r\n\r\n" +
        "<!--ControlInformation is bonded from the ViewModel-->\r\n" +
        "<toolkit:AvatarView BorderColor=\"Black\"\r\n" +
        "                    BackgroundColor=\"Orange\"\r\n" +
        "                    ImageSource=\"{x:Binding ControlInformation.ControlIcon, Mode=OneWay}\"\r\n" +
        "                    HeightRequest=\"40\" \r\n" +
        "                    WidthRequest=\"40\"\r\n" +
        "                    Padding=\"-4, 0, 0, 0\"/>\r\n\r\n" +
        "<toolkit:AvatarView BorderColor=\"Black\"\r\n" +
        "                    ImageSource=\"https://aka.ms/campus.jpg\"\r\n" +
        "                    HeightRequest=\"40\" \r\n" +
        "                    WidthRequest=\"40\"\r\n" +
        "                    Padding=\"-4, 0, 0, 0\">";

    [ObservableProperty]
    string cSharpAvatarViewViewModelImageSource =
        "[ObservableProperty]\r\n" +
        "IGalleryCardInfo controlInformation; // IGalleryCardInfo has ControlIcon property which is why ControlIcon can be called from xaml";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
        ControlInformation = query.GetData<ICommunityToolkitGalleryCardInfo>();
    }
    #endregion

    #region [ Relay Commands ]

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
}
