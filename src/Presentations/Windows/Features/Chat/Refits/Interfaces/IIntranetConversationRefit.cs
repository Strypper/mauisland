using Refit;

namespace MAUIsland;

public interface IIntranetConversationRefit
{
    [Get("/Conversation/GetLobbyRecentChatMessages")]
    Task<ICollection<RefitChatMessageResponse>> GetLobbyRecentChatMessages([Authorize("Bearer")] string token);
}
