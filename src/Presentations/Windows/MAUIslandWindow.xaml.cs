using MAUIsland.Settings;

namespace MAUIsland;

public partial class MAUIslandWindow : Window
{
    #region [ Fields ]

    private readonly SettingsPageViewModel viewModel;
    #endregion

    #region [ CTors ]

    public MAUIslandWindow(SettingsPageViewModel vm)
    {
        InitializeComponent();

        this.BindingContext = viewModel = vm;
        _titleBar = this.TitleBar as TitleBar;
        _titleBar.Icon = "mauisland_logo.png";
        InitTitleBarTrail();
    }
    #endregion

    #region [ Properties ]

    TitleBar? _titleBar;
    #endregion

    #region [ Methods ]

    void InitTitleBarTrail()
    {
        if (_titleBar is null)
            return;

        _titleBar.TrailingContent = new ImageButton()
        {
            CornerRadius = 20,
            Margin = new() { Bottom = 2, Top = 2, Left = 2, Right = 2 },
            Source = new FontImageSource()
            {
                FontFamily = FontNames.FluentSystemIconsRegular,
                Size = 24,
                Glyph = FluentUIIcon.Ic_fluent_settings_48_regular
            },
            Command = viewModel.NavigateCommand,
            CommandParameter = AppRoutes.SettingsPage
        };
    }
    #endregion
}