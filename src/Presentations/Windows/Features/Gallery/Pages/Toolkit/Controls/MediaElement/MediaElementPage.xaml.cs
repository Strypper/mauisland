using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Net;

namespace MAUIsland;
public partial class MediaElementPage : IGalleryPage
{
    #region [ Fields ]
    readonly ILogger MediaElementLogger;
    MediaElementPageViewModel ViewModel;
    string videoUrl = "https://petaversestorageaccount.blob.core.windows.net/petaverse-petvideos/Breathing 😂";
    string localFilePath = Path.Combine(FileSystem.Current.AppDataDirectory, "video.mp4");
    #endregion

    #region [CTor]
    public MediaElementPage(MediaElementPageViewModel vm, ILogger<MediaElementPage> mediaElementLogger)
    {
        InitializeComponent();

        BindingContext = ViewModel = vm;
        this.MediaElementLogger = mediaElementLogger;
        MediaElement.PropertyChanged += MediaElementPropertyChanged;
    }
    #endregion

    #region [ Override ]
    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // Disconnect the event handlers.
        MediaElement.MediaEnded -= OnMediaEnded;
        MediaElement.MediaFailed -= OnMediaFailed;
        MediaElement.MediaOpened -= OnMediaOpened;
        MediaElement.PositionChanged -= OnPositionChanged;
        MediaElement.StateChanged -= OnStateChanged;
        MediaElement.SeekCompleted -= OnSeekCompleted;

        // Set the Source property to null.
        MediaElement.Source = null;
    }
    #endregion

    #region [ Event Handlers ]
    void MediaElementPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == MediaElement.DurationProperty.PropertyName)
        {
            MediaElementLogger.LogInformation("Duration: {newDuration}", MediaElement.Duration);
            PositionSlider.Maximum = MediaElement.Duration.TotalSeconds;
        }
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        if (File.Exists(localFilePath))
        {
            MediaElementDownloadSample.Source = MediaSource.FromFile(localFilePath);
        }
        else
        {
            CheckFileLabel.Text = $"Nah bro";
        }
    }

    void ContentPage_Unloaded(object? sender, EventArgs e)
    {
        MediaElementDownloadSample.Handler?.DisconnectHandler();
        MediaElement.Handler?.DisconnectHandler();
        SimpleMediaElement.Handler?.DisconnectHandler();
    }

    private void DownloadButton_Clicked(object sender, EventArgs e)
    {
        DownloadIndicator.IsRunning = true;
        using (var client = new WebClient())
        {
            client.DownloadFileCompleted += (sender, e) =>
            {
                DownloadIndicator.IsRunning = false;
                ResultLabel.Text = "Video download finished!";
                MediaElementDownloadSample.Source = MediaSource.FromFile(localFilePath);
            };
            client.DownloadProgressChanged += (sender, e) =>
            {
                DownloadProgressBar.Progress = e.ProgressPercentage / 100.0;
            };

            client.DownloadFileAsync(new Uri(videoUrl), localFilePath);
        }
    }

    private void CheckDownload_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(localFilePath))
        {
            CheckFileLabel.Text = $"Yub it's here {localFilePath}";
        }
        else
        {
            CheckFileLabel.Text = $"No file exist";
        }
    }

    private void DeleteLocalVideoButton_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(localFilePath))
        {
            File.Delete(localFilePath);
            CheckFileLabel.Text = "Deleted !!";
        }
        else
        {
            CheckFileLabel.Text = $"No file exist !!!";
        }
    }

    void OnMediaOpened(object? sender, EventArgs e) 
        => MediaElementLogger.LogInformation("Media opened.");

    void OnStateChanged(object? sender, MediaStateChangedEventArgs e) 
        => MediaElementLogger.LogInformation("Media State Changed. Old State: {PreviousState}, New State: {NewState}", e.PreviousState, e.NewState);

    void OnMediaFailed(object? sender, MediaFailedEventArgs e) 
        => MediaElementLogger.LogInformation("Media failed. Error: {ErrorMessage}", e.ErrorMessage);

    void OnMediaEnded(object? sender, EventArgs e) 
        => MediaElementLogger.LogInformation("Media ended.");

    void OnPositionChanged(object? sender, MediaPositionChangedEventArgs e)
    {
        MediaElementLogger.LogInformation("Position changed to {position}", e.Position);
        PositionSlider.Value = e.Position.TotalSeconds;
    }

    void OnSeekCompleted(object? sender, EventArgs e) 
        => MediaElementLogger.LogInformation("Seek completed.");

    void OnSpeedMinusClicked(object? sender, EventArgs e)
    {
        if (MediaElement.Speed >= 1)
        {
            MediaElement.Speed -= 1;
        }
    }
    void OnSpeedPlusClicked(object? sender, EventArgs e)
    {
        if (MediaElement.Speed < 10)
        {
            MediaElement.Speed += 1;
        }
    }
    void OnVolumeMinusClicked(object? sender, EventArgs e)
    {
        if (MediaElement.Volume >= 0)
        {
            if (MediaElement.Volume < .1)
            {
                ViewModel.Volume = 0;

                return;
            }

            ViewModel.Volume -= .1;
        }
    }

    void OnVolumePlusClicked(object? sender, EventArgs e)
    {
        if (MediaElement.Volume < 1)
        {
            if (MediaElement.Volume > .9)
            {
                ViewModel.Volume = 1;

                return;
            }

            ViewModel.Volume += .1;
        }
    }

    void OnPlayClicked(object? sender, EventArgs e)
        => MediaElement.Play();


    void OnPauseClicked(object? sender, EventArgs e)
        => MediaElement.Pause();


    void OnStopClicked(object? sender, EventArgs e)
        => MediaElement.Stop();

    void OnMuteClicked(object? sender, EventArgs e)
        => MediaElement.ShouldMute = !MediaElement.ShouldMute;

    void Slider_DragCompleted(object? sender, EventArgs e)
    {
        ArgumentNullException.ThrowIfNull(sender);

        var newValue = ((Slider)sender).Value;
        MediaElement.SeekTo(TimeSpan.FromSeconds(newValue));

        MediaElement.Play();
    }

    void Slider_DragStarted(object sender, EventArgs e)
    {
        MediaElement.Pause();
    }
    #endregion
}