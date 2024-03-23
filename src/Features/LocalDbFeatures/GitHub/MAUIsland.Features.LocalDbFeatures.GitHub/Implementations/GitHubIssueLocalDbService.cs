namespace MAUIsland.Features.LocalDbFeatures.GitHub;

public class GitHubIssueLocalDbService : SQLitePCLRawService<GitHubIssueLocalDbModel>, IGitHubIssueLocalDbService
{
    #region [ CTor ]

    public GitHubIssueLocalDbService(DatabaseSettings settings) : base(settings) {

    }


    #endregion

    #region [ Methods - Get Single ]
    public async Task<GitHubIssueLocalDbModel?> GetByIssueUrlAsync(string issueUrl) {
        try {
            if (string.IsNullOrEmpty(issueUrl)) {
                return default;
            }

            return await _connection.Table<GitHubIssueLocalDbModel>().FirstOrDefaultAsync(x => x.IssueLinkUrl == issueUrl);
        }
        catch (Exception ex) {
            throw;
        }
    }
    #endregion

    #region [ Methods - Get List ]
    public async Task<IEnumerable<GitHubIssueLocalDbModel>?> GetByControlNameAsync(string controlName) {
        try {
            if (string.IsNullOrEmpty(controlName)) {
                return default;
            }

            return await _connection.Table<GitHubIssueLocalDbModel>().Where(x => x.ControlName == controlName).ToListAsync();
        }
        catch (Exception ex) {
            throw;
        }
    }
    #endregion
}
