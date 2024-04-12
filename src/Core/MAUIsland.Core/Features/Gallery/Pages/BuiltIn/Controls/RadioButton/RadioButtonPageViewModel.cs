using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class RadioButtonPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public RadioButtonPageViewModel(IAppNavigator appNavigator,
                                    IGitHubService gitHubService,
                                    IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                    : base(appNavigator,
                                            gitHubService,
                                            gitHubIssueLocalDbService)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string transportGroupName = "TransportGroup";

    [ObservableProperty]
    string selectedTransportItem = string.Empty;

    [ObservableProperty]
    string standardRadioButtonXamlCode =
        "<!--Without GroupName-->\r\n" +
        "<HorizontalStackLayout>\r\n" +
        "   <RadioButton Content=\"Cat\" IsChecked=\"True\" />\r\n" +
        "   <RadioButton Content=\"Dog\" />\r\n" +
        "   <RadioButton Content=\"Fish\" />\r\n" +
        "   <RadioButton Content=\"Bird\" />\r\n" +
        "</HorizontalStackLayout>\r\n" +
        "<!--With GroupName-->\r\n" +
        "<HorizontalStackLayout>\r\n" +
        "   <RadioButton GroupName=\"Transport\" Content=\"Car\" IsChecked=\"True\"/>\r\n" +
        "   <RadioButton GroupName=\"Transport\" Content=\"Bike\" />\r\n" +
        "   <RadioButton GroupName=\"Transport\" Content=\"Motocrycle\" />\r\n" +
        "</HorizontalStackLayout>\r\n" +
        "<HorizontalStackLayout>\r\n" +
        "   <RadioButton GroupName=\"Transport\" Content=\"Bus\" />\r\n" +
        "   <RadioButton GroupName=\"Transport\" Content=\"Train\" />\r\n" +
        "   <RadioButton GroupName=\"Transport\" Content=\"Walking\" />\r\n" +
        "</HorizontalStackLayout>\r\n" +
        "<!--With GroupName in parent-->\r\n" +
        "<HorizontalStackLayout RadioButtonGroup.GroupName=\"Transport\">\r\n" +
        "   <RadioButton Content=\"Rock\" IsChecked=\"True\"/>\r\n" +
        "   <RadioButton Content=\"Pop\" />\r\n" +
        "   <RadioButton Content=\"Jazz\" />\r\n" +
        "</HorizontalStackLayout>\r\n" +
        "<HorizontalStackLayout RadioButtonGroup.GroupName=\"Transport\">\r\n" +
        "   <RadioButton Content=\"Classical\" />\r\n" +
        "   <RadioButton Content=\"Country\" />\r\n" +
        "   <RadioButton Content=\"Hip Hop\" />\r\n" +
        "</HorizontalStackLayout>";

    [ObservableProperty]
    string xamlImageRadioButtonStaticResource =
        "<ContentPage.Resources>\r\n" +
        "   <FontImageSource x:Key=\"Happy\"\r\n" +
        "                    FontFamily=\"{x:Static core:FontNames.FluentSystemIconsRegular}\"\r\n" +
        "                    Glyph=\"{Static core:FluentUIIcon.Ic_fluent_emoji_28_regular}\"\r\n" +
        "                    Color=\"Black\"\r\n" +
        "                    Size=\"100\"/>\r\n" +
        "   <FontImageSource x:Key=\"Normal\" \r\n" +
        "                    FontFamily=\"{x:Static core:FontNames.FluentSystemIconsRegular}\"\r\n" +
        "                    Glyph=\"{Static core:FluentUIIcon.Ic_fluent_emoji_smile_slight_24_regular}\"\r\n" +
        "                    Color=\"Black\" \r\n" +
        "                    Size=\"100\"/>\r\n" +
        "   <FontImageSource x:Key=\"Sad\" \r\n" +
        "                    FontFamily=\"{x:Static core:FontNames.FluentSystemIconsRegular}\"\r\n" +
        "                    Glyph=\"{Static core:FluentUIIcon.Ic_fluent_emoji_sad_24_regular}\"\r\n" +
        "                    Color=\"Black\" \r\n" +
        "                    Size=\"100\"/>\r\n" +
        "</ContentPage.Resources>";

    [ObservableProperty]
    string xamlImageRadioButton =
        "<VerticalStackLayout>\r\n" +
        "   <RadioButton IsChecked=\"True\" BackgroundColor=\"White\" CornerRadius=\"5\">\r\n" +
        "       <RadioButton.Content>\r\n" +
        "           <ContentView Padding=\"5,0,5,0\">\r\n" +
        "               <Image Source=\"{x:StaticResource Happy}\" WidthRequest=\"30\"/>\r\n" +
        "           </ContentView>\r\n" +
        "       </RadioButton.Content>\r\n" +
        "   </RadioButton>\r\n" +
        "   <RadioButton BackgroundColor=\"White\" CornerRadius=\"5\">\r\n" +
        "       <RadioButton.Content>\r\n" +
        "           <ContentView Padding=\"5,0,5,0\">\r\n" +
        "               <Image Source=\"{x:StaticResource Normal}\" WidthRequest=\"30\"/>\r\n" +
        "           </ContentView>\r\n" +
        "       </RadioButton.Content>\r\n" +
        "   </RadioButton>\r\n" +
        "   <RadioButton BackgroundColor=\"White\" CornerRadius=\"5\">\r\n" +
        "       <RadioButton.Content>\r\n" +
        "           <ContentView Padding=\"5,0,5,0\">\r\n" +
        "               <Image Source=\"{x:StaticResource Sad}\" WidthRequest=\"30\"/>\r\n" +
        "           </ContentView>\r\n" +
        "       </RadioButton.Content>\r\n" +
        "   </RadioButton>\r\n" +
        "</VerticalStackLayout>";

    [ObservableProperty]
    string xamlRadioButtonState =
        "<HorizontalStackLayout RadioButtonGroup.GroupName=\"{x:Binding TransportGroupName}\"\r\n" +
        "                       RadioButtonGroup.SelectedValue=\"{x:Binding SelectedTransportItem}\">\r\n" +
        "   <RadioButton Content=\"Car\" Value=\"Car\"\r\n" +
        "                GroupName=\"{x:Binding TransportGroupName}\"\r\n" +
        "                IsChecked=\"True\"/>\r\n" +
        "   <RadioButton Content=\"Bike\" Value=\"Bike\"\r\n" +
        "                GroupName=\"{x:Binding TransportGroupName}\"/>\r\n" +
        "   <RadioButton Content=\"Train\" Value=\"Train\"\r\n" +
        "                GroupName=\"{x:Binding TransportGroupName}\"/>\r\n" +
        "   <RadioButton Content=\"Walking\" Value=\"Walking\"\r\n" +
        "                GroupName=\"{x:Binding TransportGroupName}\"/>\r\n" +
        "</HorizontalStackLayout>\r\n" +
        "<Label x:Name=\"Label\">\r\n" +
        "   <Label.FormattedText>\r\n" +
        "       <FormattedString>\r\n" +
        "           <Span Text=\"You have chosen: \" />\r\n" +
        "           <Span Text=\"{x:Binding SelectedTransportItem}\" />\r\n" +
        "       </FormattedString>\r\n" +
        "   </Label.FormattedText>\r\n" +
        "</Label>";

    [ObservableProperty]
    string cSharpRadioButtonState =
        "[ObservableProperty]\r\n" +
        "string transportGroupName = \"TransportGroup\";\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "string selectedTransportItem = string.Empty;";

    [ObservableProperty]
    string xamlRadioButtonVisualStateStyle =
        "<ContentPage.Resources>\r\n" +
        "   <Style x:Key=\"RadioButtonStyle\" TargetType=\"RadioButton\">\r\n" +
        "       <Setter Property=\"VisualStateManager.VisualStateGroups\">\r\n" +
        "           <VisualStateGroupList>\r\n" +
        "               <VisualStateGroup x:Name=\"CheckedStates\">\r\n" +
        "                   <VisualState x:Name=\"Checked\">\r\n" +
        "                       <VisualState.Setters>\r\n" +
        "                           <Setter Property=\"TextColor\" Value=\"Green\" />\r\n" +
        "                           <Setter Property=\"Opacity\" Value=\"1\" />\r\n" +
        "                       </VisualState.Setters>\r\n" +
        "                   </VisualState>\r\n" +
        "                   <VisualState x:Name=\"Unchecked\">\r\n" +
        "                       <VisualState.Setters>\r\n" +
        "                           <Setter Property=\"TextColor\" Value=\"OrangeRed\" />\r\n" +
        "                           <Setter Property=\"Opacity\" Value=\"0.5\" />\r\n" +
        "                       </VisualState.Setters>\r\n" +
        "                   </VisualState>\r\n" +
        "               </VisualStateGroup>\r\n" +
        "           </VisualStateGroupList>\r\n" +
        "       </Setter>\r\n" +
        "   </Style>\r\n" +
        "</ContentPage.Resources>";

    [ObservableProperty]
    string xamlRadioButtonVisualStates =
        "<HorizontalStackLayout>\r\n" +
        "   <RadioButton Style=\"{x:StaticResource RadioButtonStyle}\" Content=\"Car\" IsChecked=\"True\"/>\r\n" +
        "   <RadioButton Style=\"{x:StaticResource RadioButtonStyle}\" Content=\"Bike\" />\r\n" +
        "   <RadioButton Style=\"{x:StaticResource RadioButtonStyle}\" Content=\"Train\" />\r\n" +
        "   <RadioButton Style=\"{x:StaticResource RadioButtonStyle}\" Content=\"Walking\" />\r\n" +
        "</HorizontalStackLayout>";

    [ObservableProperty]
    string xamlCustomRadioButton =
        "<HorizontalStackLayout x:Name=\"EmotionalRadioButtonGroupWithCustomTemplate\"\r\n" +
        "                       RadioButtonGroup.GroupName=\"Emotional\"\r\n" +
        "                       Spacing=\"20\">\r\n" +
        "   <RadioButton ControlTemplate=\"{x:StaticResource RadioButtonTemplate}\" IsChecked=\"True\">\r\n" +
        "       <RadioButton.Content>\r\n" +
        "           <VerticalStackLayout>\r\n" +
        "               <Image Source=\"{x:StaticResource Happy}\" />\r\n" +
        "               <Label Text=\"Happy\" \r\n" +
        "                      TextColor=\"Black\"/>\r\n" +
        "           </VerticalStackLayout>\r\n" +
        "       </RadioButton.Content>\r\n" +
        "   </RadioButton>\r\n" +
        "   <RadioButton ControlTemplate=\"{x:StaticResource RadioButtonTemplate}\">\r\n" +
        "       <RadioButton.Content>\r\n" +
        "           <VerticalStackLayout>\r\n" +
        "               <Image Source=\"{x:StaticResource Normal}\" />\r\n" +
        "               <Label Text=\"Normal\" \r\n" +
        "                      TextColor=\"Black\"/>\r\n" +
        "           </VerticalStackLayout>\r\n" +
        "       </RadioButton.Content>\r\n" +
        "   </RadioButton>\r\n" +
        "   <RadioButton ControlTemplate=\"{x:StaticResource RadioButtonTemplate}\">\r\n" +
        "       <RadioButton.Content>\r\n" +
        "           <VerticalStackLayout>\r\n" +
        "               <Image Source=\"{x:StaticResource Sad}\" />\r\n" +
        "               <Label Text=\"Sad\" \r\n" +
        "                      TextColor=\"Black\"/>\r\n" +
        "           </VerticalStackLayout>\r\n" +
        "       </RadioButton.Content>\r\n" +
        "   </RadioButton>\r\n" +
        "</HorizontalStackLayout>";

    [ObservableProperty]
    string xamlCustomRadioButtonControlTemplate =
        "<ContentPage.Resources>\r\n" +
        "   <ControlTemplate x:Key=\"RadioButtonTemplate\">\r\n" +
        "       <Border Stroke=\"#F3F2F1\"\r\n" +
        "               StrokeThickness=\"2\"\r\n" +
        "               StrokeShape=\"RoundRectangle 10\"\r\n" +
        "               BackgroundColor=\"#F3F2F1\"\r\n" +
        "               HorizontalOptions=\"FillAndExpand\"\r\n" +
        "               VerticalOptions=\"FillAndExpand\"\r\n" +
        "               Padding=\"5\">\r\n" +
        "           <Grid HorizontalOptions=\"CenterAndExpand\"\r\n" +
        "                 VerticalOptions=\"CenterAndExpand\">\r\n" +
        "               <Grid HeightRequest=\"20\"\r\n" +
        "                     WidthRequest=\"20\" \r\n" +
        "                     HorizontalOptions=\"End\"\r\n" +
        "                     VerticalOptions=\"End\">\r\n" +
        "                   <Ellipse x:Name=\"Outcheck\"\r\n" +
        "                            Fill=\"#53e6a1\"\r\n" +
        "                            HeightRequest=\"20\" \r\n" +
        "                            WidthRequest=\"20\" \r\n" +
        "                            HorizontalOptions=\"Center\"\r\n" +
        "                            VerticalOptions=\"Center\"\r\n" +
        "                            Stroke=\"white\"/>\r\n" +
        "                   <Ellipse x:Name=\"Check\"\r\n" +
        "                            Fill=\"Black\"\r\n" +
        "                            HeightRequest=\"10\"\r\n" +
        "                            WidthRequest=\"10\" \r\n" +
        "                            HorizontalOptions=\"Center\"\r\n" +
        "                            VerticalOptions=\"Center\"/>\r\n" +
        "               </Grid>\r\n" +
        "               <ContentPresenter />\r\n" +
        "           </Grid>\r\n" +
        "           <VisualStateManager.VisualStateGroups>\r\n" +
        "               <VisualStateGroupList>\r\n" +
        "                   <VisualStateGroup x:Name=\"CheckedStates\">\r\n" +
        "                       <VisualState x:Name=\"Checked\">\r\n" +
        "                           <VisualState.Setters>\r\n" +
        "                               <Setter Property=\"Stroke\" Value=\"#ffffff\" />\r\n" +
        "                               <Setter TargetName=\"Check\" Property=\"Opacity\" Value=\"1\" />\r\n" +
        "                               <Setter TargetName=\"Outcheck\" Property=\"Opacity\" Value=\"1\" />\r\n" +
        "                           </VisualState.Setters>\r\n" +
        "                       </VisualState>\r\n" +
        "                       <VisualState x:Name=\"Unchecked\">\r\n" +
        "                           <VisualState.Setters>\r\n" +
        "                               <Setter Property=\"Stroke\" Value=\"Transparent\" />\r\n" +
        "                               <Setter TargetName=\"Check\" Property=\"Opacity\" Value=\"0\" />\r\n" +
        "                               <Setter TargetName=\"Outcheck\" Property=\"Opacity\" Value=\"0\" />\r\n" +
        "                           </VisualState.Setters>\r\n" +
        "                       </VisualState>\r\n" +
        "                   </VisualStateGroup>\r\n" +
        "               </VisualStateGroupList>\r\n" +
        "           </VisualStateManager.VisualStateGroups>\r\n" +
        "       </Border>\r\n" +
        "   </ControlTemplate>\r\n" +
        "</ContentPage.Resources>";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();

    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
        await RefreshAsync();
    }
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    Task OpenSnackBar(string message)
    => AppNavigator.ShowSnackbarAsync(message);


    [RelayCommand]
    async Task RefreshAsync()
    {

        if (ControlInformation is null)
            return;

        await RefreshControlIssues(true,
                                   ControlInformation.ControlName,
                                   ControlInformation.GitHubAuthorIssueName,
                                   ControlInformation.GitHubRepositoryIssueName,
                                   ControlInformation.GitHubIssueLabels);
    }

    #endregion

}
