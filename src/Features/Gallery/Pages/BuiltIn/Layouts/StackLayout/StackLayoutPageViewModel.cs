namespace MAUIsland;
public partial class StackLayoutPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public StackLayoutPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string verticalOrientationXamlCode = "<StackLayout Margin=\"20\">\r\n                        <Label Text=\"Primary colors\" />\r\n                        <BoxView HeightRequest=\"40\" Color=\"Red\" />\r\n                        <BoxView HeightRequest=\"40\" Color=\"Yellow\" />\r\n                        <BoxView HeightRequest=\"40\" Color=\"Blue\" />\r\n                        <Label Text=\"Secondary colors\" />\r\n                        <BoxView HeightRequest=\"40\" Color=\"Green\" />\r\n                        <BoxView HeightRequest=\"40\" Color=\"Orange\" />\r\n                        <BoxView HeightRequest=\"40\" Color=\"Purple\" />\r\n                    </StackLayout>";

    [ObservableProperty]
    string verticalOrientationCSharpCode = "public class VerticalStackLayoutPage : ContentPage\r\n{\r\n    public VerticalStackLayoutPage()\r\n    {\r\n        Title = \"Vertical StackLayout demo\";\r\n\r\n        StackLayout stackLayout = new StackLayout { Margin = new Thickness(20) };\r\n\r\n        stackLayout.Add(new Label { Text = \"Primary colors\" });\r\n        stackLayout.Add(new BoxView { Color = Colors.Red, HeightRequest = 40 });\r\n        stackLayout.Add(new BoxView { Color = Colors.Yellow, HeightRequest = 40 });\r\n        stackLayout.Add(new BoxView { Color = Colors.Blue, HeightRequest = 40 });\r\n        stackLayout.Add(new Label { Text = \"Secondary colors\" });\r\n        stackLayout.Add(new BoxView { Color = Colors.Green, HeightRequest = 40 });\r\n        stackLayout.Add(new BoxView { Color = Colors.Orange, HeightRequest = 40 });\r\n        stackLayout.Add(new BoxView { Color = Colors.Purple, HeightRequest = 40 });\r\n\r\n        Content = stackLayout;\r\n    }\r\n}";

    [ObservableProperty]
    string horizontalOrientationXamlCode = "<StackLayout\r\n                Margin=\"20\"\r\n                HorizontalOptions=\"Center\"\r\n                Orientation=\"Horizontal\">\r\n                <BoxView WidthRequest=\"40\" Color=\"Red\" />\r\n                <BoxView WidthRequest=\"40\" Color=\"Yellow\" />\r\n                <BoxView WidthRequest=\"40\" Color=\"Blue\" />\r\n                <BoxView WidthRequest=\"40\" Color=\"Green\" />\r\n                <BoxView WidthRequest=\"40\" Color=\"Orange\" />\r\n                <BoxView WidthRequest=\"40\" Color=\"Purple\" />\r\n            </StackLayout>";

    [ObservableProperty]
    string horizontalOrientationCSharpCode = "public class HorizontalStackLayoutPage : ContentPage\r\n{\r\n    public HorizontalStackLayoutPage()\r\n    {\r\n        Title = \"Horizontal StackLayout demo\";\r\n\r\n        StackLayout stackLayout = new StackLayout\r\n        {\r\n            Margin = new Thickness(20),\r\n            Orientation = StackOrientation.Horizontal,\r\n            HorizontalOptions = LayoutOptions.Center\r\n        };\r\n\r\n        stackLayout.Add(new BoxView { Color = Colors.Red, HeightRequest=\"120\", WidthRequest = 120 });\r\n        stackLayout.Add(new BoxView { Color = Colors.Yellow, HeightRequest=\"120\", WidthRequest = 120 });\r\n        stackLayout.Add(new BoxView { Color = Colors.Blue, HeightRequest=\"120\", WidthRequest = 120 });\r\n        stackLayout.Add(new BoxView { Color = Colors.Green, HeightRequest=\"120\", WidthRequest = 120 });\r\n        stackLayout.Add(new BoxView { Color = Colors.Orange, HeightRequest=\"120\", WidthRequest = 120 });\r\n        stackLayout.Add(new BoxView { Color = Colors.Purple, HeightRequest=\"120\", WidthRequest = 120 });\r\n\r\n        Content = stackLayout;\r\n    }\r\n}";

    [ObservableProperty]
    string spaceBetweenChildViewsXamlCode = "<StackLayout Margin=\"20\" Spacing=\"8\">\r\n                        <Label Text=\"Primary colors\" />\r\n                        <BoxView HeightRequest=\"40\" Color=\"Red\" />\r\n                        <BoxView HeightRequest=\"40\" Color=\"Yellow\" />\r\n                        <BoxView HeightRequest=\"40\" Color=\"Blue\" />\r\n                        <Label Text=\"Secondary colors\" />\r\n                        <BoxView HeightRequest=\"40\" Color=\"Green\" />\r\n                        <BoxView HeightRequest=\"40\" Color=\"Orange\" />\r\n                        <BoxView HeightRequest=\"40\" Color=\"Purple\" />\r\n                    </StackLayout>";

    [ObservableProperty]
    string spaceBetweenChildViewsCSharpCode = "public class StackLayoutSpacingPage : ContentPage\r\n{\r\n    public StackLayoutSpacingPage()\r\n    {\r\n        Title = \"StackLayout Spacing demo\";\r\n\r\n        StackLayout stackLayout = new StackLayout\r\n        {\r\n            Margin = new Thickness(20),\r\n            Spacing = 8\r\n        };\r\n\r\n        stackLayout.Add(new Label { Text = \"Primary colors\" });\r\n        stackLayout.Add(new BoxView { Color = Colors.Red, HeightRequest = 40 });\r\n        stackLayout.Add(new BoxView { Color = Colors.Yellow, HeightRequest = 40 });\r\n        stackLayout.Add(new BoxView { Color = Colors.Blue, HeightRequest = 40 });\r\n        stackLayout.Add(new Label { Text = \"Secondary colors\" });\r\n        stackLayout.Add(new BoxView { Color = Colors.Green, HeightRequest = 40 });\r\n        stackLayout.Add(new BoxView { Color = Colors.Orange, HeightRequest = 40 });\r\n        stackLayout.Add(new BoxView { Color = Colors.Purple, HeightRequest = 40 });\r\n\r\n        Content = stackLayout;\r\n    }\r\n}";

    [ObservableProperty]
    string positionAndSizeOfChildViewsXamlCode = "<StackLayout Margin=\"20\"\r\n                 Spacing=\"6\">\r\n        <Label Text=\"Start\"\r\n               BackgroundColor=\"Gray\"\r\n               HorizontalOptions=\"Start\" />\r\n        <Label Text=\"Center\"\r\n               BackgroundColor=\"Gray\"\r\n               HorizontalOptions=\"Center\" />\r\n        <Label Text=\"End\"\r\n               BackgroundColor=\"Gray\"\r\n               HorizontalOptions=\"End\" />\r\n        <Label Text=\"Fill\"\r\n               BackgroundColor=\"Gray\"\r\n               HorizontalOptions=\"Fill\" />\r\n    </StackLayout>";

    [ObservableProperty]
    string positionAndSizeOfChildViewsCSharpCode = "public class AlignmentPage : ContentPage\r\n{\r\n    public AlignmentPage()\r\n    {\r\n        Title = \"Alignment demo\";\r\n\r\n        StackLayout stackLayout = new StackLayout\r\n        {\r\n            Margin = new Thickness(20),\r\n            Spacing = 6\r\n        };\r\n\r\n        stackLayout.Add(new Label { Text = \"Start\", BackgroundColor = Colors.Gray, HorizontalOptions = LayoutOptions.Start });\r\n        stackLayout.Add(new Label { Text = \"Center\", BackgroundColor = Colors.Gray, HorizontalOptions = LayoutOptions.Center });\r\n        stackLayout.Add(new Label { Text = \"End\", BackgroundColor = Colors.Gray, HorizontalOptions = LayoutOptions.End });\r\n        stackLayout.Add(new Label { Text = \"Fill\", BackgroundColor = Colors.Gray, HorizontalOptions = LayoutOptions.Fill });\r\n\r\n        Content = stackLayout;\r\n    }\r\n}";

    [ObservableProperty]
    string nestedStackLayoutObjectsXamlCode = "<StackLayout Margin=\"20\" Spacing=\"8\">\r\n                        <Label Text=\"Primary colors\" />\r\n                        <Frame Padding=\"8\" BorderColor=\"white\">\r\n                            <StackLayout Orientation=\"Horizontal\" Spacing=\"15\">\r\n                                <BoxView WidthRequest=\"40\" Color=\"Red\" />\r\n                                <Label\r\n                                    FontSize=\"18\"\r\n                                    Text=\"Red\"\r\n                                    VerticalOptions=\"Center\" />\r\n                            </StackLayout>\r\n                        </Frame>\r\n                        <Frame Padding=\"8\" BorderColor=\"white\">\r\n                            <StackLayout Orientation=\"Horizontal\" Spacing=\"15\">\r\n                                <BoxView WidthRequest=\"40\" Color=\"Yellow\" />\r\n                                <Label\r\n                                    FontSize=\"18\"\r\n                                    Text=\"Yellow\"\r\n                                    VerticalOptions=\"Center\" />\r\n                            </StackLayout>\r\n                        </Frame>\r\n                        <Frame Padding=\"8\" BorderColor=\"white\">\r\n                            <StackLayout Orientation=\"Horizontal\" Spacing=\"15\">\r\n                                <BoxView WidthRequest=\"40\" Color=\"Blue\" />\r\n                                <Label\r\n                                    FontSize=\"18\"\r\n                                    Text=\"Blue\"\r\n                                    VerticalOptions=\"Center\" />\r\n                            </StackLayout>\r\n                        </Frame>\r\n                    </StackLayout>\r\n                    <StackLayout Margin=\"20\" Spacing=\"8\">\r\n                        <Label Text=\"Secondary colors\" />\r\n                        <Frame Padding=\"8\" BorderColor=\"white\">\r\n                            <StackLayout Orientation=\"Horizontal\" Spacing=\"15\">\r\n                                <BoxView WidthRequest=\"40\" Color=\"Green\" />\r\n                                <Label\r\n                                    FontSize=\"18\"\r\n                                    Text=\"Green\"\r\n                                    VerticalOptions=\"Center\" />\r\n                            </StackLayout>\r\n                        </Frame>\r\n                        <Frame Padding=\"8\" BorderColor=\"white\">\r\n                            <StackLayout Orientation=\"Horizontal\" Spacing=\"15\">\r\n                                <BoxView WidthRequest=\"40\" Color=\"Orange\" />\r\n                                <Label\r\n                                    FontSize=\"18\"\r\n                                    Text=\"Orange\"\r\n                                    VerticalOptions=\"Center\" />\r\n                            </StackLayout>\r\n                        </Frame>\r\n                        <Frame Padding=\"8\" BorderColor=\"white\">\r\n                            <StackLayout Orientation=\"Horizontal\" Spacing=\"15\">\r\n                                <BoxView WidthRequest=\"40\" Color=\"Purple\" />\r\n                                <Label\r\n                                    FontSize=\"18\"\r\n                                    Text=\"Purple\"\r\n                                    VerticalOptions=\"Center\" />\r\n                            </StackLayout>\r\n                        </Frame>\r\n                    </StackLayout>";

    [ObservableProperty]
    string nestedStackLayoutObjectCSharpCode = "public class CombinedStackLayoutPage : ContentPage\r\n{\r\n    public CombinedStackLayoutPage()\r\n    {\r\n        Title = \"Combined StackLayouts demo\";\r\n\r\n        Frame frame1 = new Frame\r\n        {\r\n            BorderColor = Colors.Black,\r\n            Padding = new Thickness(5)\r\n        };\r\n        StackLayout frame1StackLayout = new StackLayout\r\n        {\r\n            Orientation = StackOrientation.Horizontal,\r\n            Spacing = 15\r\n        };\r\n        frame1StackLayout.Add(new BoxView { Color = Colors.Red, WidthRequest = 40 });\r\n        frame1StackLayout.Add(new Label { Text = \"Red\", FontSize = 22, VerticalOptions = LayoutOptions.Center });\r\n        frame1.Content = frame1StackLayout;\r\n\r\n        Frame frame2 = new Frame\r\n        {\r\n            BorderColor = Colors.Black,\r\n            Padding = new Thickness(5)\r\n        };\r\n        StackLayout frame2StackLayout = new StackLayout\r\n        {\r\n            Orientation = StackOrientation.Horizontal,\r\n            Spacing = 15\r\n        };\r\n        frame2StackLayout.Add(new BoxView { Color = Colors.Yellow, WidthRequest = 40 });\r\n        frame2StackLayout.Add(new Label { Text = \"Yellow\", FontSize = 22, VerticalOptions = LayoutOptions.Center });\r\n        frame2.Content = frame2StackLayout;\r\n\r\n        Frame frame3 = new Frame\r\n        {\r\n            BorderColor = Colors.Black,\r\n            Padding = new Thickness(5)\r\n        };\r\n        StackLayout frame3StackLayout = new StackLayout\r\n        {\r\n            Orientation = StackOrientation.Horizontal,\r\n            Spacing = 15\r\n        };\r\n        frame3StackLayout.Add(new BoxView { Color = Colors.Blue, WidthRequest = 40 });\r\n        frame3StackLayout.Add(new Label { Text = \"Blue\", FontSize = 22, VerticalOptions = LayoutOptions.Center });\r\n        frame3.Content = frame3StackLayout;\r\n\r\n        ...\r\n\r\n        StackLayout stackLayout = new StackLayout { Margin = new Thickness(20) };\r\n        stackLayout.Add(new Label { Text = \"Primary colors\" });\r\n        stackLayout.Add(frame1);\r\n        stackLayout.Add(frame2);\r\n        stackLayout.Add(frame3);\r\n        stackLayout.Add(new Label { Text = \"Secondary colors\" });\r\n        stackLayout.Add(frame4);\r\n        stackLayout.Add(frame5);\r\n        stackLayout.Add(frame6);\r\n\r\n        Content = stackLayout;\r\n    }\r\n}";

    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}