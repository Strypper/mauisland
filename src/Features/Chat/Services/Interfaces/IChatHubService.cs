namespace MAUIsland;

public interface IChatHubService
{
    #region [Events]
    event Action<ChatMessageModel> ChatMessageReceived;
    #endregion

    #region [Methods]
    void RegisterChannels();
    Task ConnectAsync(bool isLocal);
    Task SendMessageTest(string message, string authorName, string avatarUrl, DateTime sentTime);

    #endregion


}
