using Microsoft.AspNetCore.SignalR.Client;

namespace MAUIsland;

public class SignalRChatHubService : IChatHubService
{
    #region [Fields]
    private readonly HubConnection hubConnection;
    #endregion

    #region [CTor]
    public SignalRChatHubService(HubConnection hubConnection)
    {
        this.hubConnection = hubConnection;
    }

    #endregion

    #region [Events]

    public event Action<ChatMessageModel> ChatMessageReceived;
    #endregion

    #region [Methods]
    public void RegisterChannel()
    {
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

        await this.hubConnection.StartAsync();

    }

    public Task SendMessageTest(string message, string authorName, string avatarUrl, DateTime sentTime)
    {
        return Task.Run(() =>
        this.hubConnection.InvokeAsync("SendMessage", message));
    }
    #endregion
}
