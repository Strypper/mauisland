namespace MAUIsland;
public partial class AppSettingsJsonPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public AppSettingsJsonPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string appSettingsJsonContent = "{\r\n  \"Settings\": {\r\n    \"KeyOne\": 1,\r\n    \"KeyTwo\": true,\r\n    \"KeyThree\": {\r\n      \"Message\": \"Oh, that's nice...\"\r\n    }\r\n  }\r\n}";

    [ObservableProperty]
    string appSettingsCSharpClasses = "public class Settings\r\n{\r\n\tpublic int KeyOne { get; set; }\r\n\tpublic bool KeyTwo { get; set; }\r\n\tpublic NestedSettings KeyThree { get; set; } = null!;\r\n}\r\n\r\npublic class NestedSettings\r\n{\r\n\tpublic string Message { get; set; } = null!;\r\n}";

    [ObservableProperty]
    string packageReferencesCode = "<ItemGroup>\r\n    <PackageReference Include=\"Microsoft.Extensions.Configuration.Binder\" Version=\"6.0.0\" />\r\n    <PackageReference Include=\"Microsoft.Extensions.Configuration.Json\" Version=\"6.0.0\" />\r\n</ItemGroup>";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion
}