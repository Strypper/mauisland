namespace MAUIsland.Home;

public class HomeService : IHomeService
{
    #region [ Fields ]

    private readonly IControlsService mauiControlsService;
    #endregion

    #region [ CTor ]

    public HomeService(IControlsService mauiControlsService)
    {
        this.mauiControlsService = mauiControlsService;
    }
    #endregion

    #region [ Methods ]

    public async Task<IEnumerable<ApplicationNew>> GetApplicationNews()
    {
        return await Task.Run(async () =>
        {
            var activites = new List<ApplicationNew>();

            var controlGroups = await mauiControlsService.GetControlGroupsAsync();

            string issuesListNews = "Every control and layout now comes with an included GitHub Issues List, enabling quick tracking of issues related to the control or layout you are exploring on the official MAUI repository.";

            string mauiToolkitNews = "The .NET MAUI Community Toolkit now include 4 new controls, 9 converters and 3 layouts";

            string repoCachedNews = "The Community gallery has been cached locally to provide a faster and more responsive experience when browsing controls and layouts. This cache is updated every 1 hours to ensure you have the latest information available.";

            string materialUINews = "The Material Component group has been added to MAUIsland with 9 controls to explore";

            activites.Add(new ApplicationNew()
            {
                Title = "Issues List",
                AuthorName = "Strypper",
                AuthorImageUrl = "https://i.imgur.com/vc9FudE.jpg",
                SecondImage = "dotnet_bot.png",
                Activity = NewActivity.AddFeature,
                NewLog = issuesListNews,
                Date = new DateTime(2024, 3, 22),
                NewsRoute = AppRoutes.CardsByGroupPage,
                Arg = controlGroups.FirstOrDefault(x => x.Name == ControlGroupInfo.BuiltInControls)
            });

            activites.Add(new ApplicationNew()
            {
                Title = "Community Toolkit",
                AuthorName = "Long",
                AuthorImageUrl = "member_long.png",
                SecondImage = "mauitoolkit_logo.png",
                Activity = NewActivity.AddFeature,
                NewLog = mauiToolkitNews,
                Date = new DateTime(2024, 2, 01),
                NewsRoute = AppRoutes.CardsByGroupPage,
                Arg = controlGroups.FirstOrDefault(x => x.Name == ControlGroupInfo.CommunityToolkit)
            });

            activites.Add(new ApplicationNew()
            {
                Title = "Repository Cache",
                AuthorName = "Tân",
                AuthorImageUrl = "member_tan.png",
                SecondImage = "github_logo.png",
                Activity = NewActivity.AddFeature,
                Date = new DateTime(2024, 2, 18),
                NewLog = repoCachedNews,
                NewsRoute = AppRoutes.CardsByGroupPage,
                Arg = controlGroups.FirstOrDefault(x => x.Name == ControlGroupInfo.GitHubCommunity)
            });

            activites.Add(new ApplicationNew()
            {
                Title = "Material Components",
                AuthorName = "Strypper",
                AuthorImageUrl = "https://i.imgur.com/vc9FudE.jpg",
                SecondImage = "materialuilogo.png",
                Activity = NewActivity.AddFeature,
                Date = new DateTime(2023, 11, 10),
                NewLog = materialUINews,
                NewsRoute = AppRoutes.CardsByGroupPage,
                Arg = controlGroups.FirstOrDefault(x => x.Name == ControlGroupInfo.MaterialComponent)
            });

            return (IEnumerable<ApplicationNew>)activites;
        });
    }
    #endregion

}
