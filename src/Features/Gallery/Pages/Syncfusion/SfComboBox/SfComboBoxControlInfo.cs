using Syncfusion.Maui.Inputs;
namespace MAUIsland;
class SfComboBoxControlInfo : IControlInfo
{
    public string ControlName => nameof(SfComboBox);
    public string ControlRoute => typeof(SfComboBoxPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_caret_down_24_regular
    };
    public string ControlDetail => "The .NET MAUI ComboBox control is a selection component that allows users to type a value or choose an option from a list of predefined options. It has many features, such as data binding, editing, searching, clear button and dropdown button customization, and more.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => "https://help.syncfusion.com/maui/combobox/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;
}