namespace MAUIsland.Core;
public partial class SfRadialGaugePageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public SfRadialGaugePageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string redZoneMeme = "MARIOS\r\nGONNA DO\r\nSOMTHING VERY\r\nILLEGAL";

    [ObservableProperty]
    string bossPissedMetric = "<gauge:SfRadialGauge\r\n                        BackgroundColor=\"Gray\"\r\n                        HeightRequest=\"380\"\r\n                        WidthRequest=\"380\">\r\n                        <gauge:SfRadialGauge.Axes>\r\n                            <gauge:RadialAxis\r\n                                LabelPosition=\"Outside\"\r\n                                Maximum=\"30\"\r\n                                Minimum=\"0\"\r\n                                ShowAxisLine=\"True\"\r\n                                ShowLabels=\"True\"\r\n                                ShowTicks=\"True\">\r\n                                <gauge:RadialAxis.AxisLabelStyle>\r\n                                    <gauge:GaugeLabelStyle FontSize=\"11\" TextColor=\"White\" />\r\n                                </gauge:RadialAxis.AxisLabelStyle>\r\n\r\n                                <gauge:RadialAxis.Ranges>\r\n                                    <gauge:RadialRange\r\n                                        EndValue=\"6\"\r\n                                        EndWidth=\"0.65\"\r\n                                        Fill=\"#73d684\"\r\n                                        Label=\"YO WE COOL\"\r\n                                        LabelStyle=\"{StaticResource labelStyle}\"\r\n                                        StartValue=\"0\"\r\n                                        StartWidth=\"0.65\"\r\n                                        WidthUnit=\"Factor\" />\r\n                                    <gauge:RadialRange\r\n                                        EndValue=\"18\"\r\n                                        EndWidth=\"0.65\"\r\n                                        Fill=\"#fce348\"\r\n                                        Label=\"YOU WAT MATE ?\"\r\n                                        LabelStyle=\"{StaticResource labelStyle}\"\r\n                                        StartValue=\"6\"\r\n                                        StartWidth=\"0.65\"\r\n                                        WidthUnit=\"Factor\" />\r\n                                    <gauge:RadialRange\r\n                                        EndValue=\"30\"\r\n                                        EndWidth=\"0.65\"\r\n                                        Fill=\"#fc0203\"\r\n                                        Label=\"{x:Binding RedZoneMeme}\"\r\n                                        LabelStyle=\"{StaticResource labelStyle}\"\r\n                                        StartValue=\"18\"\r\n                                        StartWidth=\"0.65\"\r\n                                        WidthUnit=\"Factor\" />\r\n                                    <gauge:RadialRange\r\n                                        EndValue=\"99\"\r\n                                        EndWidth=\"0.15\"\r\n                                        Fill=\"#4D9b9b9b\"\r\n                                        OffsetUnit=\"Factor\"\r\n                                        RangeOffset=\"0.63\"\r\n                                        StartValue=\"0\"\r\n                                        StartWidth=\"0.15\"\r\n                                        WidthUnit=\"Factor\" />\r\n                                </gauge:RadialAxis.Ranges>\r\n\r\n                                <gauge:RadialAxis.Pointers>\r\n                                    <gauge:NeedlePointer\r\n                                        KnobRadius=\"15\"\r\n                                        KnobSizeUnit=\"Pixel\"\r\n                                        NeedleEndWidth=\"15\"\r\n                                        NeedleLength=\"0.6\"\r\n                                        NeedleStartWidth=\"2\"\r\n                                        Value=\"28\" />\r\n                                </gauge:RadialAxis.Pointers>\r\n                            </gauge:RadialAxis>\r\n                        </gauge:SfRadialGauge.Axes>\r\n                    </gauge:SfRadialGauge>";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion

}