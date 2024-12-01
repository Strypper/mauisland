namespace MAUIsland.Core;

public partial class SfCartesianChartModel : BaseModel
{
    [ObservableProperty]
    string? name;

    [ObservableProperty]
    string? year;

    [ObservableProperty]
    double exp;

    [ObservableProperty]
    double high;

    [ObservableProperty]
    double low;

    [ObservableProperty]
    double value;

    [ObservableProperty]
    double size;

    [ObservableProperty]
    DateTime date;

    [ObservableProperty]
    List<double>? values;
}
