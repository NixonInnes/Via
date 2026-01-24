using System.Diagnostics.CodeAnalysis;

namespace Via;

public static class ResultTInspection
{
    extension<T>(Result<T> result)
    {
        /// <summary>Gets the value if the result is successful.</summary>
        public bool TryGetValue(out T? value)
        {
            if (result.IsSuccess)
            {
                value = result.Value;
                return true;
            }

            value = default;
            return false;
        }

        /// <summary>Gets the error if the result is a failure.</summary>
        public bool TryGetError([NotNullWhen(true)] out Error? error)
        {
            if (result.IsFailure)
            {
                error = result.Error.GetValueOrDefault();
                return true;
            }

            error = null;
            return false;
        }
    }
}