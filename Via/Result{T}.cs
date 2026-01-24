namespace Via;

public readonly struct Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    private readonly Error _error;

    public Error? Error => IsFailure ? _error : null;

    private Result(bool isSuccess, T? value, Error error)
    {
        IsSuccess = isSuccess;
        Value = value;
        _error = error;
    }

    public bool IsFailure => !IsSuccess;

    public static Result<T> Success(T value)
        => new(true, value, default);

    public static Result<T> Failure(Error error)
        => new(false, default, error);
}