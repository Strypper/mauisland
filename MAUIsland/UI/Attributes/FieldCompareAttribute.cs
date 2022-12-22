using System.ComponentModel.DataAnnotations;

namespace MAUIsland;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class FieldCompareAttribute : CompareAttribute
{
    public FieldCompareAttribute(string otherProperty) : base(otherProperty)
    {
    }
}