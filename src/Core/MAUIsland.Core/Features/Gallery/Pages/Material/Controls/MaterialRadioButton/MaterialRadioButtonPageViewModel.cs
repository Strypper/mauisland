namespace MAUIsland.Core;
public partial class MaterialRadioButtonPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public MaterialRadioButtonPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    IGalleryCardInfo controlInformation = default!;

    [ObservableProperty]
    string radioButtonXamlCode = "<mdc:RadioButton Orientation=\"Horizontal\">\r\n                        <mdc:RadioItem Text=\"item 1\" />\r\n                        <mdc:RadioItem Text=\"item 2\" />\r\n                        <mdc:RadioItem Text=\"item 3\" />\r\n                    </mdc:RadioButton>\r\n                    <mdc:RadioButton Orientation=\"Vertical\">\r\n                        <mdc:RadioItem Text=\"item 1\" />\r\n                        <mdc:RadioItem Text=\"item 2\" />\r\n                        <mdc:RadioItem Text=\"item 3\" />\r\n                    </mdc:RadioButton>";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);
    #endregion
}