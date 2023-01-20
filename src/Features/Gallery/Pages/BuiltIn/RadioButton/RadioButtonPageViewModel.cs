﻿namespace MAUIsland;

public partial class RadioButtonPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public RadioButtonPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string standardRadioButtonXamlCode = "<VerticalStackLayout>\r\n    <RadioButton Content=\"Cat\"\r\n         IsChecked=\"True\"/>\r\n    <RadioButton Content=\"Dog\"/>\r\n    <RadioButton Content=\"Fish/>\r\n    <RadioButton Content=\"Bird\"/>\r\n</VerticalStackLayout>";
    [ObservableProperty]
    string imageRadioButtonXamlCode = "<VerticalStackLayout>\r\n    <VerticalStackLayout.Resources>\r\n        <FontImageSource x:Key= \"Happy\"\r\n                         Color=\"White\"\r\n                         FontFamily=\"{x:Static app:FontNames.FluentSystemIconsRegular}\"\r\n                         Glyph=\"{Static app:FluentUIIcon.Ic_fluent_emoji_28_regular}\"/>\r\n        <FontImageSource x:Key= \"Normal\"\r\n                         Color=\"White\"\r\n                         FontFamily=\"{x:Static app:FontNames.FluentSystemIconsRegular}\"\r\n                         Glyph=\"{Static app:FluentUIIcon.Ic_fluent_emoji_smile_slight_24_regular}\"/>\r\n        <FontImageSource x:Key=\"Sad\"\r\n                         Color=\"White\"\r\n                         FontFamily=\"{x:Static app:FontNames.FluentSystemIconsRegular}\"\r\n                         Glyph=\"{Static app:FluentUIIcon.Ic_fluent_emoji_sad_24_regular}\"/>\r\n    </VerticalStackLayout.Resources>\r\n    <RadioButton IsChecked=\"True\">\r\n        <RadioButton.Content>\r\n            <Image WidthRequest=\"30\" \r\n                   HorizontalOptions=\"Start\"\r\n                   VerticalOptions=\"Center\"\r\n                   Source=\"{x:StaticResource Happy}\"/>\r\n        </RadioButton.Content>\r\n    </RadioButton>\r\n    <RadioButton>\r\n        <RadioButton.Content>\r\n            <Image WidthRequest= \"30\" \r\n                   HorizontalOptions=\"Start\"\r\n                   VerticalOptions=\"Center\"\r\n                   Source=\"{x:StaticResource Normal}\"/>\r\n        </RadioButton.Content>\r\n    </RadioButton>\r\n    <RadioButton>\r\n        <RadioButton.Content>\r\n            <Image WidthRequest=\"30\" \r\n                   HorizontalOptions=\"Start\"\r\n                   VerticalOptions=\"Center\"\r\n                   Source=\"{x:StaticResource Sad}\"/>\r\n        </RadioButton.Content>\r\n    </RadioButton>\r\n</VerticalStackLayout>";
    [ObservableProperty]
    string customRadioButtonXamlCode = "\n Custom Template \n\n " +
        "<Frame BorderColor=\"Transparent\"\r\n                   BackgroundColor=\"Transparent\"\r\n                   HasShadow=\"False\"\r\n                   WidthRequest=\"80\"\r\n                   HeightRequest=\"60\"\r\n                   HorizontalOptions=\"Center\"\r\n                   VerticalOptions=\"Center\"\r\n                   Margin=\"1\"\r\n                   Padding=\"0\">\r\n                <VisualStateManager.VisualStateGroups>\r\n                    <VisualStateGroupList>\r\n                        <VisualStateGroup x:Name=\"CheckedStates\">\r\n                            <VisualState x:Name=\"Checked\">\r\n                                <VisualState.Setters>\r\n                                    <Setter Property=\"BorderColor\"\r\n                                            Value=\"#ffffff\" />\r\n                                    <Setter TargetName=\"check\"\r\n                                            Property=\"Opacity\"\r\n                                            Value=\"1\" />\r\n                                    <Setter TargetName=\"outcheck\"\r\n                                            Property=\"Opacity\"\r\n                                            Value=\"1\" />\r\n                                </VisualState.Setters>\r\n                            </VisualState>\r\n                            <VisualState x:Name=\"Unchecked\">\r\n                                <VisualState.Setters>\r\n                                    <Setter Property=\"BorderColor\"\r\n                                            Value=\"Transparent\" />\r\n                                    <Setter TargetName=\"check\"\r\n                                            Property=\"Opacity\"\r\n                                            Value=\"0\" />\r\n                                    <Setter TargetName=\"outcheck\"\r\n                                            Property=\"Opacity\"\r\n                                            Value=\"0\" />\r\n                                </VisualState.Setters>\r\n                            </VisualState>\r\n                        </VisualStateGroup>\r\n                    </VisualStateGroupList>\r\n                </VisualStateManager.VisualStateGroups>\r\n                <Grid HorizontalOptions=\"Center\"\r\n                      VerticalOptions=\"Center\"\r\n                      Padding=\"0,5,0,5\"\r\n                      WidthRequest=\"80\"\r\n                      HeightRequest=\"60\">\r\n                    <Grid WidthRequest=\"18\"\r\n                          HeightRequest=\"18\"\r\n                          Margin=\"3,0,3,0\"\r\n                          HorizontalOptions=\"End\"\r\n                          VerticalOptions=\"Start\">\r\n                        <Ellipse x:Name=\"outcheck\"\r\n                                 Stroke=\"white\"\r\n                                 Fill=\"#53e6a1\"\r\n                                 WidthRequest=\"18\"\r\n                                 HeightRequest=\"18\"\r\n                                 HorizontalOptions=\"Center\"\r\n                                 VerticalOptions=\"Center\" />\r\n                        <Ellipse x:Name=\"check\"\r\n                                 Fill=\"Black\"\r\n                                 WidthRequest=\"10\"\r\n                                 HeightRequest=\"10\"\r\n                                 HorizontalOptions=\"Center\"\r\n                                 VerticalOptions=\"Center\" />\r\n                    </Grid>\r\n                    <ContentPresenter />\r\n                </Grid>\r\n            </Frame>\r\n        </ControlTemplate>"
        + "\n\n Radio Button \n\n " +
        "<StackLayout Orientation=\"Horizontal\"\r\n             HeightRequest=\"100\"\r\n             Spacing=\"14\">\r\n    <StackLayout.Resources>\r\n        <FontImageSource x:Key= \"Happy\"\r\n                         Color=\"White\"\r\n                         FontFamily=\"{x:Static app:FontNames.FluentSystemIconsRegular}\"\r\n                         Glyph=\"{Static app:FluentUIIcon.Ic_fluent_emoji_28_regular}\"/>\r\n        <FontImageSource x:Key= \"Normal\"\r\n                         Color=\"White\"\r\n                         FontFamily=\"{x:Static app:FontNames.FluentSystemIconsRegular}\"\r\n                         Glyph=\"{Static app:FluentUIIcon.Ic_fluent_emoji_smile_slight_24_regular}\"/>\r\n        <FontImageSource x:Key=\"Sad\"\r\n                         Color=\"White\"\r\n                         FontFamily=\"{x:Static app:FontNames.FluentSystemIconsRegular}\"\r\n                         Glyph=\"{Static app:FluentUIIcon.Ic_fluent_emoji_sad_24_regular}\"/>\r\n    </StackLayout.Resources>\r\n    <RadioButton IsChecked=\"True\"\r\n                 ControlTemplate=\"{StaticResource RadioButtonTemplate}\">\r\n        <RadioButton.Content>\r\n            <StackLayout>\r\n                <Image WidthRequest=\"30\" \r\n                   HorizontalOptions=\"Center\"\r\n                   VerticalOptions=\"Center\"\r\n                   Source=\"{x:StaticResource Happy}\"/>\r\n                <Label Text=\"Happy\" \r\n                       HorizontalOptions=\"Center\"\r\n                       VerticalOptions=\"End\"/>\r\n            </StackLayout>\r\n        </RadioButton.Content>\r\n    </RadioButton>\r\n    <RadioButton ControlTemplate=\"{StaticResource RadioButtonTemplate}\">\r\n        <RadioButton.Content>\r\n            <StackLayout>\r\n                <Image WidthRequest=\"30\" \r\n                   HorizontalOptions=\"Center\"\r\n                   VerticalOptions=\"Center\"\r\n                   Source=\"{x:StaticResource Normal}\"/>\r\n                <Label Text=\"Normal\" \r\n                       HorizontalOptions=\"Center\"\r\n                       VerticalOptions=\"End\"/>\r\n            </StackLayout>\r\n        </RadioButton.Content>\r\n    </RadioButton>\r\n    <RadioButton ControlTemplate=\"{StaticResource RadioButtonTemplate}\">\r\n        <RadioButton.Content>\r\n            <StackLayout>\r\n                <Image WidthRequest=\"30\" \r\n                   HorizontalOptions=\"Center\"\r\n                   VerticalOptions=\"Center\"\r\n                   Source=\"{x:StaticResource Sad}\"/>\r\n                <Label Text=\"Sad\" \r\n                       HorizontalOptions=\"Center\"\r\n                       VerticalOptions=\"End\"/>\r\n            </StackLayout>\r\n        </RadioButton.Content>\r\n    </RadioButton>\r\n</StackLayout>";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion

}
