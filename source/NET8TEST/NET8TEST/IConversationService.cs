namespace MAUIsland;

public interface IConversationService
{
    Task<ICollection<ChatMessageModel>> GetRecentChatAsync();
}
