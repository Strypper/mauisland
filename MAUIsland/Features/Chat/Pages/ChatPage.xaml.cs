namespace MAUIsland;

public partial class ChatPage
{
    private ChatPageViewModel _vm;

    #region[ Ctor ]
    public ChatPage(ChatPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = _vm = vm;
    }

    #endregion

    private void Button_Clicked(object sender, EventArgs e)
    {
        Window secondWindow = new(new BridgeWindowChatPage(AppRoutes.ChatPage));
        Application.Current.OpenWindow(secondWindow);
    }
}