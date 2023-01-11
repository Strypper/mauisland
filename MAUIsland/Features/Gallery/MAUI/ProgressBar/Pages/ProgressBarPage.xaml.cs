namespace MAUIsland;

public class PercentageConverter<T> : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        double _temp = (double)value * 100;
        return $"{_temp:N1}%";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        double _temp = (double)value / 100;
        return $"{_temp:N1}%";
    }
}

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

    private async void button1_Clicked(object sender, EventArgs e)
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
            _progress += 0.003;
            await Task.Delay(1);
            button1.Text = $"{_progress * 100:N1}%";
            progress_bar1.Progress = _progress;
        }

        button1.IsEnabled = true;
        button1.Text = "Load";
        button1.WidthRequest = 60;
    }

    private async void button2_Clicked(object sender, EventArgs e)
    {
        progress_bar2.Progress = 0;
        button2.IsEnabled= false;
        await progress_bar2.ProgressTo(0.999, 5000, Easing.BounceIn);
        button2.IsEnabled= true;
    }
}