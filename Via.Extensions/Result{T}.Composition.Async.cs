namespace Via;

public static class ResultTCompositionAsync
{
    extension<T>(Result<T> result)
    {
        /// <summary>Asynchronously chains a computation that returns a new result when successful.</summary>
        public Task<Result<TOut>> BindAsync<TOut>(Func<T?, Task<Result<TOut>>> bind)
        {
            ArgumentNullException.ThrowIfNull(bind);

            if (result.IsFailure)
            {
                return Task.FromResult(Result<TOut>.Failure(result.Error.GetValueOrDefault()));
            }

            return bind(result.Value);
        }

        /// <summary>Asynchronously chains a computation that returns a non-generic result when successful.</summary>
        public Task<Result> BindAsync(Func<T?, Task<Result>> bind)
        {
            ArgumentNullException.ThrowIfNull(bind);

            if (result.IsFailure)
            {
                return Task.FromResult(Result.Failure(result.Error.GetValueOrDefault()));
            }

            return bind(result.Value);
        }
    }
}