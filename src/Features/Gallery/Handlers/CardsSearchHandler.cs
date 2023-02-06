using Syncfusion.Office;

namespace MAUIsland;

public class CardsSearchHandler : SearchHandler
{
	#region [CTor]
	public CardsSearchHandler()
	{
        this.Cards = new();
	}
    #endregion

    #region [Bindable Properties]
    public static readonly BindableProperty CardsProperty = BindableProperty.Create(nameof(Cards),
                                                                               typeof(ObservableCollection<IControlInfo>),
                                                                               typeof(CardsSearchHandler),
                                                                               new ObservableCollection<IControlInfo>(),
                                                                               BindingMode.OneWay);
    #endregion

    #region [Properties]
    public ObservableCollection<IControlInfo> Cards
    {
        get => (ObservableCollection<IControlInfo>)GetValue(CardsProperty);
        set => SetValue(CardsProperty, value);
    }
    #endregion

    #region [Delegates]
    public delegate void SelectCardEventHandler(IControlInfo control);
    #endregion

    #region [Event Handlers]
    public event SelectCardEventHandler SelectCard;

    protected override void OnQueryChanged(string oldValue, string newValue)
    {
        base.OnQueryChanged(oldValue, newValue);

        if (string.IsNullOrWhiteSpace(newValue))
        {
            ItemsSource = null;
        }
        else
        {
            ItemsSource = Cards.Where(control => control.ControlName.ToLower().Contains(newValue.ToLower())).ToList();
        }
    }

    protected override async void OnItemSelected(object item)
    {
        base.OnItemSelected(item);
        var selectedCard = item as IControlInfo;
        SelectCard?.Invoke(selectedCard);
    }

    #endregion
}
