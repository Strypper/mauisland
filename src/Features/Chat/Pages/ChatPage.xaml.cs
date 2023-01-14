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

    private void Button_Clicked(object sender, EventArgs e)
    {
        //var route = AppRoutes.ButtonPage;

        //var viewName = route[0].ToString().ToUpper() + route.Substring(1, route.Length - 1);

        //var pageFullName = $"MAUIsland.{viewName}";
        //var pageType = Type.GetType(pageFullName);
        //var page = ServiceHelper.GetService<Page>(pageType);

        ////var viewModelFullName = $"MAUIsland.{viewName}ViewModel";
        ////var viewModelType = Type.GetType(viewModelFullName);
        ////var viewModel = ServiceHelper.GetService(viewModelType);

        //Window secondWindow = new(page);
        //Application.Current.OpenWindow(secondWindow);
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