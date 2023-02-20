namespace MAUIsland;

public partial class ChatPage
{
    private ChatPageViewModel viewModel;

    #region[ Ctor ]
    public ChatPage(ChatPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = viewModel = vm;
    }

    #endregion


    #region [Event Handlers]
    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void BasePage_SizeChanged(object sender, EventArgs e)
    {
        if (Window.Width < 500)
        {
            viewModel.CurrentState = "Phone";
            return;
        }
        else if (Window.Width < 900)
        {
            viewModel.CurrentState = "Tablet";
            return;
        }
        else if (Window.Width < 2000)
        {
            viewModel.CurrentState = "Desktop";
            return;
        }
    }
    #endregion
}