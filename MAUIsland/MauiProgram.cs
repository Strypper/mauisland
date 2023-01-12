using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Syncfusion.Maui.Core.Hosting;

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
            .RegisterPopups(); 

        builder.ConfigureSyncfusionCore(); 

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

        return builder;
    }

    static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IAppNavigator, AppNavigator>();
        builder.Services.AddSingleton<IMAUIControlsService, MAUIControlsService>();
        builder.Services.AddSingleton<ISyncfusionControlsService, SyncfusionControlsService>();
        return builder;
    }

    static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
    {
        builder.Services.AddPage<GalleryPage, GalleryPageViewModel>();
        builder.Services.AddPage<ChatPage, ChatPageViewModel>();
        builder.Services.AddPage<MAUIAllControlsPage, MAUIAllControlsPageViewModel>();

        builder.Services.AddPage<ButtonPage, ButtonPageViewModel>();
        builder.Services.AddPage<ImageButtonPage, ImageButtonPageViewModel>();
        builder.Services.AddPage<ProgressBarPage, ProgressBarPageViewModel>();
        builder.Services.AddPage<RefreshViewPage, RefreshViewPageViewModel>();
        builder.Services.AddPage<PickerPage, PickerPageViewModel>();
        builder.Services.AddPage<SliderPage, SliderPageViewModel>();
        builder.Services.AddPage<SearchBarPage, SearchBarPageViewModel>();
        builder.Services.AddPage<StepperPage, StepperPageViewModel>();
        builder.Services.AddPage<EntryPage, EntryPageViewModel>();
        builder.Services.AddPage<CollectionViewPage, CollectionViewPageViewModel>();
        builder.Services.AddPage<IndicatorViewPage, IndicatorViewPageViewModel>();
        builder.Services.AddPage<CarouselViewPage, CarouselViewPageViewModel>();
        builder.Services.AddPage<TimePickerPage, TimePickerPageViewModel>();
        builder.Services.AddPage<SwitchPage, SwitchPageViewModel>();
        builder.Services.AddPage<CheckBoxPage, CheckBoxPageViewModel>();
        builder.Services.AddPage<LabelPage, LabelPageViewModel>();
        //builder.Services.AddPage<SwipeViewPage, SwipeViewPageViewModel>();
        builder.Services.AddPage<RadioButtonPage, RadioButtonPageViewModel>();
        builder.Services.AddPage<DatePickerPage, DatePickerPageViewModel>();
        builder.Services.AddPage<EditorPage, EditorPageViewModel>();
        builder.Services.AddPage<MenuBarPage, MenuBarPageViewModel>();
        builder.Services.AddPage<ActivityIndicatorPage, ActivityIndicatorPageViewModel>();

        builder.Services.AddPage<SyncfusionAllControlsPage, SyncfusionAllControlsPageViewModel>();
        builder.Services.AddPage<SyncfusionListViewPage, SyncfusionListViewPageViewModel>();
        return builder;
    }

    static IServiceCollection AddPage<TPage, TViewModel>(this IServiceCollection services)
where TPage : BasePage where TViewModel : BaseViewModel
    {
        services.AddTransient<TPage>();
        services.AddTransient<TViewModel>();
        return services;
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
