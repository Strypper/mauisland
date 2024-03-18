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
                                                                               typeof(ObservableCollection<IGalleryCardInfo>),
                                                                               typeof(CardsSearchHandler),
                                                                               new ObservableCollection<IGalleryCardInfo>(),
                                                                               BindingMode.OneWay);
    #endregion

    #region [Properties]
    public ObservableCollection<IGalleryCardInfo> Cards
    {
        get => (ObservableCollection<IGalleryCardInfo>)GetValue(CardsProperty);
        set => SetValue(CardsProperty, value);
    }
    #endregion

    #region [Delegates]
    public delegate void SelectCardEventHandler(IGalleryCardInfo control);
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
        var selectedCard = item as IGalleryCardInfo;
        SelectCard?.Invoke(selectedCard);
    }

    #endregion
}
