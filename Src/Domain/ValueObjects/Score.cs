using Domain.Common;
using Domain.Exceptions;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace Domain.ValueObjects;

public sealed class Score : ValueObject
{
    //TODO how about to define value as byte? its smaller in memory but how about cpu calculation versus int?
    //TODO it is good practice to define score as valueObject because it has same logic in other entities 
    public byte Value { get; private set; }
    private readonly IDomainLayerSettings _domainLayerSettings;

    //TODO it will initialize in app startup but if site setting edits, we will need to re run, another way is option pattern using but with that we need public 
    public Score(byte value, IDomainLayerSettings domainLayerSettings)
    {
        _domainLayerSettings = domainLayerSettings;
        SetValue(value);
    }

    public void SetValue(byte value)
    {
        if (value > _domainLayerSettings.MaxScore)
            throw new OutOfRangeScoreException(nameof(value));
        Value = value;
    }

    /// <summary>
    /// EF constructor
    /// </summary>
    private Score(byte value)
    {
        Value = value;
    }

    public override bool Equals(ValueObject other)
    {
        if (other is null)
            return false;

        if (other is Score score)
        {
            return Value == score.Value;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}