namespace MAUIsland;

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

    // ReSharper disable once UnusedParameter.Global
    protected virtual void OnBack(IDictionary<string, object> query)
    {
    }

    // ReSharper disable once UnusedParameter.Global
    protected virtual void OnInit(IDictionary<string, object> query)
    {
    }
}

public interface IOnBackAwareViewModel
{
    // ReSharper disable once UnusedMemberInSuper.Global
    // ReSharper disable once UnusedMethodReturnValue.Global
    // ReSharper disable once UnusedParameter.Global
    Task OnBackAsync(IDictionary<string, object> query);
}

public interface IOnInitAwareViewModel<in T>
{
    // ReSharper disable once UnusedMemberInSuper.Global
    // ReSharper disable once UnusedMethodReturnValue.Global
    // ReSharper disable once UnusedParameter.Global
    Task OnInitAsync(T args);
}

// ReSharper disable once UnusedType.Global

// ReSharper disable once UnusedType.Global
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

    // ReSharper disable once UnusedParameter.Global
    // ReSharper disable once UnusedMethodReturnValue.Global
    public virtual Task OnInitAsync(TInit args) => Task.CompletedTask;

    protected override void OnBack(IDictionary<string, object> query)
    {
        OnBackAsync(query);
    }

    // ReSharper disable once UnusedParameter.Global
    // ReSharper disable once UnusedMethodReturnValue.Global
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

    // ReSharper disable once UnusedParameter.Global
    // ReSharper disable once UnusedMethodReturnValue.Global
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

    // ReSharper disable once UnusedParameter.Global
    // ReSharper disable once UnusedMethodReturnValue.Global
    public virtual Task OnInitAsync(TInit args) => Task.CompletedTask;
}
