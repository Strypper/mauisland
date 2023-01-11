namespace MAUIsland;

public partial class ProgressBarPage
{
    double _progress = 0;

    #region [CTor]
    public ProgressBarPage(ProgressBarPageViewModel vm)
    {
        InitializeComponent();
        BindingContext= vm;
    }
    #endregion

    private async void Button_Clicked(object sender, EventArgs e)
    {

        button1.IsEnabled = false;
        button1.WidthRequest = 80;

        await runProgressBar();
    }

    async Task runProgressBar()
    {
        _progress = 0;

        while (_progress < 1)
        {
            _progress += 0.002;
            await Task.Delay(1);
            button1.Text = $"{_progress * 100:N1}%";
            progress_bar1.Progress = _progress;
        }

        button1.IsEnabled = true;
        button1.Text = "Load";
        button1.WidthRequest = 60;
    }
}