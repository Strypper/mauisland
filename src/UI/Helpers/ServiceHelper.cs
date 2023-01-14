namespace MAUIsland;

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
#elif ANDROID
            return MauiApplication.Current.Services;
#elif IOS || MACCATALYST
            return MauiUIApplicationDelegate.Current.Services;
#else 
    return null;
#endif
        }
    }
}