using Syncfusion.Maui.DataGrid;

namespace MAUIsland.Gallery.Syncfusion;
class SfDataGridControlInfo : IControlInfo
{
    public string ControlName => nameof(SfDataGrid);
    public string ControlRoute => typeof(SfDataGridPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_tablet_24_regular
    };
    public string ControlDetail => "The .NET MAUI DataGrid control is used to display and manipulate data in a tabular view. It was built from the ground up to achieve the best possible performance, even when loading large amounts of data.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://help.syncfusion.com/maui/datagrid/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;
}