using CommunityToolkit.Mvvm.Messaging;

namespace MAUIsland;

public partial class ChatPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IChatHubService chatHubService;

    private readonly IConversationService conversationService;
    #endregion

    #region[CTor]
    public ChatPageViewModel(IAppNavigator appNavigator, IChatHubService chatHubService, IConversationService conversationService) : base(appNavigator)
    {
        this.chatHubService = chatHubService;
        this.conversationService = conversationService;
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    bool canStateChange = true;

    [ObservableProperty]
    bool canChatState = false;

    [ObservableProperty]
    string currentState;

    [ObservableProperty]
    string typingMessage;

    [ObservableProperty]
    UserModel currentUser;

    [ObservableProperty]
    ObservableCollection<ChatMessageModel> messages;

    #endregion

    #region [Relay Commands]
    [RelayCommand]
    async Task SendMessageAsync()
    {
        if (!string.IsNullOrEmpty(TypingMessage) &&
            !string.IsNullOrWhiteSpace(TypingMessage))
        {
            await this.chatHubService.SendMessageTest(TypingMessage,
                                                      CurrentUser.UserName,
                                                      CurrentUser.AvatarUrl,
                                                      DateTime.Now);
            TypingMessage = string.Empty;
        }

    }

    [RelayCommand]
    void SignUp() => NavigateToSignUp();
    #endregion

    #region [Overrides]

    protected override void OnInit(IDictionary<string, object> query)
    {
        SubcribeToLoginMessage();

        Messages = new();
    }
    #endregion

    #region [Methods]

    private async Task LoadMessagesAsync(bool forced)
    {

        if (Messages == null)
        {
            Messages = new ObservableCollection<ChatMessageModel>();
            return;
        }

        var recentChatMessages = await this.conversationService.GetRecentChatAsync();
        foreach (var chatMessage in recentChatMessages)
        {
            Messages.Add(chatMessage);
        }


        if (forced)
        {
            Messages.Clear();
        }
    }

    private async Task ConnectToChatHubAsync()
    {
        await this.chatHubService.ConnectAsync();
        this.chatHubService.RegisterChannels();
        this.chatHubService.ChatMessageReceived += ChatHubService_ChatMessageReceived;
    }

    private void ChatHubService_ChatMessageReceived(ChatMessageModel message)
    {
        Messages.Add(message);
    }

    private void SubcribeToLoginMessage()
    {
        //Subscribe to Login Message
        WeakReferenceMessenger.Default.Register<LoginMessage>(this, (r, m) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                CurrentUser = m.Value;
                AppNavigator.ShowSnackbarAsync("Welcome " + m.Value.UserName);


                ConnectToChatHubAsync()
                    .FireAndForget();

                LoadMessagesAsync(false)
                    .FireAndForget();

                Messages.Add(new ChatMessageModel()
                {
                    AuthorName = "MAUIsland",
                    AuthorImage = "dotnet_bot.png",
                    ChatMessageContent = $"Welcome {m.Value.UserName}",
                    SentTime = DateTime.Now,
                });
            });
        });
    }

    partial void OnCurrentUserChanging(UserModel? currentUser)
       => CanChatState = currentUser is not null ? true : false;

    void NavigateToSignUp()
        => AppNavigator.NavigateAsync(AppRoutes.SignUp, true);
    #endregion
}
