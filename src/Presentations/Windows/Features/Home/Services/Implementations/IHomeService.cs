namespace MAUIsland.Home;

public interface IHomeService
{

    Task<IEnumerable<ApplicationNew>> GetApplicationNews();
}
