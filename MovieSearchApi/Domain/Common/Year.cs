namespace Domain.Common;

// It's a value object representing a year
public readonly struct Year(int value)
{
    public Year(DateOnly value) : this(value.Year)
    {
    }

    private int Value { get; } = value;

    public static implicit operator int(Year year)
    {
        return year.Value;
    }

    public static implicit operator Year(int value)
    {
        return new Year(value);
    }

    public static bool operator ==(Year left, Year right)
    {
        return left.Value == right.Value;
    }

    public static bool operator !=(Year left, Year right)
    {
        return left.Value != right.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is Year other && Value == other.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}