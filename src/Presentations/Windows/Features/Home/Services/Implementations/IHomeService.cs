namespace MAUIsland;

public interface IHomeService
{
    Task<IEnumerable<MAUIFact>> GetMAUIFactsAsync();

    Task<IEnumerable<ApplicationNew>> GetApplicationNews();
}
