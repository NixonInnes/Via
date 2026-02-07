namespace Via;

public static class ResultTComposition
{
    extension<T>(Result<T> result)
    {
        /// <summary>Chains a computation that returns a new result when successful.</summary>
        public Result<TOut> Bind<TOut>(Func<T?, Result<TOut>> bind)
        {
            ArgumentNullException.ThrowIfNull(bind);

            return result.IsSuccess
                ? bind(result.Value)
                : Result<TOut>.Failure(result.Error.OrUnknown());
        }

        /// <summary>Chains a computation that returns a non-generic result when successful.</summary>
        public Result Bind(Func<T?, Result> bind)
        {
            ArgumentNullException.ThrowIfNull(bind);

            return result.IsSuccess
                ? bind(result.Value)
                : Result.Failure(result.Error.OrUnknown());
        }
    }

    extension<T>(Result<Result<T>> result)
    {
        /// <summary>Flattens a nested result (propagates outer failure, otherwise returns the inner result).</summary>
        public Result<T> Unwrap()
            => result.IsSuccess
                ? result.Value
                : Result<T>.Failure(result.Error.OrUnknown());
    }
}