namespace MAUIsland;


public partial class ProgressBarPage : IGalleryPage
{
    private double progress;
    public double Progress
    {
        get { return progress; }
        set { progress = value; }
    }

    #region [ CTor ]

    public ProgressBarPage(ProgressBarPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    #endregion

    #region [ Event Handlers ]


    private async void ProgressBarLoadButtonClicked(object sender, EventArgs e)
    {
        Progress = 0;

        while (Progress < 1)
        {
            if (Progress == 0)
            {
                ProgressBar1.ProgressColor = Colors.Red;
            }
            Progress += 0.01;
            await Task.Delay(1);
            var progressIntValue = Progress * 100;
            ProgressLabel.Text = $"{progressIntValue:N1}%";
            switch ((int)progressIntValue)
            {
                case 30:
                    ProgressBar1.ProgressColor = Colors.OrangeRed;
                    break;
                case 50:
                    ProgressBar1.ProgressColor = Colors.Orange;
                    break;
                case 80:
                    ProgressBar1.ProgressColor = Colors.Yellow;
                    break;
                case 90:
                    ProgressBar1.ProgressColor = Colors.YellowGreen;
                    break;
                case 100:
                    ProgressBar1.ProgressColor = Colors.Green;
                    break;
            }
            ProgressBar1.Progress = Progress;
        }
    }

    private async void ProgressBarRunButtonClicked(object sender, EventArgs e)
    {
        ProgressBar2.Progress = 0;
        ProgressBarRunButton.IsEnabled = false;
        await ProgressBar2.ProgressTo(0.999, 5000, Easing.BounceIn);
        ProgressBarRunButton.IsEnabled = true;
    }
    #endregion
}