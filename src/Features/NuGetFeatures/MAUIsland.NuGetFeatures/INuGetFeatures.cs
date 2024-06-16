using OneOf;

namespace MAUIsland.NuGetFeatures;

public interface INuGetFeatures
{
    Task<OneOf<ServiceSuccess, SerivceError>> GetNuGetByName(string name);
}
