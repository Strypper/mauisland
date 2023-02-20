// <copyright file="MicaWindow.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using MAUIsland;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using WinRT;

namespace MAUIsland;    

/// <summary>
/// Mica Window.
/// </summary>
public class MicaWindow : Microsoft.Maui.Controls.Window
{
    private Microsoft.UI.Xaml.Window? appWindow;
    private WindowsSystemDispatcherQueueHelper? m_wsdqHelper; // See separate sample below for implementation
    private MicaController? m_micaController;
    private SystemBackdropConfiguration? m_configurationSource;

    /// <inheritdoc/>
    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        this.SetupWindow();
    }

    private void SetupWindow()
    {
        var handler = this.Handler as Microsoft.Maui.Handlers.WindowHandler;
        if (handler?.PlatformView is not Microsoft.UI.Xaml.Window window)
        {
            return;
        }

        this.appWindow = window;
        this.TrySetMicaBackdrop();
    }

    private bool TrySetMicaBackdrop()
    {
        if (this.appWindow is null)
        {
            return false;
        }

        if (!MicaController.IsSupported())
        {
            return false;
        }

        this.m_wsdqHelper ??= new WindowsSystemDispatcherQueueHelper();
        this.m_wsdqHelper.EnsureWindowsSystemDispatcherQueueController();

        // Hooking up the policy object
        this.m_configurationSource = new SystemBackdropConfiguration();
        this.appWindow.Activated += this.AppWindow_Activated;
        this.appWindow.Closed += this.AppWindow_Closed;

        // Initial configuration state.
        this.m_configurationSource.IsInputActive = true;

        if (this.appWindow.Content is FrameworkElement { ActualTheme: var actualTheme })
        {
            this.m_configurationSource.Theme = actualTheme switch
            {
                ElementTheme.Dark => SystemBackdropTheme.Dark,
                ElementTheme.Light => SystemBackdropTheme.Light,
                ElementTheme.Default => SystemBackdropTheme.Default,
                _ => SystemBackdropTheme.Default,
            };
        }

        this.m_micaController = new MicaController();

        // Enable the system backdrop.
        // Note: Be sure to have "using WinRT;" to support the Window.As<...>() call.
        this.m_micaController.AddSystemBackdropTarget(this.appWindow.As<Microsoft.UI.Composition.ICompositionSupportsSystemBackdrop>());
        this.m_micaController.SetSystemBackdropConfiguration(this.m_configurationSource);

        return true;
    }

    private void AppWindow_Closed(object sender, WindowEventArgs args)
    {
        // Make sure any Mica/Acrylic controller is disposed so it doesn't try to
        // use this closed window.
        if (this.m_micaController != null)
        {
            this.m_micaController.Dispose();
            this.m_micaController = null;
        }

        if (this.appWindow is not null)
        {
            this.appWindow.Activated -= this.AppWindow_Activated;
        }

        this.m_configurationSource = null;
    }

    private void AppWindow_Activated(object sender, WindowActivatedEventArgs args)
    {
        if (this.appWindow is null || this.m_configurationSource is null)
        {
            return;
        }

        this.m_configurationSource.IsInputActive = args.WindowActivationState != WindowActivationState.Deactivated;

        if (this.appWindow.Content is FrameworkElement frameworkElement)
        {
            frameworkElement.ActualThemeChanged += (sender, args) =>
            {
                this.m_configurationSource.Theme = frameworkElement.ActualTheme switch
                {
                    ElementTheme.Dark => SystemBackdropTheme.Dark,
                    ElementTheme.Light => SystemBackdropTheme.Light,
                    ElementTheme.Default => SystemBackdropTheme.Default,
                    _ => SystemBackdropTheme.Default,
                };
            };
        }
    }
}