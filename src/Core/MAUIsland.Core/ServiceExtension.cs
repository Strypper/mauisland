using CommunityToolkit.Maui;
using Material.Components.Maui.Extensions;
using MAUIsland.Features.LocalDbFeatures;
using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;
using Plugin.Maui.OCR;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Xe.AcrylicView;
using ZXing.Net.Maui.Controls;

namespace MAUIsland.Core;

public static class ServicesExtension
{
    public static MauiAppBuilder InitCore(this MauiAppBuilder builder)
    {

        //builder.UseMauiCommunityToolkit(option => option.SetShouldEnableSnackbarOnWindows(true));

        builder.UseOcr();
        builder.UseAcrylicView();
        builder.UseSkiaSharp(true);
        builder.UseBarcodeReader();
        builder.UseMaterialComponents();


        builder.Services.RegisterGitHubFeatures();
        builder.Services.AddSingleton<IFilePicker, FilePicker>();
        builder.Services.AddTransient<IDialogService, DialogService>();
        builder.Services.AddSingleton<IControlsService, ControlsService>();
        builder.Services.AddTransient<IGitHubRepositorySyncService, GitHubRepositorySyncService>();
        builder.Services.AddTransient<ICardInfoSyncService, CardInfoSyncService>();

        #region [ LocalDb ]

        var DbName = "mauisland.db";
        var localDbPath = Path.Combine(FileSystem.AppDataDirectory, DbName);
        builder.Services.RegisterLocalDbFeatures(localDbPath);
        builder.Services.RegisterLocalDbFeaturesGitHub();
        #endregion


        return builder;
    }
}

