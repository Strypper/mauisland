﻿using DiscordRPC;
using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class MenuBarPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public MenuBarPageViewModel(IAppNavigator appNavigator,
                               IGitHubService gitHubService,
                               DiscordRpcClient discordRpcClient,
                               IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                : base(appNavigator,
                                        gitHubService,
                                        discordRpcClient,
                                        gitHubIssueLocalDbService)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string buttonWithMenuBar =
    "<Button\r\n" +
    "    HorizontalOptions=\"Start\"\r\n" +
    "    Text=\"&#x25B6;&#xFE0F; Play\"\r\n" +
    "    WidthRequest=\"80\">\r\n" +
    "    <FlyoutBase.ContextFlyout>\r\n" +
    "        <MenuFlyout>\r\n" +
    "            <MenuFlyoutItem Text=\"Pause\">\r\n" +
    "                <MenuFlyoutItem.IconImageSource>\r\n" +
    "                    <FontImageSource FontFamily=\"Arial\" Glyph=\"&#x23F8;\" />\r\n" +
    "                </MenuFlyoutItem.IconImageSource>\r\n" +
    "            </MenuFlyoutItem>\r\n" +
    "            <MenuFlyoutItem Text=\"Stop\">\r\n" +
    "                <MenuFlyoutItem.IconImageSource>\r\n" +
    "                    <FontImageSource FontFamily=\"Arial\" Glyph=\"&#x23F9;\" />\r\n" +
    "                </MenuFlyoutItem.IconImageSource>\r\n" +
    "            </MenuFlyoutItem>\r\n" +
    "        </MenuFlyout>\r\n" +
    "    </FlyoutBase.ContextFlyout>\r\n" +
    "</Button>";

    [ObservableProperty]
    string imageWithMenuBar =
        "<Image\r\n" +
        "    HeightRequest=\"100\"\r\n" +
        "    HorizontalOptions=\"Start\"\r\n" +
        "    Source=\"dotnet_bot.png\"\r\n" +
        "    WidthRequest=\"100\">\r\n" +
        "    <FlyoutBase.ContextFlyout>\r\n" +
        "        <MenuFlyout>\r\n" +
        "            <MenuFlyoutItem IconImageSource=\"{x:StaticResource DownloadIcon}\" Text=\"Save Image\" />\r\n" +
        "        </MenuFlyout>\r\n" +
        "    </FlyoutBase.ContextFlyout>\r\n" +
        "</Image>";

    [ObservableProperty]
    string contentPageWithMenuBar =
    "<ContentPage ...\r\n" +
    "    <ContentPage.MenuBarItems>\r\n" +
    "        <MenuBarItem Text=\"File\">\r\n" +
    "            <MenuFlyoutItem Text=\"Exit\"\r\n" +
    "                            Command=\"{Binding ExitCommand}\" />\r\n" +
    "        </MenuBarItem>\r\n" +
    "        <MenuBarItem Text=\"Locations\">\r\n" +
    "            <MenuFlyoutSubItem Text=\"Change Location\">\r\n" +
    "                <MenuFlyoutItem Text=\"Redmond, USA\"\r\n" +
    "                                Command=\"{Binding ChangeLocationCommand}\"\r\n" +
    "                                CommandParameter=\"Redmond\" />\r\n" +
    "                <MenuFlyoutItem Text=\"London, UK\"\r\n" +
    "                                Command=\"{Binding ChangeLocationCommand}\"\r\n" +
    "                                CommandParameter=\"London\" />\r\n" +
    "                <MenuFlyoutItem Text=\"Berlin, DE\"\r\n" +
    "                                Command=\"{Binding ChangeLocationCommand}\"\r\n" +
    "                                CommandParameter=\"Berlin\"/>\r\n" +
    "            </MenuFlyoutSubItem>\r\n" +
    "            <MenuFlyoutSeparator />\r\n" +
    "            <MenuFlyoutItem Text=\"Add Location\"\r\n" +
    "                            Command=\"{Binding AddLocationCommand}\" />\r\n" +
    "            <MenuFlyoutItem Text=\"Edit Location\"\r\n" +
    "                            Command=\"{Binding EditLocationCommand}\" />\r\n" +
    "            <MenuFlyoutItem Text=\"Remove Location\"\r\n" +
    "                            Command=\"{Binding RemoveLocationCommand}\" />\r\n" +
    "        </MenuBarItem>\r\n" +
    "        <MenuBarItem Text=\"View\">\r\n" +
    "            <MenuFlyoutItem Text=\"Refresh\"\r\n" +
    "                            Command=\"{Binding RefreshCommand}\" />\r\n" +
    "            <MenuFlyoutItem Text=\"Change Theme\"\r\n" +
    "                            Command=\"{Binding ChangeThemeCommand}\" />\r\n" +
    "        </MenuBarItem>\r\n" +
    "    </ContentPage.MenuBarItems>\r\n" +
    "</ContentPage>";


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
    Task OpenSnackBar(string message)
    => AppNavigator.ShowSnackbarAsync(message);

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

    #endregion
}
