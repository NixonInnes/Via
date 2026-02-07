using System.Diagnostics.CodeAnalysis;

namespace Via;

public static class ResultInspection
{
    extension(Result result)
    {
        /// <summary>Gets the error if the result is a failure.</summary>
        public bool TryGetError([NotNullWhen(true)] out Error? error)
        {
            if (result.IsFailure)
            {
                error = result.Error.OrUnknown();
                return true;
            }

            error = null;
            return false;
        }
    }
}