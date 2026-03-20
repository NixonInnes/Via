namespace Via;

/// <summary>
/// Represents the absence of a meaningful value (the functional equivalent of <c>void</c>).
/// Useful for generic code paths such as <c>Result&lt;Unit&gt;</c> and <c>Option&lt;Unit&gt;</c>.
/// </summary>
public readonly struct Unit : IEquatable<Unit>
{
    /// <summary>The single canonical unit value.</summary>
    public static Unit Value => default;

    public bool Equals(Unit other) => true;

    public override bool Equals(object? obj) => obj is Unit;

    public override int GetHashCode() => 0;

    public override string ToString() => "()";

    public static bool operator ==(Unit left, Unit right) => true;

    public static bool operator !=(Unit left, Unit right) => false;
}
