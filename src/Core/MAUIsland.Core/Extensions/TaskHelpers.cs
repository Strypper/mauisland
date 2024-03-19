namespace MAUIsland.Core;

public static class TaskHelpers
{
    public static void FireAndForget(this Task task, bool configureAwait = false)
    {
        task.ConfigureAwait(configureAwait);
    }
}
