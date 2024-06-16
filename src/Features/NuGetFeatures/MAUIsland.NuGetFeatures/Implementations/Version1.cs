using NuGet.Common;
using NuGet.Configuration;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using OneOf;

namespace MAUIsland.NuGetFeatures;

internal class Version1 : INuGetFeatures
{
    #region [ CTors ]

    #endregion

    #region [ Methods ]
    public async Task<OneOf<ServiceSuccess, SerivceError>> GetNuGetByName(string name)
    {
        ILogger logger = new Logger();
        PackageSource source = new PackageSource("https://api.nuget.org/v3/index.json");
        SourceRepository repository = Repository.Factory.GetCoreV3(source);

        // Get the metadata resource
        PackageMetadataResource metadataResource = await repository.GetResourceAsync<PackageMetadataResource>();

        // Search for the package metadata
        var searchMetadata = await metadataResource.GetMetadataAsync(name,
                                                                     includePrerelease: false,
                                                                     includeUnlisted: false,
                                                                     sourceCacheContext: new SourceCacheContext(),
                                                                     log: logger,
                                                                     token: CancellationToken.None);

        foreach (var package in searchMetadata)
        {
            Console.WriteLine($"Package ID: {package.Identity.Id}");
            Console.WriteLine($"Version: {package.Identity.Version}");
            Console.WriteLine($"Authors: {package.Authors}");
            Console.WriteLine($"Description: {package.Description}");
            Console.WriteLine($"Published: {package.Published}");
            Console.WriteLine();
        }

        return new ServiceSuccess(string.Empty,
                                  string.Empty,
                                  nameof(Version1),
                                  nameof(GetNuGetByName),
                                  string.Empty,
                                  DateTime.UtcNow,
                                  null);
    }
    #endregion
}
public class Logger : ILogger
{
    public void LogDebug(string data) => Console.WriteLine(data);
    public void LogVerbose(string data) => Console.WriteLine(data);
    public void LogInformation(string data) => Console.WriteLine(data);
    public void LogMinimal(string data) => Console.WriteLine(data);
    public void LogWarning(string data) => Console.WriteLine(data);
    public void LogError(string data) => Console.WriteLine(data);
    public void LogInformationSummary(string data) => Console.WriteLine(data);
    public void Log(LogLevel level, string data) => Console.WriteLine(data);
    public Task LogAsync(LogLevel level, string data) => Task.Run(() => Console.WriteLine(data));
    public void Log(ILogMessage message) => Console.WriteLine(message);
    public Task LogAsync(ILogMessage message) => Task.Run(() => Console.WriteLine(message));
}