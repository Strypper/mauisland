using CodeHollow.FeedReader;
using OneOf;

namespace MAUIsland.NewsFeatures;

public class ImplVersion1 : INewsService
{
    #region [ CTor ]

    #endregion

    #region [ Methods ]


    public async Task<OneOf<ServiceSuccess, SerivceError>> GetNews()
    {
        Feed feed = null;
        try
        {
            feed = await FeedReader.ReadAsync("https://blog.jetbrains.com/feed/");
        }
        catch (Exception ex)
        {
            return new SerivceError(Constants.GetAuthorFailure,
                                    Constants.NotAvailable,
                                    nameof(ImplVersion1),
                                    nameof(GetNews),
                                    Constants.NotAvailable,
                                    ex.Message,
                                    DateTime.UtcNow);
        }

        return new SerivceError(Constants.GetAuthorFailure,
                                Constants.NotAvailable,
                                nameof(ImplVersion1),
                                nameof(GetNews),
                                Constants.NotAvailable,
                                string.Empty,
                                DateTime.UtcNow);
    }
    #endregion
}
