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
using Syncfusion.Maui.Core.Hosting;
using System.Reflection;

namespace MAUIsland;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitCore()
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
            .RegisterRefitApi()
            .RegisterHubConnection(true)
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

    static MauiAppBuilder RegisterRefitApi(this MauiAppBuilder builder)
    {
        builder.Services.AddRefitClient<ITotechsIdentityAuthenticationRefit>()
                        .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://totechsidentityprovider.azurewebsites.net/api"));
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
        builder.Services.AddSingleton<IUserServices, BogusUserServices>();
        builder.Services.AddSingleton<IControlsService, ControlsService>();
        builder.Services.AddSingleton<IChatHubService, SignalRChatHubService>();
        builder.Services.AddSingleton<ISecureStorageService, SecureStorageService>();
        builder.Services.AddSingleton<IAuthenticationServices, BogusAuthenticationService>();

        builder.Services.AddSingleton<IAppInfo>(AppInfo.Current);
        builder.Services.AddSingleton<IFolderPicker>(FolderPicker.Default);
        return builder;
    }

    static MauiAppBuilder RegisterPages(this MauiAppBuilder builder, string pattern = "Page")
    {
        var assemblies = new Assembly[] { typeof(MauiProgram).Assembly };
        var pageTypes = assemblies.SelectMany(a => a.GetTypes().Where(a => a.Name.EndsWith(pattern) && !a.IsAbstract && !a.IsInterface));
        foreach (var pageType in pageTypes)
        {
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
                .WithUrl(ChatConstants.BaseUrl, options =>
                {
                    options.HttpMessageHandlerFactory = (handler) =>
                    {
                        if (handler is HttpClientHandler clientHandler)
                        {
                            clientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                        }
                        return handler;
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
