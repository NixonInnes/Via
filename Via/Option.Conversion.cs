namespace Via;

public static class OptionConversion
{
    extension<T>(Option<T> option) where T : notnull
    {
        /// <summary>Converts Some into a successful result, otherwise returns a failure.</summary>
        public Result<T> ToResult(Error? error = null)
        {
            return option.IsSome
                ? Result<T>.Success(option.Value)
                : Result<T>.Failure(error ?? new Error("Option has no value."));
        }
    }
}