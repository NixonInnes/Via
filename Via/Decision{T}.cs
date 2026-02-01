using System.Diagnostics.CodeAnalysis;

namespace Via;

public struct Decision<T>
{
    public bool IsAllowed { get; }
    public T? Reason { get; }

    private Decision(bool isAllowed, T? reason)
    {
        IsAllowed = isAllowed;
        Reason = reason;
    }

    public static Decision<T> Allow()
        => new(true, default);

    public static Decision<T> Deny(T reason)
        => new(false, reason);
    public bool IsDenied => !IsAllowed;
}

public static class DecisionTExtensions
{
    extension<T>(Decision<T> decision)
    {
        public bool IsDeniedGetReason([NotNullWhen(true)]out T? reason)
        {
            if (decision.IsDenied)
            {
                reason = decision.Reason!;
                return true;
            }

            reason = default;
            return false;
        }
    }
}