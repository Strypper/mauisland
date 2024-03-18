using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using Xe.AcrylicView;

namespace MAUIsland.Core;

public static class ServicesExtension
{
    public static MauiAppBuilder InitCore(this MauiAppBuilder builder)
    {
        builder.UseAcrylicView();
        builder.UseMauiCommunityToolkit();
        builder.UseMauiCommunityToolkitCore();
        builder.UseMauiCommunityToolkitMediaElement();
        return builder;
    }
}