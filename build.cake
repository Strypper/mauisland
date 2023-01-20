#addin nuget:?package=Cake.FileHelpers&version=6.0.0

var target = Argument("target", "BuiltInControlPage");
var group = Argument("group", "BuiltIn");
var name = Argument("name", "AwesomeControl");
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
    public string ControlDetail => throw new NotImplementedException();
    public string GitHubUrl => $""https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{{ControlName}}"";
    public string DocumentUrl => $""https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{{ControlName}}/?view=net-maui-7.0"";
    public string GroupName => ControlGroupInfo.{group}Controls;
}}");

    Information($"\n>> Generate >> {name}Page.xaml");
    FileWriteText($"{controlFolderPath}/{name}Page.xaml", $@"<?xml version=""1.0"" encoding=""utf-8"" ?>
<app:BasePage 
    xmlns=""http://schemas.microsoft.com/dotnet/2021/maui""
    xmlns:x=""http://schemas.microsoft.com/winfx/2009/xaml""
    xmlns:app=""clr-namespace:MAUIsland""
    x:Class=""MAUIsland.{name}Page""
    x:DataType=""app:{name}PageViewModel""
    Title=""{name}"">
    
    <app:BasePage.Resources>

        <x:String x:Key=""ControlInfo"">
            The .NET Multi-platform App UI (.NET MAUI) {name} displays an animation to show that the application is engaged in a lengthy activity. Unlike ProgressBar, {name} gives no indication of progress.
            The appearance of an {name} is platform-dependent, and the following screenshot shows an {name} on iOS and Android:
        </x:String>

        <x:String x:Key=""PropertiesListHeader"">
            {name} defines the following properties:
        </x:String>

        <x:String x:Key=""PropertiesListFooter"">
            These properties are backed by BindableProperty objects, which means that they can be targets of data bindings, and styled.
        </x:String>

        <x:Array x:Key=""PropertiesItemsSource"" Type=""{"x:Type x:String"}"">
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
            <Frame Style=""{"x:StaticResource DocumentContentFrameStyle"}"">
                <Label Text=""{"x:StaticResource ControlInfo"}"" />
            </Frame>
            <Frame Style=""{"x:StaticResource DocumentContentFrameStyle"}"">
                <CollectionView
                    Footer=""{"x:StaticResource PropertiesListFooter"}""
                    Header=""{"x:StaticResource PropertiesListHeader"}""
                    ItemsSource=""{"x:StaticResource PropertiesItemsSource"}""
                    Style=""{"x:StaticResource PropertiesListStyle"}"" />
            </Frame>
        </VerticalStackLayout>
    </ScrollView>
</app:BasePage>");

    Information($"\n>> Generate >> {name}Page.xaml.cs");
    FileWriteText($"{controlFolderPath}/{name}Page.xaml.cs", $@"namespace MAUIsland;
public partial class {name}Page : IControlPage
{{
    public {name}Page()
    {{
        InitializeComponent();
    }}
}}");

    Information($"\n>> Generate >> {name}PageViewModel.cs");
    FileWriteText($"{controlFolderPath}/{name}PageViewModel.cs", $@"namespace MAUIsland;
public partial class {name}PageViewModel : NavigationAwareBaseViewModel
{{
    public {name}PageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {{
    }}
}}");
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
