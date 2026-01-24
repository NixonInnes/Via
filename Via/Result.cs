namespace Via;

public readonly struct Result
{
    public bool IsSuccess { get; }
    private readonly Error _error;

    public Error? Error => IsFailure ? _error : null;

    private Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        _error = error;
    }

    public bool IsFailure => !IsSuccess;

    public static Result Success()
        => new(true, default);

    public static Result Failure(Error error)
        => new(false, error);
}