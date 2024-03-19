using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Xe.AcrylicView;

namespace MAUIsland.Core;

public static class ServicesExtension
{
    public static MauiAppBuilder InitCore(this MauiAppBuilder builder)
    {
        builder.UseAcrylicView();
        builder.UseSkiaSharp(true);
        builder.UseMauiCommunityToolkit();
        builder.UseMauiCommunityToolkitCore();
        builder.UseMauiCommunityToolkitMediaElement();
        return builder;
    }
}