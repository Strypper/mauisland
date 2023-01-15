using Bogus.DataSets;
using Microsoft.AspNetCore.SignalR.Client;
using System.Reflection;

namespace MAUIsland;

public partial class ChatPage
{
    HubConnection _connection;

    #region[ Ctor ]
    public ChatPage(ChatPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

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

    #endregion

    private async void OnConnectAsync(object sender, EventArgs e)
    {
        _connection.On<string>("ReceiveMessage", (message) =>
        {
            Console.WriteLine(message);
        });

        try
        {
            await _connection.StartAsync();
        }
        catch(Exception ex)
        {

        }
    }

    private async void OnSendMessage(object sender, EventArgs e)
    {
        try
        {
            await _connection.InvokeAsync("SendMessage", "A message was sent from MAUIsland");
        }
        catch (Exception)
        {

            throw;
        }
    }
}
static class ServiceHelper
{
    public static TService GetService<TService>() => Current.GetService<TService>();
    public static TService GetService<TService>(Type type) where TService : class
        => GetService(type) as TService;

    public static object GetService(Type type) => Current.GetService(type);

    public static IServiceProvider Current
    {
        get
        {
#if WINDOWS
            return MauiWinUIApplication.Current.Services;
#endif

            return null;
        }
    }
}