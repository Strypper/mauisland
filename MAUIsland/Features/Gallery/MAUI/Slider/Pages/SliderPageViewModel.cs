namespace MAUIsland;

public partial class SliderPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public SliderPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    string simpleCreateSliderXamlCode = "<Slider />";

    [ObservableProperty]
    string sliderWithCustomColorsXamlCode = "<Slider\r\n                        MaximumTrackColor=\"Red\"\r\n                        MinimumTrackColor=\"Blue\"\r\n                        ThumbColor=\"Green\" />";

    [ObservableProperty]
    string sliderWithCustomThumbImageXamlCode = "<Slider MinimumTrackColor=\"#6e50db\" ThumbImageSource=\"dotnet_bot.png\" />";
    #endregion
}


