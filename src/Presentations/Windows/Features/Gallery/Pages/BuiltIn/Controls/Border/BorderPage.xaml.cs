using Microsoft.Maui.Controls.Shapes;

namespace MAUIsland;

public partial class BorderPage : IGalleryPage
{
    #region [ Fields ]

    private readonly BorderPageViewModel viewModel;
    #endregion


    #region [ CTor ]


    public BorderPage(BorderPageViewModel vm)
    {
        InitializeComponent();
        viewModel = vm;
        BindingContext = viewModel;

    }
    #endregion

    #region [ Event Handlers ]

    private void BasePage_Loaded(object sender, EventArgs e)
    {
        if (NewWindowParameter is not null && viewModel.ControlInformation is null)
        {
            viewModel.SetControlInformation(NewWindowParameter);
            viewModel.RefreshCommand.Execute(null);
        }
        CreateBorderUsingCSharp();
    }
    #endregion

    #region [ Methods ]

    void CreateBorderUsingCSharp()
    {
        Border border = new Border
        {
            Stroke = Color.FromArgb("#C49B33"),
            Background = Color.FromArgb("#2B0B98"),
            StrokeThickness = 4,
            Padding = new Thickness(16, 8),
            HorizontalOptions = LayoutOptions.Center,
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(40, 0, 0, 40)
            },
            Content = new Label
            {
                Text = ".NET MAUI",
                TextColor = Colors.White,
                FontSize = 18,
                FontAttributes = FontAttributes.Bold
            }
        };

        CreateBorderExampleGrid.Add(border);
    }
    #endregion
}