using CommunityToolkit.Maui.Views;
using System.Net;

namespace MAUIsland;
public partial class MediaElementPage : IControlPage
{
    #region [ Fields ]

    string videoUrl = "https://petaversestorageaccount.blob.core.windows.net/petaverse-petvideos/Taking a dumb 💩";
    string localFilePath = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "video.mp4");
    #endregion

    #region [CTor]
    public MediaElementPage(MediaElementPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

    #region [ Event Handlers ]

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        if (File.Exists(localFilePath))
        {
            mediaElementDownloadSample.Source = MediaSource.FromFile(localFilePath);
        }
        else
        {
            CheckFileLabel.Text = $"Nah bro";
        }
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
                mediaElementDownloadSample.Source = MediaSource.FromFile(localFilePath);
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
            CheckFileLabel.Text = $"Nah bro";
        }
    }

    private void DeleteLocalVideoButton_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(localFilePath))
        {
            File.Delete(localFilePath);
        }
        else
        {
            CheckFileLabel.Text = $"Nah bro";
        }
    }
    #endregion
}