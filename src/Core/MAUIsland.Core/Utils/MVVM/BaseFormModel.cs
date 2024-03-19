namespace MAUIsland.Core;

public abstract class BaseFormModel : ObservableValidator
{
    protected virtual string[] ValidatableAndSupportPropertyNames => new string[0];

    public virtual bool IsValid()
    {
        ValidateAllProperties();

        foreach (var propertyName in ValidatableAndSupportPropertyNames)
        {
            OnPropertyChanged(propertyName);
        }

        return !HasErrors;
    }
}

