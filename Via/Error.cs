using System.Diagnostics.CodeAnalysis;

namespace Via;

// public readonly struct Error
// {
//     private readonly string? _message;
//     private readonly Exception? _exception;

//     public string Message => _message ?? "An error has occurred.";
//     public Exception? Exception => _exception;

//     public Error(string message, Exception? exception = null)
//     {
//         _message = message;
//         _exception = exception;
//     }

//     public static Error FromException(Exception exception)
//         => new(exception.Message, exception);
// }

public abstract record Error
{
    public virtual string Message { get; }

    protected Error(string message)
        => Message = message;

    public static Error FromException(Exception ex) => new ExceptionError(ex);
    public static Error FromMessage(string message) => new SimpleError(message);

}

public sealed record SimpleError(string Message) : Error(Message);

public sealed record ViaError(string Message) : Error(Message);

public sealed record UnknownError() : Error("An unknown error has occurred.");

public sealed record ExceptionError(Exception Exception)
    : Error(Exception.Message)
{

    public bool TryGetException([NotNullWhen(true)]out Exception? ex)
    {
        if (Exception is null)
        {
            ex = null;
            return false;
        }

        ex = Exception;
        return true;
    }
}

public static class ErrorExtensions
{
    extension(Error? error)
    {
        public Error OrUnknown()
            => error ?? new UnknownError();
    }
}
