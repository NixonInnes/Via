namespace Via;

public static class ResultComposition
{
    extension(Result result)
    {
        /// <summary>Chains a computation that runs only when the result is successful.</summary>
        public Result Bind(Func<Result> bind)
        {
            ArgumentNullException.ThrowIfNull(bind);

            return result.IsSuccess ? bind() : result;
        }
    }   

    extension(Result<Result> result)
    {
        /// <summary>Flattens a nested result (propagates outer failure, otherwise returns the inner result).</summary>
        public Result Unwrap()
            => result.IsSuccess
                ? result.Value
                : Result.Failure(result.Error.OrUnknown());
    }
}