using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;


public partial class SwipeViewPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public SwipeViewPageViewModel(IAppNavigator appNavigator,
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
    string standardSwipeViewXamlCode =
    "<SwipeView>\r\n" +
    "    <SwipeView.LeftItems>\r\n" +
    "        <SwipeItems>\r\n" +
    "            <SwipeItem\r\n" +
    "                BackgroundColor=\"LightGreen\"\r\n" +
    "                Command=\"{x:Binding FavoriteCommand}\"\r\n" +
    "                IconImageSource=\"favorite.png\"\r\n" +
    "                Text=\"Favorite\" />\r\n" +
    "            <SwipeItem\r\n" +
    "                BackgroundColor=\"LightPink\"\r\n" +
    "                Command=\"{x:Binding DeleteCommand}\"\r\n" +
    "                IconImageSource=\"delete.png\"\r\n" +
    "                Text=\"Delete\" />\r\n" +
    "        </SwipeItems>\r\n" +
    "    </SwipeView.LeftItems>\r\n" +
    "    <Grid\r\n" +
    "        BackgroundColor=\"DimGray\"\r\n" +
    "        HeightRequest=\"60\"\r\n" +
    "        WidthRequest=\"300\">\r\n" +
    "        <Label\r\n" +
    "            HorizontalOptions=\"Center\"\r\n" +
    "            Text=\"Swipe right\"\r\n" +
    "            VerticalOptions=\"Center\" />\r\n" +
    "    </Grid>\r\n" +
    "</SwipeView>";

    [ObservableProperty]
    string swipeItemsXamlCode =
        "<SwipeView>\r\n" +
        "    <SwipeView.LeftItems>\r\n" +
        "        <SwipeItems>\r\n" +
        "            <SwipeItem\r\n" +
        "                BackgroundColor=\"LightGreen\"\r\n" +
        "                IconImageSource=\"favorite.png\"\r\n" +
        "                Text=\"Favorite\" />\r\n" +
        "            <SwipeItem\r\n" +
        "                BackgroundColor=\"LightPink\"\r\n" +
        "                IconImageSource=\"delete.png\"\r\n" +
        "                Text=\"Delete\" />\r\n" +
        "        </SwipeItems>\r\n" +
        "    </SwipeView.LeftItems>\r\n" +
        "    <Grid\r\n" +
        "        BackgroundColor=\"ForestGreen\"\r\n" +
        "        HeightRequest=\"60\"\r\n" +
        "        WidthRequest=\"300\">\r\n" +
        "        <Label\r\n" +
        "            HorizontalOptions=\"Center\"\r\n" +
        "            Text=\"Swipe right\"\r\n" +
        "            VerticalOptions=\"Center\" />\r\n" +
        "    </Grid>\r\n" +
        "</SwipeView>";

    [ObservableProperty]
    string swipeDirectionXamlCode =
        "<SwipeView>\r\n" +
        "    <SwipeView.LeftItems>\r\n" +
        "        <SwipeItems Mode=\"Execute\">\r\n" +
        "            <SwipeItem\r\n" +
        "                BackgroundColor=\"LightPink\"\r\n" +
        "                Command=\"{x:Binding DeleteCommand}\"\r\n" +
        "                IconImageSource=\"delete.png\"\r\n" +
        "                Text=\"Delete\" />\r\n" +
        "        </SwipeItems>\r\n" +
        "    </SwipeView.LeftItems>\r\n" +
        "    <SwipeView.RightItems>\r\n" +
        "        <SwipeItems Mode=\"Reveal\">\r\n" +
        "            <SwipeItem\r\n" +
        "                BackgroundColor=\"LightGreen\"\r\n" +
        "                Command=\"{x:Binding FavoriteCommand}\"\r\n" +
        "                IconImageSource=\"favorite.png\"\r\n" +
        "                Text=\"Favorite\" />\r\n" +
        "            <SwipeItem\r\n" +
        "                BackgroundColor=\"LightYellow\"\r\n" +
        "                Command=\"{x:Binding ShareCommand}\"\r\n" +
        "                IconImageSource=\"share.png\"\r\n" +
        "                Text=\"Share\" />\r\n" +
        "        </SwipeItems>\r\n" +
        "    </SwipeView.RightItems>\r\n" +
        "    <Grid\r\n" +
        "        BackgroundColor=\"BlueViolet\"\r\n" +
        "        HeightRequest=\"60\"\r\n" +
        "        WidthRequest=\"300\">\r\n" +
        "        <Label\r\n" +
        "            HorizontalTextAlignment=\"Center\"\r\n" +
        "            Text=\"Swipe Right Or Left\"\r\n" +
        "            VerticalOptions=\"Center\" />\r\n" +
        "    </Grid>\r\n" +
        "</SwipeView>";

    [ObservableProperty]
    string swipeThresholdXamlCode =
        "<SwipeView Threshold=\"200\">\r\n" +
        "    <SwipeView.LeftItems>\r\n" +
        "        <SwipeItems>\r\n" +
        "            <SwipeItem\r\n" +
        "                BackgroundColor=\"LightGreen\"\r\n" +
        "                IconImageSource=\"favorite.png\"\r\n" +
        "                Text=\"Favorite\" />\r\n" +
        "        </SwipeItems>\r\n" +
        "    </SwipeView.LeftItems>\r\n" +
        "    <Grid\r\n" +
        "        BackgroundColor=\"Tomato\"\r\n" +
        "        HeightRequest=\"60\"\r\n" +
        "        WidthRequest=\"300\">\r\n" +
        "        <Label\r\n" +
        "            HorizontalTextAlignment=\"Center\"\r\n" +
        "            Text=\"Swipe Right\"\r\n" +
        "            VerticalOptions=\"Center\" />\r\n" +
        "    </Grid>\r\n" +
        "</SwipeView>";

    [ObservableProperty]
    string swipeModeXamlCode =
    "<SwipeView>\r\n" +
    "    <SwipeView.LeftItems>\r\n" +
    "        <SwipeItems Mode=\"Execute\">\r\n" +
    "            <SwipeItem\r\n" +
    "                BackgroundColor=\"LightPink\"\r\n" +
    "                Command=\"{x:Binding DeleteCommand}\"\r\n" +
    "                IconImageSource=\"delete.png\"\r\n" +
    "                Text=\"Delete\" />\r\n" +
    "        </SwipeItems>\r\n" +
    "    </SwipeView.LeftItems>\r\n" +
    "    <Grid\r\n" +
    "        BackgroundColor=\"LightCoral\"\r\n" +
    "        HeightRequest=\"60\"\r\n" +
    "        WidthRequest=\"300\">\r\n" +
    "        <Label\r\n" +
    "            HorizontalTextAlignment=\"Center\"\r\n" +
    "            Text=\"Swipe Right\"\r\n" +
    "            VerticalOptions=\"Center\" />\r\n" +
    "    </Grid>\r\n" +
    "</SwipeView>";

    [ObservableProperty]
    string swipeBehaviorXamlCode =
        "<SwipeView>\r\n" +
        "    <SwipeView.LeftItems>\r\n" +
        "        <SwipeItems SwipeBehaviorOnInvoked=\"RemainOpen\">\r\n" +
        "            <SwipeItem\r\n" +
        "                BackgroundColor=\"LightGreen\"\r\n" +
        "                IconImageSource=\"favorite.png\"\r\n" +
        "                Text=\"Favorite\" />\r\n" +
        "            <SwipeItem\r\n" +
        "                BackgroundColor=\"LightPink\"\r\n" +
        "                IconImageSource=\"delete.png\"\r\n" +
        "                Text=\"Delete\" />\r\n" +
        "        </SwipeItems>\r\n" +
        "    </SwipeView.LeftItems>\r\n" +
        "    <Grid\r\n" +
        "        BackgroundColor=\"Orchid\"\r\n" +
        "        HeightRequest=\"60\"\r\n" +
        "        WidthRequest=\"300\">\r\n" +
        "        <Label\r\n" +
        "            HorizontalTextAlignment=\"Center\"\r\n" +
        "            Text=\"Swipe Right\"\r\n" +
        "            VerticalOptions=\"Center\" />\r\n" +
        "    </Grid>\r\n" +
        "</SwipeView>";


    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();

    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
        await RefreshAsync();
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

        await RefreshControlIssues(true,
                                   ControlInformation.ControlName,
                                   ControlInformation.GitHubAuthorIssueName,
                                   ControlInformation.GitHubRepositoryIssueName,
                                   ControlInformation.GitHubIssueLabels);
    }

    [RelayCommand]
    Task DeleteAsync()
    => AppNavigator.ShowSnackbarAsync("You triggered delete", null, "Ok");

    [RelayCommand]
    Task FavoriteAsync()
    => AppNavigator.ShowSnackbarAsync("You triggered favorite", null, "Ok");

    [RelayCommand]
    Task ShareAsync()
    => AppNavigator.ShowSnackbarAsync("You triggered share", null, "Ok");

    [RelayCommand]
    Task CheckAnswerAsync()
    => AppNavigator.ShowSnackbarAsync("You triggered check anwser", null, "Ok");
    #endregion
}