namespace MAUIsland.GitHubFeatures;

public record ServiceSuccess(string SuccessMessage = "",
                             string SuccessCode = "",
                             string ServiceName = "",
                             string MethodName = "",
                             string ConsumerName = "",
                             DateTime EventOccuredAt = default!,
                             object? AttachedData = default!);