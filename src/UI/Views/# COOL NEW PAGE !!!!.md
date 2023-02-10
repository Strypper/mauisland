# COOL NEW PAGE !!!!
### Page name: `SfComboBoxPage`

## Contributors

[//]: contributor-faces

<a href="https://github.com/ViperTricks"><img src="https://i.imgur.com/TcJ4QeI.png" title="ViperTricks" width="80" height="80"></a>

[//]: contributor-faces

## Describe your changes

## Have we discussed about this before ? (Please link the discussion link below)

## Added SfComboBox page requirements as following:
- [ ] SfComboBoxPage.xaml
  - [ ] Change the `x:Class` to project namespace standard (ex: `x:Class="MAUIsland.LabelPage"`)?
  - [ ] Include `xmlns:app="clr-namespace:MAUIsland"`?
  - [ ] Change `ContentPage` to `app:BasePage`?
  - [ ] Hook the `x:DataType` to the <Page>ViewModel?
  - [ ] Provide `Padding="10"` to `app:BasePage`?
  - [ ] Provide `ControlInfo` to `app:BasePage.Resources`?
  - [ ] Provide `PropertiesListHeader` to `app:BasePage.Resources`?
  - [ ] Provide `PropertiesListFooter` to `app:BasePage.Resources`?
  - [ ] Provide `PropertyItemsSource` to `app:BasePage.Resources`?
  - [ ] Provide a brief `Control Info` UI ?
    ```xml
       <Frame Style="{x:StaticResource DocumentContentFrameStyle}">
                <Label Text="{x:StaticResource ControlInfo}" />
       </Frame>
    ```
    - [ ] Provide `Properties List` UI ?
    ```xml
       <Frame Style="{x:StaticResource DocumentContentFrameStyle}">
                <CollectionView
                    Footer="{x:StaticResource PropertiesListFooter}"
                    Header="{x:StaticResource PropertiesListHeader}"
                    ItemsSource="{x:StaticResource PropertyItemsSource}"
                    Style="{x:StaticResource PropertiesListStyle}" />
       </Frame>
    ```
- [ ] SfComboBoxPage.xaml.cs
  - [ ] Did you change the `namespace` to project namespace standard `namespace MAUIsland`?
  - [ ] Did you remove inheritance `ContentPage`?
  - [ ] Did you organize everything inside `region`?
  - [ ] Did you change `<Page>ViewModel` into the constructor parmeter?
  - [ ] Did you hook the page binding context to the page view model - `BindingContext = vm;` ?
- [ ] SfComboBoxPageViewModel.cs
  - [ ] Did you inherit the `NavigationAwareBaseViewModel`?
  - [ ] Did you organize everything inside `region`?
  - [ ] Did you modify the constructor like the example we provide?
    ```cs
    #region [CTor]
    public LabelPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion
    ```

## Register SfComboBox page route requirements as following:
- [ ] Did you create now route constant ?
- [ ] Did you register page route in AppShell.xaml.cs ?
- [ ] If the page is one of applciation root route did you register it to AppShell.xaml ?

## Register SfComboBox page services:
- [ ] Did you register the page with the view model in `RegisterPages` ?
- [ ] Did you register all the created services `RegisterServices` ?
