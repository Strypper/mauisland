namespace MAUIsland;

public class RefitIntranetConversationService : IConversationService
{
    #region [Services]
    private readonly IIntranetConversationRefit _intranetConversationRefit;
    #endregion

    #region [CTor]
    public RefitIntranetConversationService(IIntranetConversationRefit intranetConversationRefit)
    {
        _intranetConversationRefit = intranetConversationRefit;
    }
    #endregion
    public async Task<ICollection<ChatMessageModel>> GetRecentChatAsync()
    {
        var chatMessages = await _intranetConversationRefit.GetLobbyRecentChatMessages();

        var chatMessageModels = new List<ChatMessageModel>();

        foreach (var message in chatMessages)
        {
            chatMessageModels.Add(new ChatMessageModel()
            {
                AuthorName = message.user.userName,
                AuthorImage = message.user.profilePic,
                ChatMessageContent = message.messageContent,
                SentTime = message.dateTime
            });
        }

        return chatMessageModels;
    }
}
