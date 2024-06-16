namespace MAUIsland.NuGetFeatures;

public record SerivceError(string ErrorMessage = "",
                           string ErrorCode = "",
                           string ServiceName = "",
                           string MethodName = "",
                           string ConsumerName = "",
                           string? ErrorDetail = null,
                           DateTime EventOccuredAt = default!);
