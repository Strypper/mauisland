namespace MAUIsland.Gallery.BuiltIn;

class ImageButtonControlInfo : IControlInfo
{
    public string ControlName => nameof(ImageButton);
    public string ControlRoute => typeof(ImageButtonPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_image_add_24_regular
    };
    public string ControlDetail => "ImageButton view combines the Button view and Image view to create a button whose content is an image. When you press the ImageButton with a finger or click it with a mouse, it directs the app to carry out a task. However, unlike the Button the ImageButton view has no concept of text and text appearance.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}
