namespace MAUIsland;

public interface IChatHubService
{

    #region [Events]

    event Action<ChatMessageModel> ChatMessageReceived;

    #endregion

    #region [Methods]
    void RegisterChannel();
    Task ConnectAsync();

    Task SendMessageTest(string message, string authorName, string avatarUrl, DateTime sentTime);

    #endregion


}
