using Microsoft.AspNetCore.SignalR.Client;

namespace MAUIsland;

public partial class BridgeWindowChatPage : ContentPage
{
    HubConnection _connection;

    private string _url;

	public BridgeWindowChatPage(string url)
	{
		InitializeComponent();
        _url = url;

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
    }

    private async void ContentPage_Appearing(object sender, EventArgs e)
    {
        //await Shell.Current.GoToAsync(_url);
    }
}