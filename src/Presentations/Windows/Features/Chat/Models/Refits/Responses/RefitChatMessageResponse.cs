namespace MAUIsland;

public record RefitChatMessageResponse(RefitUserInfoResponseModel user,
                                       string messageContent,
                                       DateTime dateTime,
                                       int conversationId)
{ }
