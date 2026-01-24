namespace Via;

public readonly struct Error
{
    private readonly string? _message;
    private readonly Exception? _exception;

    public string Message => _message ?? "An error has occurred.";
    public Exception? Exception => _exception;

    public Error(string message, Exception? exception = null)
    {
        _message = message;
        _exception = exception;
    }

    public static Error FromException(Exception exception)
        => new(exception.Message, exception);
}