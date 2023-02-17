using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Storage;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Refit;
using SkiaSharp.Views.Maui.Controls.Hosting;
using SQLite;
using Syncfusion.Maui.Core.Hosting;
using System.Reflection;

namespace MAUIsland;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {

        var isLocal = true;


        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitCore()
            .UseMauiCommunityToolkitMediaElement()
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("FluentSystemIcons-Regular.ttf", FontNames.FluentSystemIconsRegular);
            })
            .ConfigureEssentials(essentials =>
            {
                essentials.UseVersionTracking();
            })
            .RegisterServices()
            .RegisterPages()
            .RegisterControlInfos()
            .RegisterPopups()
            .RegisterRefitApi(isLocal)
            .RegisterHubConnection(isLocal)
            .GetAppSettings()
            .ConfigureSyncfusionCore();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

#if __ANDROID__
    public static void PrependToMappingImageSource(IImageHandler handler, Microsoft.Maui.IImage image)
    {
        //handler.PlatformView?.Clear();
    }
#endif

    static MauiAppBuilder RegisterPopups(this MauiAppBuilder builder)
    {
        builder.Services.AddPopup<AuthenticatePopup, AuthenticatePopupViewModel>(AppRoutes.SignUp);
        return builder;
    }

    static MauiAppBuilder RegisterRefitApi(this MauiAppBuilder builder, bool isLocal)
    {
        builder.Services.AddRefitClient<IIntranetAuthenticationRefit>()
                        .ConfigureHttpClient(c => c.BaseAddress = new Uri(!isLocal
                                                                          ? "https://totechsidentityprovider.azurewebsites.net/api"
                                                                          : "https://localhost:44371/api"));

        builder.Services.AddRefitClient<IIntranetUserRefit>()
                        .ConfigureHttpClient(c => c.BaseAddress = new Uri(!isLocal
                                                                  ? "https://totechsidentityprovider.azurewebsites.net/api"
                                                                  : "https://localhost:44371/api"));
        return builder;
    }

    static MauiAppBuilder RegisterControlInfos(this MauiAppBuilder builder)
    {
        var assemblies = new Assembly[] { typeof(IControlInfo).Assembly };
        var controlInfoTypes = assemblies
            .SelectMany(
                a => a
                    .GetTypes()
                    .Where(a => !a.IsAbstract && !a.IsInterface && a.IsAssignableTo(typeof(IControlInfo))));

        foreach (var controlInfoType in controlInfoTypes)
        {
            builder.Services.AddSingleton(typeof(IControlInfo), controlInfoType);
        }
        return builder;
    }

    static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IFilePicker, FilePicker>();
        builder.Services.AddSingleton<IHomeService, HomeService>();
        builder.Services.AddSingleton<IAppNavigator, AppNavigator>();
        builder.Services.AddSingleton<IUserServices, UserService>();
        builder.Services.AddSingleton<IControlsService, ControlsService>();
        builder.Services.AddSingleton<IChatHubService, SignalRChatHubService>();
        builder.Services.AddSingleton<ISecureStorageService, SecureStorageService>();
        builder.Services.AddSingleton<IAuthenticationServices, RefitAuthenticationService>();

        builder.Services.AddSingleton<IAppInfo>(AppInfo.Current);
        builder.Services.AddSingleton<IFolderPicker>(FolderPicker.Default);

        //Register local database
        builder.Services.AddTransient<SQLiteAsyncConnection>((_) =>
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LocalDatabase.db3");
            return new SQLiteAsyncConnection(dbPath);
        });
        return builder;
    }

    static MauiAppBuilder RegisterPages(this MauiAppBuilder builder, string pattern = "Page")
    {
        var assemblies = new Assembly[] { typeof(MauiProgram).Assembly };
        var pageTypes = assemblies.SelectMany(a => a.GetTypes().Where(a => a.Name.EndsWith(pattern) && !a.IsAbstract && !a.IsInterface));
        foreach (var pageType in pageTypes)
        {
            if (pageType.FullName == "MAUIsland.MediaElementPage")
            {

            }

            var viewModelFullName = $"{pageType.FullName}ViewModel";
            var viewModelType = Type.GetType(viewModelFullName);

            builder.Services.AddTransient(pageType);

            if (viewModelType != null)
                builder.Services.AddTransient(viewModelType);

            if (pageType.IsAssignableTo(typeof(IControlPage)))
            {
                Routing.RegisterRoute(pageType.FullName, pageType);
            }
        }

        return builder;
    }

    static MauiAppBuilder RegisterHubConnection(this MauiAppBuilder builder, bool isLocal)
    {
        try
        {
            if (isLocal)
            {
                builder.Services.AddSingleton((_) => new HubConnectionBuilder()
                .WithAutomaticReconnect()
                .WithUrl(ChatConstants.LocalBaseUrl, options =>
                {
                    options.AccessTokenProvider = () =>
                    {
                        return Task.FromResult("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoidmlldC50b0B0b3RlY2hzLmNvbS52biIsImp0aSI6IjliNjg4OTVlLThiMDgtNGJkMi04ZTI1LWU1ZTVjZWYxZjc2ZSIsImd1aWQiOiJiMjcxMDk5Mi1lNjEwLTQ1N2UtYjY0Ny1kYjFjMDVkZDI0ZTIiLCJuYmYiOjE2NzY2NjEzOTcsImV4cCI6MTY3Njc0Nzc5NywiaWF0IjoxNjc2NjYxMzk3LCJpc3MiOiJUb3RlY2hzSW50cmFuZXQiLCJhdWQiOiJtYXVpc2xhbmQifQ.4HqSJV1YG6Yj6ZWT2aHmLKeqUjCm--Z7nuq-wyg0hXA");
                    };

                }).Build());
            }
            else
            {
                builder.Services.AddSingleton((_) => new HubConnectionBuilder()
                            .WithAutomaticReconnect()
                            .WithUrl(ChatConstants.BaseUrl).Build());
            }
        }
        catch (Exception ex)
        {

            throw;
        }

        return builder;
    }

    static MauiAppBuilder GetAppSettings(this MauiAppBuilder builder)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("MAUIsland.appsettings.Development.json");

        if (stream is not null)
        {
            var config = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .Build();

            builder.Configuration.AddConfiguration(config);
        }
        else
        {
            var options = new SnackbarOptions
            {
                BackgroundColor = AppColors.Purple,
                TextColor = AppColors.White,
                ActionButtonTextColor = AppColors.Pink,
                CornerRadius = new CornerRadius(Dimensions.ButtonCornerRadius),
                CharacterSpacing = 0.5
            };
            var message = "Can't find app settings file";

            var snackbar = Snackbar.Make(message, null, "OK", TimeSpan.FromSeconds(5), options);
            snackbar.Show();
        }

        return builder;
    }

    static IServiceCollection AddPopup<TPopup, TViewModel>(this IServiceCollection services, string name)
    where TPopup : BasePopup where TViewModel : BaseViewModel
    {
        Routing.RegisterRoute(name, typeof(TPopup));
        services.AddTransient<TPopup>();
        services.AddTransient<TViewModel>();
        return services;
    }
}
