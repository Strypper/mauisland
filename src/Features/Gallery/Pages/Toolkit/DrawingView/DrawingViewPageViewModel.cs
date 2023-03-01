namespace MAUIsland;
public partial class DrawingViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public DrawingViewPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string basicDrawingViewXamlCode = "<toolkit:DrawingView\r\n            Lines=\"{Binding MyLines}\"\r\n            LineColor=\"Red\"\r\n            LineWidth=\"5\" />";

    [ObservableProperty]
    string basicDrawingViewCSharpCode = "using CommunityToolkit.Maui.Views;\r\n\r\nvar drawingView = new DrawingView\r\n{\r\n    Lines = new ObservableCollection<IDrawingLine>(),\r\n    LineColor = Colors.Red,\r\n    LineWidth = 5\r\n};";

    [ObservableProperty]
    string multiLineUsageXamlCode = "<views:DrawingView\r\n            Lines=\"{Binding MyLines}\"\r\n            IsMultiLineModeEnabled=\"true\"\r\n            ShouldClearOnFinish=\"false\" />";

    [ObservableProperty]
    string multiLineUsageCSharpCode = "using CommunityToolkit.Maui.Views;\r\n\r\nvar gestureImage = new Image();\r\nvar drawingView = new DrawingView\r\n{\r\n    Lines = new ObservableCollection<IDrawingLine>(),\r\n    IsMultiLineModeEnabled = true,\r\n    ShouldClearOnFinish = false,\r\n};";

    [ObservableProperty]
    string drawingLineCompletedXamlCode = "<views:DrawingView\r\n            Lines=\"{Binding MyLines}\"\r\n            DrawingLineCompletedCommand=\"{Binding DrawingLineCompletedCommand}\"\r\n            DrawingLineCompleted=\"OnDrawingLineCompletedEvent\" />";

    [ObservableProperty]
    string drawingLineCompletedCSharpCode = "using CommunityToolkit.Maui.Views;\r\n\r\nvar gestureImage = new Image();\r\nvar drawingView = new DrawingView\r\n{\r\n    Lines = new ObservableCollection<IDrawingLine>(),\r\n    DrawingLineCompletedCommand = new Command<IDrawingLine>(async (line) =>\r\n    {\r\n        var stream = await line.GetImageStream(gestureImage.Width, gestureImage.Height, Colors.Gray.AsPaint());\r\n        gestureImage.Source = ImageSource.FromStream(() => stream);\r\n    })\r\n};\r\ndrawingView.DrawingLineCompleted += async (s, e) =>\r\n{\r\n    var stream = await e.LastDrawingLine.GetImageStream(gestureImage.Width, gestureImage.Height, Colors.Gray.AsPaint());\r\n    gestureImage.Source = ImageSource.FromStream(() => stream);\r\n};";

    [ObservableProperty]
    string advancedUsageXamlCode = "<toolkit:DrawingView\r\n            x:Name=\"DrawingViewControl\"\r\n            Lines=\"{Binding MyLines}\"\r\n            IsMultiLineModeEnabled=\"true\"\r\n            ShouldClearOnFinish=\"true\"\r\n            DrawingLineCompletedCommand=\"{Binding DrawingLineCompletedCommand}\"\r\n            DrawingLineCompleted=\"OnDrawingLineCompletedEvent\"\r\n            LineColor=\"Red\"\r\n            LineWidth=\"5\"\r\n            HorizontalOptions=\"FillAndExpand\"\r\n            VerticalOptions=\"FillAndExpand\">\r\n            <toolkit:DrawingView.Background>\r\n                    <LinearGradientBrush StartPoint=\"0,0\"\r\n                                         EndPoint=\"0,1\">\r\n                        <GradientStop Color=\"Blue\"\r\n                                      Offset=\"0\"/>\r\n                        <GradientStop Color=\"Yellow\"\r\n                                      Offset=\"1\"/>\r\n                    </LinearGradientBrush>\r\n            </toolkit:DrawingView.Background>\r\n</toolkit:DrawingView>";

    [ObservableProperty]
    string advancedUsageCSharpCode = "using CommunityToolkit.Maui.Views;\r\n\r\nvar gestureImage = new Image();\r\nvar drawingView = new DrawingView\r\n{\r\n    Lines = new ObservableCollection<IDrawingLine>(),\r\n    IsMultiLineModeEnabled = true,\r\n    ShouldClearOnFinish = false,\r\n    DrawingLineCompletedCommand = new Command<IDrawingLine>(async (line) =>\r\n    {\r\n        var stream = await line.GetImageStream(gestureImage.Width, gestureImage.Height, Colors.Gray.AsPaint());\r\n        gestureImage.Source = ImageSource.FromStream(() => stream);\r\n    }),\r\n    LineColor = Colors.Red,\r\n    LineWidth = 5,\r\n    Background = Brush.Red\r\n};\r\ndrawingView.DrawingLineCompleted += async (s, e) =>\r\n{\r\n    var stream = await e.LastDrawingLine.GetImageStream(gestureImage.Width, gestureImage.Height, Colors.Gray.AsPaint());\r\n    gestureImage.Source = ImageSource.FromStream(() => stream);\r\n};\r\n\r\n// get stream from lines collection\r\nvar lines = new List<IDrawingLine>();\r\nvar stream1 = await DrawingView.GetImageStream(\r\n                lines,\r\n                new Size(gestureImage.Width, gestureImage.Height),\r\n                Colors.Black);\r\n\r\n// get steam from the current DrawingView\r\nvar stream2 = await drawingView.GetImageStream(gestureImage.Width, gestureImage.Height);";

    [ObservableProperty]
    string customIDrawingLineCSharpCode1 = "public class MyDrawingLine : IDrawingLine\r\n{\r\n    public ObservableCollection<PointF> Points { get; } = new();\r\n    ...\r\n}";

    [ObservableProperty]
    string customIDrawingLineCSharpCode2 = "public class MyDrawingLineAdapter : IDrawingLineAdapter\r\n{\r\n    public IDrawingLine(MauiDrawingLine mauiDrawingLine)\r\n    {\r\n        return new MyDrawingLine\r\n        {\r\n            Points = mauiDrawingLine.Points,\r\n            ...\r\n        }\r\n    }\r\n}";

    [ObservableProperty]
    string customIDrawingLineCSharpCode3 = "var myDrawingLineAdapter = new MyDrawingLineAdapter();\r\ndrawingViewHandler.SetDrawingLineAdapter(myDrawingLineAdapter);";
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