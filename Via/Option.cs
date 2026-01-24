using System.Diagnostics.CodeAnalysis;

namespace Via;

public readonly struct Option<T>
    where T : notnull
{
    private readonly T? _value;
    public bool IsSome { get; }
    public T Value => _value ?? throw new InvalidOperationException("Option has no value.");

    private Option(bool isSome, T? value)
    {
        if (isSome && value is null)
        {
            throw new ArgumentNullException(nameof(value), "Cannot create a Some option with a null value.");
        }
        
        IsSome = isSome;
        _value = value;
    }

    public bool IsNone => !IsSome;

    public static Option<T> Some(T value)
    {
        ArgumentNullException.ThrowIfNull(value);
        return new(true, value);
    }

    public static Option<T> None
        => new(false, default);
}