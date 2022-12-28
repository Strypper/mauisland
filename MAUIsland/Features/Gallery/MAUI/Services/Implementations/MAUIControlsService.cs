namespace MAUIsland;

public class MAUIControlsService : IMAUIControlsService
{

    public Task<IEnumerable<ControlInfo>> GetAllControlInfoAsync()
    {
        return Task.Run(() =>
        {
            var controls = new List<ControlInfo>();
            controls.Add(new ControlInfo()
            {
                ControlName = "Button",
                ControlRoute = AppRoutes.ButtonPage
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Activity Indicator",
                ControlRoute = AppRoutes.ActivityIndicatorPage
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Editor",
                ControlRoute = AppRoutes.EditorPage
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Date Picker",
                ControlRoute = AppRoutes.DatePickerPage
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Progress Bar",
                ControlRoute = AppRoutes.ProgressBarPage
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Slider",
                ControlRoute = AppRoutes.SliderPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_calendar_3_day_28_regular
                },
                ControlDetail = "Slider is a horizontal bar that you can manipulate to select a double value from a continuous range."
            });

            return controls.AsEnumerable();
        });
    }
}
