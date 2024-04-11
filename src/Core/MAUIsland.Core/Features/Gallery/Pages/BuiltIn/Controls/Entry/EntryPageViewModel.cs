using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class EntryPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public EntryPageViewModel(IAppNavigator appNavigator,
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
    ObservableCollection<ChatMessageModel> messages = default!;

    [ObservableProperty]
    string standardEntryXamlCode =
    "<Entry x:Name=\"Entry\"\n" +
    "       Placeholder=\"Enter text here\"\n" +
    "       PlaceholderColor=\"LightSlateGray\"\n" +
    "       HorizontalTextAlignment=\"Start\"\n" +
    "       VerticalTextAlignment=\"Center\"/>";


    #endregion

    #region [ Overrides ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();

        Messages = new();
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
    Task SendMessage(string message)
    {
        Messages.Add(new ChatMessageModel()
        {
            AuthorName = "MAUIsland",
            AuthorImage = "dotnet_bot.png",
            ChatMessageContent = message,
            SentTime = DateTime.Now
        });

        return Task.CompletedTask;
    }

    [RelayCommand]
    async Task RefreshAsync()
    {
        await RefreshControlIssues(true,
                                   ControlInformation.ControlName,
                                   ControlInformation.GitHubAuthorIssueName,
                                   ControlInformation.GitHubRepositoryIssueName,
                                   ControlInformation.GitHubIssueLabels);
    }
    #endregion
}
