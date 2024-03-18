using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MAUIsland.Core;

public class PasswordAttribute : ValidationAttribute
{
    public bool IncludesUpper { get; set; }
    public bool IncludesLower { get; set; }
    public bool IncludesNumber { get; set; }
    public bool IncludesSpecial { get; set; }
    public uint MinimumLength { get; set; }

    static readonly Regex UpperRegex = new Regex("[A-Z]+", RegexOptions.None);
    static readonly Regex LowerRegex = new Regex("[a-z]+", RegexOptions.None);
    static readonly Regex NumberRegex = new Regex("[0-9]+", RegexOptions.None);
    static readonly Regex SpecialRegex = new Regex("[^A-Z0-9]+", RegexOptions.IgnoreCase);

    public override bool IsValid(object value)
    {
        if (value is not string stringValue)
        {
            return base.IsValid(value);
        }

        if (string.IsNullOrWhiteSpace(stringValue)) return false;

        if (MinimumLength > 0 && stringValue.Length < MinimumLength) return false;

        if (IncludesLower && !LowerRegex.IsMatch(stringValue)) return false;

        if (IncludesNumber && !LowerRegex.IsMatch(stringValue)) return false;

        if (IncludesSpecial && !SpecialRegex.IsMatch(stringValue)) return false;

        if (IncludesUpper && !UpperRegex.IsMatch(stringValue)) return false;

        return true;
    }
}

