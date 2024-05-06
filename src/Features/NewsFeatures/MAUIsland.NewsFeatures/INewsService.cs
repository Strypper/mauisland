using OneOf;

namespace MAUIsland.NewsFeatures;

public interface INewsService
{
    Task<OneOf<ServiceSuccess, SerivceError>> GetNews();
}
