using CommunityToolkit.Maui.Core;

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
    string basicDrawingView = "<toolkit:DrawingView\r\n            Lines=\"{Binding MyLines}\"\r\n            LineColor=\"Red\"\r\n            LineWidth=\"5\" />";

    [ObservableProperty]
    string basicDrawingViewCSharp = "using CommunityToolkit.Maui.Views;\r\n\r\nvar drawingView = new DrawingView\r\n{\r\n    Lines = new ObservableCollection<IDrawingLine>(),\r\n    LineColor = Colors.Red,\r\n    LineWidth = 5\r\n};";

    [ObservableProperty]
    string multiLineUsage = "<views:DrawingView\r\n            Lines=\"{Binding MyLines}\"\r\n            IsMultiLineModeEnabled=\"true\"\r\n            ShouldClearOnFinish=\"false\" />";

    [ObservableProperty]
    string multiLineUsageCSharp = "using CommunityToolkit.Maui.Views;\r\n\r\nvar gestureImage = new Image();\r\nvar drawingView = new DrawingView\r\n{\r\n    Lines = new ObservableCollection<IDrawingLine>(),\r\n    IsMultiLineModeEnabled = true,\r\n    ShouldClearOnFinish = false,\r\n};";

    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();
        
    }
    #endregion
}