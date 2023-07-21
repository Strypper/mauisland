namespace MAUIsland;
public partial class MaterialComboBoxPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public MaterialComboBoxPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string comboBoxXamlCode = "<mdc:ComboBox Style=\"{DynamicResource FilledComboBoxStyle}\">\r\n\t<mdc:ComboBoxItem Text=\"item 1\" />\r\n\t<mdc:ComboBoxItem Text=\"item 2\" />\r\n</mdc:ComboBox>\r\n<mdc:ComboBox Style=\"{DynamicResource OutlinedComboBoxStyle}\">\r\n\t<mdc:ComboBoxItem Text=\"item 1\" />\r\n\t<mdc:ComboBoxItem Text=\"item 2\" />\r\n</mdc:ComboBox>\r\n";
    #endregion

    #region [Overrides]
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