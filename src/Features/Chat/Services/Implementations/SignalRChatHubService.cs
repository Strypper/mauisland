using CommunityToolkit.Diagnostics;
using Microsoft.AspNetCore.SignalR.Client;

namespace MAUIsland;

public class SignalRChatHubService : IChatHubService
{
    #region [Fields]

    private readonly IAppNavigator appNavigator;

    private readonly HubConnection hubConnection;

    private readonly ISecureStorageService secureStorageService;
    #endregion

    #region [CTor]
    public SignalRChatHubService(IAppNavigator appNavigator,
                                 HubConnection hubConnection,
                                 ISecureStorageService secureStorageService)
    => (this.appNavigator, this.hubConnection, this.secureStorageService)
        = (appNavigator, hubConnection, secureStorageService);

    #endregion

    #region [Events]

    public event Action<ChatMessageModel> ChatMessageReceived;
    #endregion

    #region [Methods]
    public void RegisterChannels()
    {
        Guard.IsNotNull(this.hubConnection);

        this.hubConnection.On<string, string, string, DateTime>("ReceiveMessage", (message, authorName, avartarUrl, sentTime) =>
        {
            var chatmessage = new ChatMessageModel()
            {
                AuthorName = authorName,
                AuthorImage = avartarUrl,
                ChatMessageContent = message,
                SentTime = sentTime,
            };
            ChatMessageReceived?.Invoke(chatmessage);
        });
    }

    public async Task ConnectAsync()
    {
        Guard.IsNotNull(this.hubConnection);

        await this.hubConnection.StartAsync();
    }

    public Task SendMessageTest(string message, string authorName, string avatarUrl, DateTime sentTime)
    {
        return Task.Run(() =>
        {
            Guard.IsNotNull(this.hubConnection);
            this.hubConnection.InvokeAsync("SendMessage", message);
        });
    }
    #endregion
}
