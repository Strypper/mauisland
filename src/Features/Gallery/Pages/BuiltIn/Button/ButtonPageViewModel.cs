namespace MAUIsland;

public partial class ButtonPageViewModel : NavigationAwareBaseViewModel
{
	#region [CTor]
	public ButtonPageViewModel(IAppNavigator appNavigator) 
									: base(appNavigator)
	{

	}
	#endregion

	#region [Properties]
	[ObservableProperty]
	bool isEnable = true;

	[ObservableProperty]
	IControlInfo controlInformation;

	[ObservableProperty]
	string standardButtonXamlCode = "<Button Text=\"Standard XAML Button\"\r\n                            VerticalOptions=\"Center\"\r\n                            HorizontalOptions=\"Start\"\r\n                            IsEnabled=\"{x:Binding IsEnable}\"/>";

	[ObservableProperty]
	string rotationButtonXamlCode = "<Button Text=\"MAUI Button Test\"\r\n                        VerticalOptions=\"Center\"\r\n                        HorizontalOptions=\"Center\"\r\n                        BorderColor=\"Black\"\r\n                        BorderWidth=\"2\"\r\n                        BackgroundColor=\"Red\"\r\n                        CharacterSpacing=\"4\"\r\n                        WidthRequest=\"190\"\r\n                        HeightRequest=\"70\"\r\n                        FontSize=\"18\"            \r\n                        FontAttributes=\"Bold\"\r\n                        LineBreakMode=\"WordWrap\"\r\n                        TextColor=\"White\"\r\n                        CornerRadius=\"30\"\r\n                        RotationX=\"10\"\r\n                        RotationY=\"30\"/>";

	[ObservableProperty]
	string buttonsChangedBackgroundGroupXamlCode = "<HorizontalStackLayout Spacing=\"10\">\r\n                <Button Text=\"Green\"\r\n                        TextColor=\"{x:StaticResource White}\"\r\n                        BackgroundColor=\"Green\"/>\r\n\r\n                <Button Text=\"Red\"\r\n                        TextColor=\"{x:StaticResource White}\"\r\n                        BackgroundColor=\"Red\"/>\r\n\r\n                <Button Text=\"Application Primary Color\"\r\n                        TextColor=\"{x:StaticResource White}\"\r\n                        BackgroundColor=\"{x:StaticResource Primary}\"/>\r\n\r\n                <!--This button will be Cyan when in dark mode and Blue when light mode-->\r\n                <Button Text=\"Dark or Light mode color\"\r\n                        TextColor=\"{x:StaticResource Black}\"\r\n                        BackgroundColor=\"{x:AppThemeBinding Dark={x:StaticResource Cyan300Accent}, \r\n                                                            Light={x:StaticResource Blue300Accent}}\"/>\r\n            </HorizontalStackLayout>";

	[ObservableProperty]
	string buttonWithImageXamlCode = "<Frame>\r\n                <Frame.Resources>\r\n                    <FontImageSource x:Key=\"HomeIcon\"\r\n                                     Color=\"{x:StaticResource Primary }\"\r\n                                     FontFamily=\"{x:Static app:FontNames.FluentSystemIconsRegular}\"\r\n                                     Glyph=\"{Static app:FluentUIIcon.Ic_fluent_home_20_regular}\"/>\r\n\r\n                    <FontImageSource x:Key=\"DownloadIcon\"\r\n                                     Color=\"{x:StaticResource Primary }\"\r\n                                     FontFamily=\"{x:Static app:FontNames.FluentSystemIconsRegular}\"\r\n                                     Glyph=\"{Static app:FluentUIIcon.Ic_fluent_arrow_download_20_regular}\"/>\r\n                </Frame.Resources>\r\n\r\n                <HorizontalStackLayout Spacing=\"10\">\r\n                    <Button Text=\"Home\"\r\n                            ImageSource=\"{x:StaticResource HomeIcon}\"/>\r\n\r\n                    <Button Text=\"Download\"\r\n                            ImageSource=\"{x:StaticResource DownloadIcon}\"/>\r\n                </HorizontalStackLayout>\r\n            </Frame>";
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
