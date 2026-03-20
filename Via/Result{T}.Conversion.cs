namespace Via;

public static class ResultTConversion
{
    extension<T>(Result<T> result)
    {
        /// <summary>Separates the value into an out parameter and returns a non-generic result.</summary>
        public Result Strip(out T? value)
        {
            if (result.IsSuccess)
            {
                value = result.Value;
                return Result.Success();
            }
            else
            {
                value = default;
                return Result.Failure(result.Error.OrUnknown());
            }
        }
    }

    extension<T>(Result<T> result) where T : notnull
    {
        /// <summary>Converts a successful non-null result into `Option.Some`, otherwise returns `Option.None`.</summary>
        public Option<T> ToOption()
            => result.IsSuccess && result.Value is not null
                ? Option<T>.Some(result.Value)
                : Option<T>.None;
    }
}