namespace MAUIsland.Core;

public static class UriHelper
{
    public const string GoBackSegment = "..";

    public const string GoBackQueryParameterName = "__GOBACK__";
    public const string DataQueryParameterName = "__DATA__";

    public static bool IsGoingBack(this IDictionary<string, object> query)
    {
        if (query == null) return false;

        return query.ContainsKey(GoBackQueryParameterName);
    }

    public static T GetData<T>(this IDictionary<string, object> query)
    {
        if (query == null) return default;

        var hasData = query.TryGetValue(DataQueryParameterName, out var arg);

        if (hasData && arg is T tValue) return tValue;

        return default;
    }
}