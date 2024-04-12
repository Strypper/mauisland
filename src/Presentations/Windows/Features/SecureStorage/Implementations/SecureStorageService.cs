namespace MAUIsland;

public class SecureStorageService : ISecureStorageService
{
    public Task<string> ReadValueAsync(string key)
        => Task.Run(() => SecureStorage.Default.GetAsync(key));

    public Task WriteValueAsync(string key, string value)
        => Task.Run(() => SecureStorage.Default.SetAsync(key, value));

    public Task RemoveAllValueAsync()
        => Task.Run(() => SecureStorage.Default.RemoveAll());

    public Task<bool> RemoveValueAsync(string key)
        => Task.Run(() => SecureStorage.Default.Remove(key));
}
