namespace MAUIsland.Core;

public abstract class NavigationAwareBaseViewModel : BaseViewModel, IQueryAttributable
{
    protected bool Initialized { get; private set; }

    protected NavigationAwareBaseViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.IsGoingBack())
        {
            System.Diagnostics.Debug.WriteLine($"{GetType().Name}.{nameof(OnBack)}");
            OnBack(query);
        }
        else
        {
            System.Diagnostics.Debug.WriteLine($"{GetType().Name}.{nameof(OnInit)}");

            if (Initialized) return;

            Initialized = true;
            OnInit(query);
        }
    }

    public override Task OnAppearingAsync()
    {
        if (!Initialized)
        {
            Initialized = true;
            OnInit(new Dictionary<string, object>());
        }

        return base.OnAppearingAsync();
    }

    protected virtual void OnBack(IDictionary<string, object> query)
    {
    }

    protected virtual void OnInit(IDictionary<string, object> query)
    {
    }
}

public interface IOnBackAwareViewModel
{
    Task OnBackAsync(IDictionary<string, object> query);
}

public interface IOnInitAwareViewModel<in T>
{
    Task OnInitAsync(T args);
}

public abstract class NavigationAwareViewModel<TInit>
    : NavigationAwareBaseViewModel
        , IOnInitAwareViewModel<TInit>
        , IOnBackAwareViewModel
{
    protected NavigationAwareViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
    }

    protected override void OnInit(IDictionary<string, object> query)
    {
        OnInitAsync(query.GetData<TInit>());
    }

    public virtual Task OnInitAsync(TInit args) => Task.CompletedTask;

    protected override void OnBack(IDictionary<string, object> query)
    {
        OnBackAsync(query);
    }

    public virtual Task OnBackAsync(IDictionary<string, object> query) => Task.CompletedTask;
}

// ReSharper disable once UnusedType.Global
public abstract class OnBackAwareViewModel
    : NavigationAwareBaseViewModel
        , IOnBackAwareViewModel
{
    protected OnBackAwareViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
    }

    protected override void OnBack(IDictionary<string, object> query)
    {
        OnBackAsync(query);
    }

    public virtual Task OnBackAsync(IDictionary<string, object> query) => Task.CompletedTask;
}

// ReSharper disable once UnusedType.Global
public abstract class OnInitAwareViewModel<TInit>
    : NavigationAwareBaseViewModel
        , IOnInitAwareViewModel<TInit>
{
    protected OnInitAwareViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
    }

    protected override void OnInit(IDictionary<string, object> query)
    {
        OnInitAsync(query.GetData<TInit>());
    }

    public virtual Task OnInitAsync(TInit args) => Task.CompletedTask;
}
