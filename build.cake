#addin nuget:?package=Cake.FileHelpers&version=6.0.0

var target = Argument("target", "BuiltInControlPage");
var group = Argument("group", "BuiltIn");
var name = Argument("name", "AwesomeControl");
var cardDetail = Argument("cardDetail", "CardDetail");
var originalDocumentUrl = Argument("originalDocumentUrl", "DocumentLink");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

const string CONTROL_FODLER_PATH_TEMPLATE="./src/Features/Gallery/Pages/{0}/{1}";

Task("BuiltInControlPage")
    .Does(() =>
{
    var controlFolderPath = string.Format(CONTROL_FODLER_PATH_TEMPLATE, group, name);
    Information("Control folder path: " + controlFolderPath);
    
    if (DirectoryExists(controlFolderPath)) {
        Warning("Control folder path exists");
        return;
    }

    CreateDirectory(controlFolderPath);

    Information($"\n>> Generate >> {name}ControlInfo.cs");
    FileWriteText($"{controlFolderPath}/{name}ControlInfo.cs", $@"namespace MAUIsland.Gallery.{group};
class {name}ControlInfo : IControlInfo 
{{
    public string ControlName => nameof({name});
    public string ControlRoute => typeof({name}Page).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {{
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    }};
    public string ControlDetail => ""{cardDetail}"";
    public string GitHubUrl => $""https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/{group}/{{ControlName}}"";
    public string DocumentUrl => $""{originalDocumentUrl}"";
    public string GroupName => ControlGroupInfo.{group}Controls;
}}");

    Information($"\n>> Generate >> {name}Page.xaml");
    FileWriteText($"{controlFolderPath}/{name}Page.xaml", $@"<?xml version=""1.0"" encoding=""utf-8"" ?>
<app:BasePage 
    xmlns=""http://schemas.microsoft.com/dotnet/2021/maui""
    xmlns:x=""http://schemas.microsoft.com/winfx/2009/xaml""
    xmlns:app=""clr-namespace:MAUIsland""
    Padding=""10""
    x:Class=""MAUIsland.{name}Page""
    x:DataType=""app:{name}PageViewModel""
    Title=""{name}"">

    <app:BasePage.ToolbarItems>
        <ToolbarItem
            Command=""{{x:Binding OpenUrlCommand}}""
            CommandParameter=""{{x:Binding ControlInformation.GitHubUrl}}""
            IconImageSource=""github.png""
            Text=""Source code"" />
        <ToolbarItem
            Command=""{{x:Binding OpenUrlCommand}}""
            CommandParameter=""{{x:Binding ControlInformation.DocumentUrl}}""
            IconImageSource=""microsoft.png""
            Text=""Original Document"" />
    </app:BasePage.ToolbarItems>
    
    <app:BasePage.Resources>

        <x:String x:Key=""PropertiesListHeader"">
            {name} defines the following properties:
        </x:String>

        <x:String x:Key=""PropertiesListFooter"">
            These properties are backed by BindableProperty objects, which means that they can be targets of data bindings, and styled.
        </x:String>

        <x:Array x:Key=""PropertiesItemsSource"" Type=""{{x:Type x:String}}"">
            <x:String>
                <![CDATA[
                                <strong style=""color:blue"">Color</strong>, of type <strong style=""color:blue"">Color </strong>, value that defines the color of the ActivityIndicator.
                            ]]>
            </x:String>
            <x:String>
                <![CDATA[
                                <strong style=""color:blue"">IsRunning</strong>, of type <strong style=""color:blue"">bool</strong>,value that indicates whether the ActivityIndicator should be visible and animating, or hidden. The default value of this property is false, which indicates that the ActivityIndicator isn't visible.
                            ]]>
            </x:String>
        </x:Array>


    </app:BasePage.Resources>

    <ScrollView>
        <VerticalStackLayout Spacing=""20"">
            <Frame Style=""{{x:StaticResource DocumentContentFrameStyle}}"">
                <Label Text=""{{x:Binding ControlInformation.ControlDetail}}"" />
            </Frame>
            <Frame Style=""{{x:StaticResource DocumentContentFrameStyle}}"">
                <CollectionView
                    Footer=""{{x:StaticResource PropertiesListFooter}}""
                    Header=""{{x:StaticResource PropertiesListHeader}}""
                    ItemsSource=""{{x:StaticResource PropertiesItemsSource}}""
                    Style=""{{x:StaticResource PropertiesListStyle}}"" />
            </Frame>
        </VerticalStackLayout>
    </ScrollView>
</app:BasePage>");

    Information($"\n>> Generate >> {name}Page.xaml.cs");
    FileWriteText($"{controlFolderPath}/{name}Page.xaml.cs", $@"namespace MAUIsland;
public partial class {name}Page : IControlPage
{{
    #region [CTor]
    public {name}Page({name}PageViewModel vm)
    {{
        InitializeComponent();

        BindingContext = vm;
    }}
    #endregion
}}");

    Information($"\n>> Generate >> {name}PageViewModel.cs");
    FileWriteText($"{controlFolderPath}/{name}PageViewModel.cs", $@"namespace MAUIsland;
public partial class {name}PageViewModel : NavigationAwareBaseViewModel
{{
    #region [CTor]
    public {name}PageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {{
    }}
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {{
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

    }}
    #endregion
}}");
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
