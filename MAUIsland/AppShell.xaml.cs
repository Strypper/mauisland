namespace MAUIsland;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("galleryPage", typeof(GalleryPage));
		Routing.RegisterRoute("mauiAllControlsPage", typeof(MAUIAllControlsPage));
        Routing.RegisterRoute("collectionViewPage", typeof(CollectionViewPage));
        Routing.RegisterRoute("buttonPage", typeof(ButtonPage));
		Routing.RegisterRoute("imageButtonPage", typeof(ImageButtonPage));
        Routing.RegisterRoute("sliderPage", typeof(SliderPage));
        Routing.RegisterRoute("pickerPage", typeof(PickerPage));
        Routing.RegisterRoute("searchBarPage", typeof(SearchBarPage));
        Routing.RegisterRoute("swipeViewPage", typeof(SwipeViewPage));
        Routing.RegisterRoute("switchPage", typeof(SwitchPage));
        Routing.RegisterRoute("indicatorViewPage", typeof(IndicatorViewPage));
        Routing.RegisterRoute("carouselViewPage", typeof(CarouselViewPage));
        Routing.RegisterRoute("entryPage", typeof(EntryPage));
        Routing.RegisterRoute("timePickerPage", typeof(TimePickerPage));
        Routing.RegisterRoute("stepperPage", typeof(StepperPage));
        Routing.RegisterRoute("checkBoxPage", typeof(CheckBoxPage));
        Routing.RegisterRoute("refreshViewPage", typeof(RefreshViewPage));
        Routing.RegisterRoute("radioButtonPage", typeof(RadioButtonPage));
        Routing.RegisterRoute("progressBarPage", typeof(ProgressBarPage));
        Routing.RegisterRoute("activityIndicatorPage", typeof(ActivityIndicatorPage));
        Routing.RegisterRoute("datePickerPage", typeof(DatePickerPage));
        Routing.RegisterRoute("editorPage", typeof(EditorPage));
		Routing.RegisterRoute("menuBarPage", typeof(MenuBarPage));
	}
}
