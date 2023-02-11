using Bogus.DataSets;
using System.Reflection;

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


    #region [Events]
    private void Button_Clicked(object sender, EventArgs e)
    {
        var route = AppRoutes.ChatPage;

        var viewName = route[0].ToString().ToUpper() + route.Substring(1, route.Length - 1);

        var pageFullName = $"MAUIsland.{viewName}";
        var pageType = Type.GetType(pageFullName);
        var page = ServiceHelper.GetService<Page>(pageType);

        Window secondWindow = new(page);
        Application.Current.OpenWindow(secondWindow);
    }
    private void BasePage_SizeChanged(object sender, EventArgs e)
    {
        if (Window.Width < 500)
        {
            _vm.CurrentState = "Phone";
            return;
        }
        else if (Window.Width < 900)
        {
            _vm.CurrentState = "Tablet";
            return;
        }
        else if (Window.Width < 2000)
        {
            _vm.CurrentState = "Desktop";
            return;
        }
    }
    #endregion

}