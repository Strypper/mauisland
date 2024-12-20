﻿using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Storage;
using MAUIsland.Home;
using MAUIsland.ResumesTemplate;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Refit;
using Syncfusion.Maui.Core.Hosting;
using System.Reflection;
using ZXing.Net.Maui.Controls;

namespace MAUIsland;

public static class MauiProgram
{

    public static MauiApp CreateMauiApp()
    {

        var isLocal = true;

        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiCommunityToolkitCore()
            .UseMauiCommunityToolkitMediaElement()
            .UseMauiCommunityToolkit(options => options.SetShouldEnableSnackbarOnWindows(true))
#if DEBUG
            .RegisterAppSettingsFromJsonFile()
#else
            .RegisterAppSettingsFromCode()
#endif
            .UseMauiApp<App>()
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
            .RegisterRealTimeConnection(isLocal)
            .ConfigureSyncfusionCore()
            .UseBarcodeReader();


#if DEBUG
        builder.Logging.AddDebug();
        builder.Services.AddBlazorWebViewDeveloperTools();

        builder.Services.AddLogging(logging =>
        {
            logging.AddFilter("Microsoft.AspNetCore.Components.WebView", LogLevel.Trace);
            logging.AddDebug();
        });
#endif


        var serviceProvider = builder.Services.BuildServiceProvider();
        var appSettings = serviceProvider.GetRequiredService<AppSettings>();

        builder.InitCore(gitHubFeatureAccessToken: appSettings.GitHubAccessToken);

        //Temp way for blazor web view, razor and xaml shared states only work with singleton currently
        builder.Services.AddSingleton<BlazorWebViewPageViewModel>();
        builder.Services.AddSingleton<ResumeDetailPageViewModel>();

        return builder.Build();
    }

    static MauiAppBuilder RegisterPopups(this MauiAppBuilder builder)
    {
        builder.Services.AddPopup<AuthenticatePopup, AuthenticatePopupViewModel>(AppRoutes.SignUp);
        return builder;
    }

    static MauiAppBuilder RegisterRefitApi(this MauiAppBuilder builder, bool isLocal)
    {
        builder.Services.AddRefitClient<IIntranetAuthenticationRefit>()
                        .ConfigureHttpClient(c => c.BaseAddress = new Uri(!isLocal
                                                                          ? "https://intranetcloud.azurewebsites.net/api"
                                                                          : "https://localhost:44371/api"));

        builder.Services.AddRefitClient<IIntranetUserRefit>()
                        .ConfigureHttpClient(c => c.BaseAddress = new Uri(!isLocal
                                                                          ? "https://intranetcloud.azurewebsites.net/api"
                                                                          : "https://localhost:44371/api"));

        builder.Services.AddRefitClient<IIntranetConversationRefit>()
                        .ConfigureHttpClient(c => c.BaseAddress = new Uri(!isLocal
                                                                          ? "https://intranetcloud.azurewebsites.net/api"
                                                                          : "https://localhost:44371/api"));
        return builder;
    }

    static MauiAppBuilder RegisterControlInfos(this MauiAppBuilder builder)
    {
        var assemblies = new List<Assembly>
    {
        typeof(IGalleryCardInfo).Assembly, // Assuming IGalleryCardInfo is now in MAUIsland.Core
    };

        // Explicitly add the MAUIsland.Core assembly, ensuring it's considered.
        var coreAssembly = AppDomain.CurrentDomain.GetAssemblies()
                                                  .FirstOrDefault(x => x.GetName().Name == "MAUIsland.Core");
        if (coreAssembly != null)
        {
            assemblies.Add(coreAssembly);
        }

        var allTypes = assemblies.SelectMany(assembly => assembly.GetTypes());
        var galleryCardInfoTypes = allTypes.Where(type => !type.IsAbstract && !type.IsInterface && type.IsAssignableTo(typeof(IGalleryCardInfo)));
        var distinctGalleryCardInfoTypes = galleryCardInfoTypes.Distinct();
        var galleryCardInfoTypeList = distinctGalleryCardInfoTypes.ToList();

        foreach (var controlInfoType in galleryCardInfoTypeList)
        {
            builder.Services.AddSingleton(typeof(IGalleryCardInfo), controlInfoType);
        }

        return builder;
    }

    static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IMrIncreadibleMemeService, MrIncreadibleMemeService>();
        builder.Services.AddSingleton<IHomeService, HomeService>();
        builder.Services.AddSingleton<IAppNavigator, AppNavigator>();
        builder.Services.AddSingleton<IChatHubService, SignalRChatHubService>();
        builder.Services.AddSingleton<ISecureStorageService, SecureStorageService>();
        builder.Services.AddSingleton<IUserServices, RefitIntranetUserService>();
        builder.Services.AddSingleton<IConversationService, RefitIntranetConversationService>();
        builder.Services.AddSingleton<IAuthenticationServices, RefitAuthenticationService>();

        builder.Services.AddSingleton<IAppInfo>(AppInfo.Current);
        builder.Services.AddSingleton<IFolderPicker>(FolderPicker.Default);
        builder.Services.AddMauiBlazorWebView();

        builder.Configuration.GetSection("AppSettings");

        builder.Services.AddSingleton(_ =>
        {
            var appSettings = ServiceHelper.GetService<AppSettings>();

            var client = new DiscordRPC.DiscordRpcClient(appSettings.DiscordApplicationId);

            //Set the logger
            client.Logger = new DiscordRPC.Logging.ConsoleLogger() { Level = DiscordRPC.Logging.LogLevel.Warning };

            //Subscribe to events
            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Received Update! {0}", e.Presence);
            };

            //Connect to the RPC
            client.Initialize();

            return client;
        });


        return builder;
    }

    static MauiAppBuilder RegisterRealTimeConnection(this MauiAppBuilder builder, bool isLocal)
    {
        builder.Services.AddScoped<HubConnection>((_) =>
        {
            var secureStorageService = ServiceHelper.GetService<ISecureStorageService>();

            if (secureStorageService is null) return null;

            var accessToken = secureStorageService.ReadValueAsync("accesstoken")
                                                  .GetAwaiter().GetResult();

            if (accessToken is null) return null;

            return isLocal ? new HubConnectionBuilder()
                                .WithAutomaticReconnect()
                                .WithUrl(ChatConstants.LocalBaseUrl, options =>
                                {
                                    options.AccessTokenProvider = () =>
                                    {
                                        return Task.FromResult(accessToken);
                                    };

                                }).Build()
                            : new HubConnectionBuilder()
                                .WithAutomaticReconnect()
                                .WithUrl(ChatConstants.BaseUrl, options =>
                                {
                                    options.AccessTokenProvider = () =>
                                    {
                                        return Task.FromResult(accessToken);
                                    };
                                }).Build();
        });

        return builder;
    }

    static MauiAppBuilder RegisterPages(this MauiAppBuilder builder, string pattern = "Page")
    {
        var assemblies = new Assembly[] { typeof(MauiProgram).Assembly };
        var coreAssemblies = AppDomain.CurrentDomain.GetAssemblies().Single(x => x.GetName().Name == "MAUIsland.Core");
        var pageTypes = assemblies.SelectMany(a => a.GetTypes().Where(a => a.Name.EndsWith(pattern) && !a.IsAbstract && !a.IsInterface));
        foreach (var pageType in pageTypes)
        {
            var viewModelFullName = $"{pageType.FullName}ViewModel";
            var viewModelType = Type.GetType(viewModelFullName);

            if (viewModelType is null)
            {
                var coreViewModelFullName = $"MAUIsland.Core.{pageType.Name}ViewModel";
                var coreViewModelType = coreAssemblies.GetType(coreViewModelFullName);

                if (coreViewModelType is null)
                    continue;

                builder.Services.AddTransient(pageType);
                builder.Services.AddTransient(coreAssemblies.GetType(coreViewModelFullName));
            }
            else
            {
                builder.Services.AddTransient(pageType);

                if (viewModelType is null)
                    continue;

                builder.Services.AddTransient(viewModelType);
            }


            if (pageType.IsAssignableTo(typeof(IGalleryPage)))
                Routing.RegisterRoute(pageType.FullName, pageType);

        }

        return builder;
    }

    static MauiAppBuilder RegisterAppSettingsFromJsonFile(this MauiAppBuilder builder)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("MAUIsland.appsettings.Development.json");
        using var appsettingspagestream = assembly.GetManifestResourceStream("MAUIsland.Features.Gallery.Pages.BuiltIn.Helpers.AppSettingsJson.JsonFiles.appsettings.json");

        if (stream is not null && appsettingspagestream is not null)
        {
            var systemConfig = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .Build();

            var appSettingsFeatureConfig = new ConfigurationBuilder()
                        .AddJsonStream(appsettingspagestream)
                        .Build();

            builder.Configuration.AddConfiguration(systemConfig);
            builder.Configuration.AddConfiguration(appSettingsFeatureConfig);

            var systemSettings = new AppSettings();
            systemConfig.GetSection("AppSettings").Bind(systemSettings);
            builder.Services.AddSingleton(systemSettings);
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
