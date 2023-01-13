namespace MAUIsland;

public class SyncfusionControlsService : ISyncfusionControlsService
{

    public Task<IEnumerable<ControlInfo>> GetAllControlInfoAsync()
    {
        return Task.Run(() =>
        {
            var controls = new List<ControlInfo>();

            controls.Add(new ControlInfo()
            {
                ControlName = "List View",
                ControlRoute = AppRoutes.SyncfusionListViewPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_swipe_right_24_regular
                },
                ControlDetail = "The Syncfusion .NET MAUI ListView renders set of data items using Maui views or custom templates. Data can easily be grouped, sorted, and filtered.",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/SwipeView",
                DocumentUrl = "https://help.syncfusion.com/maui/listview/overview"
            });

            return controls.AsEnumerable();
        });
    }
}
