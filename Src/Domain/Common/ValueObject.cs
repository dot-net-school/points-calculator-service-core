namespace Domain.Common;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public static bool operator ==(ValueObject left, ValueObject right)
    {
        if (left is null ^ right is null)
            return false;

        return left?.Equals(right) != false;
    }

    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !(left == right);
    }

    public abstract bool Equals(ValueObject other);
    //for dictionary and hashcode collection we need to define it too
    public abstract int GetHashCode();
}