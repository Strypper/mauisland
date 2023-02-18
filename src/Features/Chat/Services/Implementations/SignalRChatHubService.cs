using CommunityToolkit.Diagnostics;
using Microsoft.AspNetCore.SignalR.Client;

namespace MAUIsland;

public class SignalRChatHubService : IChatHubService
{
    #region [Fields]
    private HubConnection hubConnection;

    private readonly ISecureStorageService secureStorageService;

    private readonly IAppNavigator appNavigator;
    #endregion

    #region [CTor]
    public SignalRChatHubService(ISecureStorageService secureStorageService, IAppNavigator appNavigator)
    {
        this.secureStorageService = secureStorageService;
        this.appNavigator = appNavigator;
    }

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

    public async Task ConnectAsync(bool isLocal)
    {
        var accessToken = await this.secureStorageService.ReadValueAsync("accesstoken");
        Guard.IsNotNullOrEmpty(accessToken);

        try
        {
            if (isLocal)
            {
                hubConnection = new HubConnectionBuilder()
                                .WithAutomaticReconnect()
                                .WithUrl(ChatConstants.LocalBaseUrl, options =>
                                {
                                    options.HttpMessageHandlerFactory = (handler) =>
                                    {
                                        if (handler is HttpClientHandler clientHandler)
                                        {
                                            clientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                                        }
                                        return handler;
                                    };
                                    options.AccessTokenProvider = () =>
                                    {
                                        return Task.FromResult(accessToken);
                                    };

                                }).Build();
            }
            else
            {
                hubConnection = new HubConnectionBuilder()
                                .WithAutomaticReconnect()
                                .WithUrl(ChatConstants.BaseUrl, options =>
                                {
                                    options.AccessTokenProvider = () =>
                                    {
                                        return Task.FromResult(accessToken);
                                    };
                                }).Build();
            }

            await this.hubConnection.StartAsync();
        }
        catch (Exception ex)
        {
            await appNavigator.ShowSnackbarAsync(ex.Message);
        }
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
