

using Microsoft.UI.Xaml;
using System.Diagnostics;

namespace MAUIsland.WinUI;

public partial class App : MauiWinUIApplication
{
    static Mutex? mutex;

    public App()
    {
        this.InitializeComponent();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        if (!IsSingleInstance())
        {
            Process.GetCurrentProcess().Kill();
        }
        else
        {
            base.OnLaunched(args);
        }
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    static bool IsSingleInstance()
    {
        const string applicationId = "1F9C3A44-059B-4FBC-9D92-476E59FB937A";
        mutex = new Mutex(false, applicationId);

        // keep the mutex reference alive until the normal 
        // termination of the program
        GC.KeepAlive(mutex);

        try
        {
            return mutex.WaitOne(0, false);
        }
        catch (AbandonedMutexException)
        {
            // if one thread acquires a Mutex object 
            // that another thread has abandoned 
            // by exiting without releasing it
            mutex.ReleaseMutex();
            return mutex.WaitOne(0, false);
        }
    }
}

