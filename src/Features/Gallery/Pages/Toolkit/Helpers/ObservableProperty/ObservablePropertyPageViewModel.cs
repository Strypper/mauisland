using Bogus.DataSets;

namespace MAUIsland;
public partial class ObservablePropertyPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IControlsService MauiControlsService;
    #endregion

    #region [CTor]
    public ObservablePropertyPageViewModel(
        IAppNavigator appNavigator,
        IControlsService mauiControlsService
    ) : base(appNavigator)
    {
        this.MauiControlsService = mauiControlsService;
    }
    #endregion

    #region [ Build-in Property Setup ]
    public string buildinCode;
    public string BuildinCode
    {
        get => buildinCode;
        set
        {
            if (!EqualityComparer<string>.Default.Equals(buildinCode, value))
            {
                string oldValue = buildinCode;
                OnBuildinCodeChanging(value);
                OnBuildinCodeChanging(oldValue, value);
                OnPropertyChanging();
                buildinCode = value;
                OnBuildinCodeChanged(value);
                OnBuildinCodeChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    partial void OnBuildinCodeChanging(string value);
    partial void OnBuildinCodeChanged(string value);

    partial void OnBuildinCodeChanging(string oldValue, string newValue);
    partial void OnBuildinCodeChanged(string oldValue, string newValue);
    #endregion

    #region [ Community Toolkit Setup ]
    [ObservableProperty]
    string fullName = "FullName";

    [ObservableProperty]
    string toolkitCode;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    private string toolkitNotifyPropertyChanged;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(NotifyCanExecuteChangedCommand))]
    private string toolkitNotifyCanExecuteChanged;

    // To use this one you have to inherit ObservableValidator
    //[ObservableProperty]
    //[NotifyDataErrorInfo]
    //[Required]
    //[MinLength(2)]
    //[MaxLength(4)]
    //private string toolkitNotifyDataErrorInfo;

    [ObservableProperty]
    [NotifyPropertyChangedRecipients]
    private string toolkitNotifyPropertyChangedRecipients;

    #region [ Generated Code ]
    private string generatedCode;
    public string GeneratedCode
    {
        get => generatedCode;
        set => SetProperty(ref generatedCode, value);
    }
    private string generatedNotifyPropertyChanged;
    public string GeneratedNotifyPropertyChanged
    {
        get => generatedNotifyPropertyChanged;
        set
        {
            if (SetProperty(ref generatedNotifyPropertyChanged, value))
            {
                OnPropertyChanged("FullName");
            }
        }
    }
    private string generatedNotifyCanExecuteChanged;
    public string GeneratedNotifyCanExecuteChanged
    {
        get => generatedNotifyCanExecuteChanged;
        set
        {
            if (SetProperty(ref generatedNotifyCanExecuteChanged, value))
            {
                NotifyCanExecuteChangedCommand.NotifyCanExecuteChanged();
            }
        }
    }
    //private string generatedNotifyDataErrorInfo;
    //public string GeneratedNotifyDataErrorInfo
    //{
    //    get => generatedNotifyDataErrorInfo;
    //    set
    //    {
    //        if (SetProperty(ref generatedNotifyDataErrorInfo, value))
    //        {
    //            ValidateProperty(value, "Value2");
    //        }
    //    }
    //}
    private string generatedNotifyPropertyChangedRecipients;
    public string GeneratedNotifyPropertyChangedRecipients
    {
        get => generatedNotifyPropertyChangedRecipients;
        set => SetProperty(ref generatedNotifyPropertyChangedRecipients, value, broadcast: true);
    }
    #endregion
    #endregion

    #region [Properties]
    [ObservableProperty]
    bool isExpanding;

    [ObservableProperty]
    string searchText = string.Empty;

    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    ObservableCollection<IGalleryCardInfo> controlGroupList;

    [ObservableProperty]
    string toolkitObservableProperty =
        "[ObservableProperty]\r\n" +
        "string toolkitCode;";

    [ObservableProperty]
    string toolkitNotifyingDependentProperties =
        "[ObservableProperty]\r\n" +
        "[NotifyPropertyChangedFor(nameof(FullName))]\r\n" +
        "private string toolkitNotifyPropertyChanged;";

    [ObservableProperty]
    string toolkitNotifyingDependentCommands =
        "[ObservableProperty]\r\n" +
        "[NotifyCanExecuteChangedFor(nameof(NotifyCanExecuteChangedCommand))]\r\n" +
        "private string toolkitNotifyCanExecuteChanged;\r\n\r\n" +
        "[RelayCommand]\r\n" +
        "Task<string> NotifyCanExecuteChanged() => Task.FromResult(\"null\");";

    [ObservableProperty]
    string toolkitRequestingPropertyValidation =
        "// To use this one you have to inherit ObservableValidator\r\n" +
        "[ObservableProperty]\r\n" +
        "[NotifyDataErrorInfo]\r\n" +
        "[Required]\r\n" +
        "[MinLength(2)]\r\n" +
        "[MaxLength(4)]\r\n" +
        "private string toolkitNotifyDataErrorInfo;";

    [ObservableProperty]
    string toolkitSendingNotificationMessages =
        "[ObservableProperty]\r\n" +
        "[NotifyPropertyChangedRecipients]\r\n" +
        "private string toolkitNotifyPropertyChangedRecipients;";

    [ObservableProperty]
    string buildinGenerateObservableProperty =
        "private string generatedCode;\r\n" +
        "public string GeneratedCode\r\n" +
        "{\r\n" +
        "     get => generatedCode;\r\n" +
        "     set => SetProperty(ref generatedCode, value);\r\n" +
        "}";

    [ObservableProperty]
    string buildinGenerateNotifyingDependentProperties =
        "private string generatedNotifyPropertyChanged;\r\n" +
        "public string GeneratedNotifyPropertyChanged\r\n" +
        "{\r\n" +
        "     get => generatedNotifyPropertyChanged;\r\n" +
        "     set\r\n" +
        "     {\r\n" +
        "           if (SetProperty(ref generatedNotifyPropertyChanged, value))\r\n" +
        "           {\r\n" +
        "                OnPropertyChanged(\"FullName\");\r\n" +
        "           }\r\n" +
        "     }\r\n" +
        "}";

    [ObservableProperty]
    string buildinGenerateNotifyingDependentCommands =
        "private string generatedNotifyCanExecuteChanged;\r\n" +
        "public string GeneratedNotifyCanExecuteChanged\r\n" +
        "{\r\n" +
        "     get => generatedNotifyCanExecuteChanged;\r\n" +
        "     set\r\n" +
        "     {\r\n" +
        "          if (SetProperty(ref generatedNotifyCanExecuteChanged, value))\r\n" +
        "          {\r\n" +
        "               NotifyCanExecuteChangedCommand.NotifyCanExecuteChanged();\r\n" +
        "          }\r\n" +
        "     }\r\n" +
        "}\r\n\r\n" +
        "[RelayCommand]\r\n" +
        "Task<string> NotifyCanExecuteChanged() => Task.FromResult(\"null\");";

    [ObservableProperty]
    string buildinGenerateRequestingPropertyValidation =
        "private string generatedNotifyDataErrorInfo;\r\n" +
        "public string? GeneratedNotifyDataErrorInfo\r\n" +
        "{\r\n" +
        "     get => generatedNotifyDataErrorInfo;\r\n" +
        "     set\r\n" +
        "     {\r\n" +
        "          if (SetProperty(ref generatedNotifyDataErrorInfo, value))\r\n" +
        "          {\r\n" +
        "               ValidateProperty(value, \"Value2\");\r\n" +
        "          }\r\n" +
        "     }\r\n" +
        "}";

    [ObservableProperty]
    string buildinGenerateSendingNotificationMessages =
        "private string generatedNotifyPropertyChangedRecipients;\r\n" +
        "public string GeneratedNotifyPropertyChangedRecipients\r\n" +
        "{\r\n " +
        "     get => generatedNotifyPropertyChangedRecipients;\r\n" +
        "     set => SetProperty(ref generatedNotifyPropertyChangedRecipients, value, broadcast: true);\r\n" +
        "}";

   [ObservableProperty]
    string buildinCodeSetup = 
        "public string buildinCode;\r\n" +
        "public string BuildinCode\r\n" +
        "{\r\n" +
        "      get => buildinCode;\r\n" +
        "      set\r\n" +
        "      {\r\n" +
        "            if (!EqualityComparer<string>.Default.Equals(buildinCode, value))\r\n" +
        "            {\r\n" +
        "                  string oldValue = buildinCode;\r\n"+
        "                  OnBuildinCodeChanging(value);\r\n" +
        "                  OnBuildinCodeChanging(oldValue, value);\r\n" +
        "                  OnPropertyChanging();\r\n" +
        "                  buildinCode = value;\r\n" +
        "                  OnBuildinCodeChanged(value);\r\n" +
        "                  OnBuildinCodeChanged(oldValue, value);\r\n" +
        "                  OnPropertyChanged();\r\n" +
        "            }\r\n" +
        "      }\r\n" +
        "}\r\n\r\n" +
        "partial void OnBuildinCodeChanging(string value);\r\n" +
        "partial void OnBuildinCodeChanged(string value);\r\n\r\n" +
        "partial void OnBuildinCodeChanging(string oldValue, string newValue);\r\n" +
        "partial void OnBuildinCodeChanged(string oldValue, string newValue);";

    [ObservableProperty]
    string toolkitCodeSetup = 
        "[ObservableProperty]\r\n" +
        "string toolkitCode;";

    [ObservableProperty]
    string buildinCodeUsage =
        "partial void OnBuildinCodeChanged(string oldValue, string newValue)\r\n" +
        "{\r\n" +
        "     //Implement your code here\r\n" +
        "}\r\n" +
        "partial void OnBuildinCodeChanging(string oldValue, string newValue)\r\n" +
        "{\r\n" +
        "     //Implement your code here\r\n" +     
        "}\r\n" +
        "partial void OnBuildinCodeChanged(string value)\r\n" +
        "{\r\n" +
        "     //Implement your code here\r\n" +
        "}\r\n" +
        "partial void OnBuildinCodeChanging(string value)\r\n" +
        "{\r\n" +
        "     //Implement your code here\r\n" +
        "}";

    [ObservableProperty]
    string toolkitCodeUsage =
        "partial void OnToolkitCodeChanged(string oldValue, string newValue)\r\n" +
        "{\r\n" +
        "     //Implement your code here\r\n" +
        "}\r\n" +
        "partial void OnToolkitCodeChanging(string oldValue, string newValue)\r\n" +
        "{\r\n" +
        "     //Implement your code here\r\n" +
        "}\r\n" +
        "partial void OnToolkitCodeChanged(string value)\r\n" +
        "{\r\n" +
        "     //Implement your code here\r\n" +
        "}\r\n" +
        "partial void OnToolkitCodeChanging(string value)\r\n" +
        "{\r\n" +
        "     //Implement your code here\r\n" +
        "}";

    [ObservableProperty]
    string searchingXamlCode =
        "<SearchBar Placeholder=\"Search items...\"\r\n" +
        "           x:Name=\"SearchBar\"\r\n" +
        "           Text=\"{x:Binding SearchText}\"/>";

    [ObservableProperty]
    string searchingCSharpCode = 
        "[ObservableProperty]\r\n" +
        "string searchText = string.Empty;\r\n\r\n" +
        "partial void OnSearchTextChanged(string value)\r\n" +
        "{\r\n" +
        "     SearchCommand.ExecuteAsync(null);\r\n" +
        "}\r\n\r\n" +
        "[RelayCommand]\r\n" +
        "private async Task SearchAsync()\r\n" +
        "{\r\n" +
        "     ControlGroupList.Clear();\r\n\r\n" +
        "     var items = await MauiControlsService.GetControlsAsync(ControlInformation.GroupName);\r\n\r\n" +
        "     foreach (var item in items.Where(x => x.ControlName.ToLower().Contains(SearchText.ToLower())))\r\n" +
        "     {\r\n" +
        "          ControlGroupList.Add(item);\r\n" +
        "     }\r\n" +
        "}";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
        ControlGroupList = new ObservableCollection<IGalleryCardInfo>();
        ControlInformation = query.GetData<IGalleryCardInfo>();

        LoadDataAsync().FireAndForget();
    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    Task<string> NotifyCanExecuteChanged() => Task.FromResult("null");

    [RelayCommand]
    private async Task SearchAsync()
    {
        ControlGroupList.Clear();

        var items = await MauiControlsService.GetControlsAsync(ControlInformation.GroupName);

        foreach (var item in items.Where(x => x.ControlName.ToLower().Contains(SearchText.ToLower())))
        {
            ControlGroupList.Add(item);
        }
    }
    #endregion

    #region [ Methods ]

    partial void OnSearchTextChanged(string value)
    {
        SearchCommand.ExecuteAsync(null);
    }

    #region [ Build-in Testing Methods ]
    partial void OnBuildinCodeChanged(string oldValue, string newValue)
    {
        throw new NotImplementedException();
    }
    partial void OnBuildinCodeChanging(string oldValue, string newValue)
    {
        if (oldValue is not null)
        {
            oldValue = "new";
        }

        if (newValue is not null)
        {
            newValue = "new";
        }
    }
    partial void OnBuildinCodeChanged(string value)
    {
        throw new NotImplementedException();
    }
    partial void OnBuildinCodeChanging(string value)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region [ Toolkit Testing Method ]
    partial void OnToolkitCodeChanged(string oldValue, string newValue)
    {
        throw new NotImplementedException();
    }
    partial void OnToolkitCodeChanging(string oldValue, string newValue)
    {
        if (oldValue is not null)
        {
            oldValue = "new";
        }

        if (newValue is not null)
        {
            newValue = "new";
        }
    }
    partial void OnToolkitCodeChanged(string value)
    {
        throw new NotImplementedException();
    }
    partial void OnToolkitCodeChanging(string value)
    {
        throw new NotImplementedException();
    }
    #endregion
    #endregion

    #region [Data]
    private async Task LoadDataAsync()
    {
        ControlGroupList.Clear();

        var items = await MauiControlsService.GetControlsAsync(ControlInformation.GroupName);

        foreach (var item in items)
        {
            ControlGroupList.Add(item);
        }
        return;
    }
    #endregion
}
