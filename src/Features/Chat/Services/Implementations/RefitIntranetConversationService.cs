using CommunityToolkit.Diagnostics;
using Refit;

namespace MAUIsland;

public class RefitIntranetConversationService : IConversationService
{
    #region [Services]
    private readonly IIntranetConversationRefit _intranetConversationRefit;
    private readonly ISecureStorageService _secureStorageService;
    private readonly IAppNavigator _appNavigator;
    #endregion

    #region [CTor]
    public RefitIntranetConversationService(IIntranetConversationRefit intranetConversationRefit,
                                            ISecureStorageService secureStorageService,
                                            IAppNavigator appNavigator)
    {
        _intranetConversationRefit = intranetConversationRefit;
        _secureStorageService = secureStorageService;
        _appNavigator = appNavigator;
    }
    #endregion
    public async Task<ICollection<ChatMessageModel>> GetRecentChatAsync()
    {
        var accessToken = await _secureStorageService.ReadValueAsync("accesstoken");
        Guard.IsNotNullOrEmpty(accessToken);

        try
        {
            var chatMessages = await _intranetConversationRefit.GetLobbyRecentChatMessages(accessToken);

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
        catch (ApiException ex)
        {
            await _appNavigator.ShowSnackbarAsync(ex.Message);
            throw;
        }
    }
}
