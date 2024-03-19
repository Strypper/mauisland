using Syncfusion.Maui.Data;

namespace MAUIsland;

public partial class RelayCommandPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IControlsService MauiControlsService;
    #endregion

    #region [CTor]
    public RelayCommandPageViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    ObservableCollection<IGalleryCardInfo> controlGroupList;

    [ObservableProperty]
    string toolkitRelayCommand =
        "[RelayCommand]\r\n" +
        "private void ToolKit()\r\n" +
        "   => RelayCommand();\r\n\r\n" +
        "private void RelayCommand()\r\n" +
        "   => Console.WriteLine(\"RelayCommand!\");";

    [ObservableProperty]
    string toolkitRelayCommandWithParameter = 
        "[RelayCommand]\r\n" +
        "private void ToolKitWithParameter(string value)\r\n" +
        "   => RelayCommandWithParameter(value);\r\n\r\n" +
        "private void RelayCommandWithParameter(string value) \r\n" +
        "   => Console.WriteLine($\"RelayCommand {value}!\");";

    [ObservableProperty]
    string toolkitRelayCommandWithAsynchronous =
        "[RelayCommand]\r\n" +
        "private async Task ToolKitWithAsynchronous(string value)\r\n" +
        "   => await RelayCommandithAsynchronous();\r\n\r\n" +
        "private async Task RelayCommandithAsynchronous() \r\n" +
        "   => await LoadDataAsync();";

    [ObservableProperty]
    string toolkitControlPropertyState1 =
        "[ObservableProperty]\r\n" +
        "[NotifyCanExecuteChangedFor(nameof(ToolKitWithEnablingDisablingCommand))]\r\n" +
        "private string exampleForControlPropertyState1 = \"Hello\";";

    [ObservableProperty]
    string toolkitControlPropertyState2 =
        "[ObservableProperty]\r\n" +
        "[NotifyCanExecuteChangedFor(nameof(ToolKitWithEnablingDisablingCommand))]\r\n" +
        "private string exampleForControlPropertyStateCommand;";

    [ObservableProperty]
    string example1BoundPropertyToControlXaml =
    "<Button Text=\"Example Property For Control Property State Command\"\r\n" +
    "        Command=\"{Binding ToolKitWithEnablingDisablingCommand}\"\r\n" +
    "        CommandParameter=\"{Binding ExampleForControlPropertyState1}\"/>";

    [ObservableProperty]
    string example2BoundPropertyToControlXaml =
    "<Button Text=\"Example Property For Control Property State Command\"\r\n" +
    "        Command=\"{Binding ToolKitWithEnablingDisablingCommand}\"\r\n" +
    "        CommandParameter=\"{Binding ExampleForControlPropertyState2}\"/>";

    [ObservableProperty]
    string toolkitRelayCommandWithEnablingDisabling =
        "[RelayCommand(CanExecute = nameof(CanExecuteMethod))]\r\n" +
        "private void ToolKitWithEnablingDisabling(string value)\r\n" +
        "   => RelayCommandWithEnablingDisabling(value);\r\n\r\n" +
        "private void RelayCommandWithEnablingDisabling(string value) \r\n" +
        "   => Console.WriteLine($\"RelayCommand {value}!\");\r\n\r\n" +
        "private bool CanExecuteMethod(string value) \r\n" +
        "   => value is not null;";

    [ObservableProperty]
    string toolkitRelayCommandWithAllowConcurrentExecution = 
        "[RelayCommand(AllowConcurrentExecutions = true)]\r\n" +
        "private async Task ToolKitWithAllowConcurrentExecution()\r\n" +
        "   => await RelayCommandithAsynchronous();";

    [ObservableProperty]
    string toolkitRelayCommandWithExceptionDefault = 
        "[RelayCommand]\r\n" +
        "private async Task ToolKitWithHandlingAsyncExceptionDefault(CancellationToken token)\r\n" +
        "{\r\n" +
        "     try { await RelayCommandithAsynchronous(); }\r\n" +
        "     catch (Exception ex) { Console.WriteLine($\"An error occurred: {ex.Message}\"); }\r\n" +
        "}";

    [ObservableProperty]
    string toolkitRelayCommandWithExceptionScheduler = 
        "[RelayCommand(FlowExceptionsToTaskScheduler = true)]\r\n" +
        "private async Task ToolKitWithHandlingAsyncExceptionScheduler(CancellationToken token)\r\n" +
        "{\r\n" +
        "     try { await RelayCommandithAsynchronous(); }\r\n" +
        "     catch (Exception ex) { Console.WriteLine($\"An error occurred: {ex.Message}\"); }\r\n" +
        "}";

    [ObservableProperty]
    string toolkitRelayCommandWithCancel = 
        "[RelayCommand(IncludeCancelCommand = true)]\r\n" +
        "private async Task ToolKitAsyncWithCancel(CancellationToken token)\r\n" +
        "   => await RelayCommandAsyncWithCancel(token);";

    [ObservableProperty]
    string buildinGenerate =
        "private RelayCommand? buildinGenerateCommand;\r\n" +
        "public IRelayCommand BuildinGenerateCommand\r\n" +
        "   => buildinGenerateCommand ??= new RelayCommand(RelayCommand);" +
        "private void RelayCommand()\r\n" +
        "   => Console.WriteLine(\"RelayCommand!\");";

    [ObservableProperty]
    string buildinGenerateCommandWithParameter =
        "private RelayCommand<string>? buildinGenerateWithParameter;\r\n" +
        "public IRelayCommand<string> BuildinGenerateCommandWithParameter \r\n" +
        "   => buildinGenerateWithParameter ??= new RelayCommand<string>(RelayCommandWithParameter);\r\n\r\n" +
        "private void RelayCommandWithParameter(string value) \r\n" +
        "   => Console.WriteLine($\"RelayCommand {value}!\");";

    [ObservableProperty]
    string buildinGenerateCommandWithAsynchronous = 
        "private AsyncRelayCommand? buildinGenerateWithAsynchronous;\r\n" +
        "public IAsyncRelayCommand BuildinGenerateWithAsynchronous \r\n" +
        "   => buildinGenerateWithAsynchronous ??= new AsyncRelayCommand(RelayCommandithAsynchronous);\r\n\r\n" +
        "private async Task RelayCommandithAsynchronous() \r\n" +
        "   => await LoadDataAsync();";

    [ObservableProperty]
    string buildinGenerateCommandWithEnablingDisabling =
        "private RelayCommand<string>? buildinGenerateWithEnablingDisabling;\r\n" +
        "public ICommand BuildinGenerateWithEnablingDisabling\r\n" +
        "   => buildinGenerateWithEnablingDisabling ??= new RelayCommand<string>(RelayCommandWithEnablingDisabling, CanExecuteMethod);\r\n\r\n" +
        "private void RelayCommandWithEnablingDisabling(string value) \r\n" +
        "   => Console.WriteLine($\"RelayCommand {value}!\");\r\n\r\n" +
        "private bool CanExecuteMethod(string value) \r\n" +
        "   => value is not null;";

    [ObservableProperty]
    string buildinEquivalentCommandWithCancel = 
        "private AsyncRelayCommand<CancellationToken>? buildinCancel;\r\n" +
        "public IAsyncRelayCommand BuildinCancel\r\n" +
        "   => buildinCancel ??= new AsyncRelayCommand<CancellationToken>(RelayCommandAsyncWithCancel);\r\n" +
        "private RelayCommand buildinAsyncWithCancelCommand;\r\n" +
        "public ICommand BuildinAsyncWithCancelCommand\r\n" +
        "   => buildinAsyncWithCancelCommand ??= new RelayCommand(() => buildinCancel?.Cancel());";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
        ControlGroupList = new ObservableCollection<IGalleryCardInfo>();
        ControlInformation = query.GetData<IGalleryCardInfo>();
    }
    #endregion

    #region [ Example Properties ]
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ToolKitWithEnablingDisablingCommand))]
    private string exampleForControlPropertyState1 = "Hello";

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ToolKitWithEnablingDisablingCommand))]
    private string exampleForControlPropertyState2;
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion

    #region [ Build-in Relay Commands ]
    private RelayCommand? buildinGenerateCommand;
    public IRelayCommand BuildinGenerateCommand 
        => buildinGenerateCommand ??= new RelayCommand(RelayCommand);

    private RelayCommand<string>? buildinGenerateWithParameter;
    public IRelayCommand<string> BuildinGenerateWithParameter 
        => buildinGenerateWithParameter ??= new RelayCommand<string>(RelayCommandWithParameter);

    private AsyncRelayCommand? buildinGenerateWithAsynchronous;
    public IAsyncRelayCommand BuildinGenerateWithAsynchronous 
        => buildinGenerateWithAsynchronous ??= new AsyncRelayCommand(RelayCommandithAsynchronous);

    private RelayCommand<string>? buildinGenerateWithEnablingDisabling;
    public ICommand BuildinGenerateWithEnablingDisabling
        => buildinGenerateWithEnablingDisabling ??= new RelayCommand<string>(RelayCommandWithEnablingDisabling, CanExecuteMethod);

    private AsyncRelayCommand<CancellationToken>? buildinCancel;
    public IAsyncRelayCommand BuildinCancel
        => buildinCancel ??= new AsyncRelayCommand<CancellationToken>(RelayCommandAsyncWithCancel);
    private RelayCommand buildinAsyncWithCancelCommand;
    public ICommand BuildinAsyncWithCancelCommand
        => buildinAsyncWithCancelCommand ??= new RelayCommand(() => buildinCancel?.Cancel());
    #endregion

    #region [ ToolKit Relay Commands ]
    [RelayCommand]
    private void ToolKit() => RelayCommand();

    [RelayCommand]
    private void ToolKitWithParameter(string value)
        => RelayCommandWithParameter(value);

    [RelayCommand]
    private async Task ToolKitWithAsynchronous(string value)
        => await RelayCommandithAsynchronous();

    [RelayCommand(CanExecute = nameof(CanExecuteMethod))]
    private void ToolKitWithEnablingDisabling(string value)
        => RelayCommandWithEnablingDisabling(value);

    [RelayCommand(AllowConcurrentExecutions = true)]
    private async Task ToolKitWithAllowConcurrentExecution()
        => await RelayCommandithAsynchronous();

    [RelayCommand]
    private async Task ToolKitWithHandlingAsyncExceptionDefault(CancellationToken token)
    {
        try { await RelayCommandithAsynchronous(); }
        catch (Exception ex) { Console.WriteLine($"An error occurred: {ex.Message}"); }
    }

    [RelayCommand(FlowExceptionsToTaskScheduler = true)]
    private async Task ToolKitWithHandlingAsyncExceptionScheduler(CancellationToken token)
    {
        try { await RelayCommandithAsynchronous(); }
        catch (Exception ex) { Console.WriteLine($"An error occurred: {ex.Message}"); }
    }

    [RelayCommand(IncludeCancelCommand = true)]
    private async Task ToolKitAsyncWithCancel(CancellationToken token)
        => await RelayCommandAsyncWithCancel(token);
    #endregion

    #region [ Methods ]
    private void RelayCommand() 
        => Console.WriteLine("RelayCommand!");

    private void RelayCommandWithParameter(string value) 
        => Console.WriteLine($"RelayCommand {value}!");

    private async Task RelayCommandithAsynchronous() 
        => await LoadDataAsync();

    private bool CanExecuteMethod(string value) 
        => value is not null;

    private void RelayCommandWithEnablingDisabling(string value) 
        => Console.WriteLine($"RelayCommand {value}!");

    private async Task RelayCommandAsyncWithCancel(CancellationToken token)
    {
        try
        {
            await LoadDataAsync();
        }
        catch (OperationCanceledException) { }
    }
    #endregion

    #region [Data]
    private async Task LoadDataAsync()
    {
        try
        {
            ControlGroupList.Clear();

            var items = await MauiControlsService.GetControlsAsync(ControlInformation.GroupName);

            items.ForEach(item =>
            {
                ControlGroupList.Add(item);
            });
            return;
        }
        catch (OperationCanceledException) { }
    }
    #endregion
}
