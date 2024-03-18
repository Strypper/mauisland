namespace MAUIsland;

public partial class LoginFormModel : BaseFormModel
{
    #region [Properties]
    [ObservableProperty]
    [Required(ErrorMessage = "Please enter your phone number")]
    [Phone(ErrorMessage = "Please enter a valid phone number")]
    [NotifyPropertyChangedFor(nameof(PhoneNumberErrors))]
    [NotifyDataErrorInfo]
    string phoneNumber;


    [ObservableProperty]
    [Required(ErrorMessage = "Please enter a password")]
    [Password(
    IncludesLower = true,
    IncludesNumber = true,
    IncludesSpecial = true,
    IncludesUpper = true,
    MinimumLength = 6,
    ErrorMessage = "Please enter a strong password: from 8 characters, 1 upper, 1 lower, 1 digit, 1 special character"
)]
    [NotifyPropertyChangedFor(nameof(PasswordErrors))]
    [NotifyDataErrorInfo]
    string password;
    #endregion

    #region [Errors]
    public IEnumerable<ValidationResult> PhoneNumberErrors => GetErrors(nameof(PhoneNumber));

    public IEnumerable<ValidationResult> PasswordErrors => GetErrors(nameof(Password));
    #endregion

    #region [Override]
    protected override string[] ValidatableAndSupportPropertyNames => new[]
    {
        nameof(PhoneNumber),
        nameof(PhoneNumberErrors),
    };
    #endregion
}
