#addin nuget:?package=Cake.FileHelpers&version=6.0.0

var target = Argument("target", "Default");
var group = Argument("group", "BuiltIn");
var name = Argument("name", "AwesomeControl");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

const string CONTROL_FODLER_PATH_TEMPLATE="./src/Features/Gallery/Pages/{0}/{1}";

Task("Default")
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
    public string GitHubUrl => $""https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{{ControlName}}"";
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
    <VerticalStackLayout>
        <Label 
            Text=""Welcome to {name} Page!""
            VerticalOptions=""Center"" 
            HorizontalOptions=""Center"" />
    </VerticalStackLayout>
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
