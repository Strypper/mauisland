namespace MAUIsland.Gallery.BuiltIn;

class PickerControlInfo : IControlInfo
{
    public string ControlName => nameof(Picker);
    public string ControlRoute => typeof(PickerPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_time_picker_24_regular
    };
    public string ControlDetail => "Picker displays a short list of items, from which the user can select an item.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}
