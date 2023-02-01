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
    string currentState;

    [ObservableProperty]
    string typingMessage;

    [ObservableProperty]
    ObservableCollection<ChatMessage> messages;
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    void AddNewMessage()
    {
        if(!string.IsNullOrEmpty(TypingMessage) && 
           !string.IsNullOrWhiteSpace(TypingMessage))
        {
            Messages.Add(new ChatMessage()
            {
                AuthorName = "Strypper",
                AuthorImage = "https://totechsintranet.blob.core.windows.net/team-members/Me(ver 2019).jpg",
                ChatMessageContent = TypingMessage,
                SentTime = DateTime.Now,
            });

            TypingMessage = string.Empty;
        }
    }
    #endregion

    #region [Overrides]

    protected override void OnInit(IDictionary<string, object> query)
    {
        LoadDataAsync(true)
            .FireAndForget();
    }
    #endregion

    #region [Methods]

    private async Task LoadDataAsync(bool forced)
    {

        if (Messages == null)
        {
            Messages = new ObservableCollection<ChatMessage>();
            return;
        }

        if (forced)
        {
            Messages.Clear();
        }
    }
    #endregion
}
