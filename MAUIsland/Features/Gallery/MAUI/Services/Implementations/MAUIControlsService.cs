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



            return controls.AsEnumerable();
        });
    }
}
