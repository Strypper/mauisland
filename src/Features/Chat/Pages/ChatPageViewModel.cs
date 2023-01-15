using Microsoft.AspNetCore.SignalR.Client;

namespace MAUIsland;

public class ChatPageViewModel : NavigationAwareBaseViewModel
{
    HubConnection _connection;

    #region[ Ctor ]
    public ChatPageViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
        _connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44371/mauislandhub", options =>
                {
                    options.HttpMessageHandlerFactory = (handler) =>
                    {
                        if (handler is HttpClientHandler clientHandler)
                        {
                            clientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                        }
                        return handler;
                    };
                }).Build();

        try
        {
            _connection.StartAsync();
        }
        catch (Exception ex)
        {
            
        }
    }
    #endregion


}
