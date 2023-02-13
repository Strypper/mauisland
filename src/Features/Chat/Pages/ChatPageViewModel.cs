using CommunityToolkit.Mvvm.Messaging;

namespace MAUIsland;

public partial class ChatPageViewModel : NavigationAwareBaseViewModel
{
    #region[ Ctor ]
    public ChatPageViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {

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
    void AddNewMessage()
    {
        if (!string.IsNullOrEmpty(TypingMessage) &&
           !string.IsNullOrWhiteSpace(TypingMessage))
        {
            Messages.Add(new ChatMessageModel()
            {
                AuthorName = CurrentUser.UserName,
                AuthorImage = CurrentUser.AvatarUrl,
                ChatMessageContent = TypingMessage,
                SentTime = DateTime.Now,
            });

            TypingMessage = string.Empty;
        }
    }

    [RelayCommand]
    void SignUp() => NavigateToSignUp();
    #endregion

    #region [Overrides]

    protected override void OnInit(IDictionary<string, object> query)
    {
        WeakReferenceMessenger.Default.Register<LoginMessage>(this, (r, m) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                CurrentUser = m.Value;
                AppNavigator.ShowSnackbarAsync("Welcome " + m.Value.UserName);
                Messages.Add(new ChatMessageModel()
                {
                    AuthorName = "MAUIsland",
                    AuthorImage = "dotnet_bot.png",
                    ChatMessageContent = $"Welcome {m.Value.UserName}",
                    SentTime = DateTime.Now,
                });
            });
        });

        LoadDataAsync(true)
            .FireAndForget();
    }

    protected override void OnBack(IDictionary<string, object> query)
    {
        base.OnBack(query);

        CurrentUser = query.GetData<UserModel>();
    }
    #endregion

    #region [Methods]

    private async Task LoadDataAsync(bool forced)
    {

        if (Messages == null)
        {
            Messages = new ObservableCollection<ChatMessageModel>();
            return;
        }

        if (forced)
        {
            Messages.Clear();
        }
    }

    partial void OnCurrentUserChanging(UserModel? currentUser)
       => CanChatState = currentUser is not null ? true : false;

    void NavigateToSignUp()
        => AppNavigator.NavigateAsync(AppRoutes.SignUp, true);
    #endregion
}
