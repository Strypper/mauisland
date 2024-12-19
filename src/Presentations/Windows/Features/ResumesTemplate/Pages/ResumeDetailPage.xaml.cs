using Microsoft.AspNetCore.Components;
using Octokit;
using System.ComponentModel;
using System.Diagnostics;

namespace MAUIsland.ResumesTemplate;

public partial class ResumeDetailPage
{
    #region [ Field ]
    private bool IsAnimating = false;

    protected ResumeDetailPageViewModel ViewModel;
    #endregion

    #region [ CTor ]

    public ResumeDetailPage(ResumeDetailPageViewModel vm)
    {
        InitializeComponent();

        this.BindingContext = ViewModel = vm;

        SizeChanged += OnSizeChanged;
        ViewModel.PropertyChanged += ViewModel_PropertyChanged;
    }
    #endregion

    #region [ Events ]
    private async void BlazorWebViewElement_Loaded(Object sender, EventArgs e)
    {
        await BlazorWebViewElement.TryDispatchAsync(sp =>
        {
            var navigationManager = sp.GetRequiredService<NavigationManager>();
            navigationManager.NavigateTo(ViewModel.BlazorWebViewStartPath, true, true);
        });
    }

    private void OnSizeChanged(object sender, EventArgs e)
    {
        AdjustLayout().FireAndForget();
    }

    private async void ViewModel_PropertyChanged(Object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ViewModel.SelectedPageIndex))
        {
            await HandlePageIndexChangedByWebViewAsync();
        }
    }

    private void OnScrolled(object sender, ScrolledEventArgs e)
    {
        if (IsAnimating)
            return;

        var scrollY = e.ScrollY;
        var contentHeight = ResumeInputStackLayout.Height;
        var visibleHeight = ResumeInputScrollView.Height;
        var maxScrollY = contentHeight - visibleHeight;
        var threshold = maxScrollY * 0.05;

        if (scrollY > (maxScrollY - threshold))
        {
            if (ViewModel.SelectedPageIndex < (ResumeInputStackLayout.Children.Count - 1))
            {
                ChangePage(ViewModel.SelectedPageIndex + 1);
            }
        }
        else if (scrollY < (threshold))
        {
            if (ViewModel.SelectedPageIndex > 0)
            {
                ChangePage(ViewModel.SelectedPageIndex - 1);
            }
        }
    }
    #endregion

    #region [ Methods ]
    private void ChangePage(int newPage)
    {
        ViewModel.PreviousSelectedPageIndex = ViewModel.SelectedPageIndex;
        ViewModel.SelectedPageIndex = newPage;

        //await BlazorWebViewElement.TryDispatchAsync(async sp =>
        //{
        //    var navigationManager = sp.GetRequiredService<NavigationManager>();
        //    var newUri = ViewModel.BlazorWebViewStartPath + ViewModel.Pages[newPage];
        //    if (navigationManager.Uri != navigationManager.ToAbsoluteUri(newUri).ToString())
        //    {
        //        await Task.Delay(800);
        //        navigationManager.NavigateTo(newUri, true);
        //        await Task.Delay(800);
        //    }
        //});
    }

    private async Task HandlePageIndexChangedByWebViewAsync()
    {
        IsAnimating = true;

        var previousLayout = ResumeInputStackLayout.Children[ViewModel.PreviousSelectedPageIndex] as VisualElement;
        var currentLayout = ResumeInputStackLayout.Children[ViewModel.SelectedPageIndex] as VisualElement;

        if (previousLayout != null)
        {
            await Task.Delay(100);
            await previousLayout.FadeTo(0, 300);
            previousLayout.IsVisible = false;
        }

        if (currentLayout != null)
        {
            await Task.Delay(100);
            currentLayout.IsVisible = true;
            await currentLayout.FadeTo(1, 300);
        }

        await AdjustLayout();

        IsAnimating = false;
    }

    private async Task AdjustLayout()
    {
        IsAnimating = true;
        var currentPageHeight = 0.0;
        var currentElement = ResumeInputStackLayout.Children[ViewModel.SelectedPageIndex] as VisualElement;

        if (currentElement is VisualElement stackChildrenElement)
        {
            stackChildrenElement.Measure(double.PositiveInfinity, double.PositiveInfinity);
            currentPageHeight = stackChildrenElement.DesiredSize.Height;
        }

        var desiredHeight = ResumeInputScrollView.Height;

        var remainingHeight = desiredHeight - currentPageHeight;
        if (remainingHeight > 0)
        {
            ResumeInputStackLayout.Padding = new Thickness(0, remainingHeight / 2 + desiredHeight * 0.1);
        }
        else
        {
            ResumeInputStackLayout.Padding = new Thickness(0, desiredHeight * 0.1);
        }

        await Task.Delay(300);
        //await ResumeInputScrollView.ScrollToAsync(0, desiredHeight * 0.1, true);
        await ResumeInputScrollView.ScrollToAsync(currentElement, ScrollToPosition.Center, true);

        IsAnimating = false;
    }
    #endregion
}