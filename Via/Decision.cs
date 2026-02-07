namespace Via;

public readonly struct Decision
{
    public bool IsAllowed { get; }
    public string? Reason { get; }

    private Decision(bool isAllowed, string? reason)
    {
        IsAllowed = isAllowed;
        Reason = reason;
    }

    public static Decision Allow()
        => new(true, null);

    public static Decision Deny(string reason)
        => new(false, reason);

    public bool IsDenied => !IsAllowed;
}

public static class DecisionExtensions
{
    extension(Decision decision)
    {
        public bool IsDeniedGetReason(out string reason)
        {
            if (decision.IsDenied)
            {
                reason = decision.Reason ?? "No reason provided.";
                return true;
            }

            reason = string.Empty;
            return false;
        }

        public Result ToResult()
            => decision.IsAllowed
                ? Result.Success()
                : Result.Failure(Error.FromMessage(decision.Reason ?? "No reason provided."));
    }
}