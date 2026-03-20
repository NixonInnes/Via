namespace Via;

public static class ResultCompositionAsync
{
    extension(Result result)
    {
        /// <summary>Asynchronously chains a computation that returns `Result` when successful.</summary>
        public Task<Result> BindAsync(Func<Task<Result>> bind)
        {
            ArgumentNullException.ThrowIfNull(bind);

            if (result.IsFailure)
            {
                return Task.FromResult(Result.Failure(result.Error.OrUnknown()));
            }

            return bind();
        }
    }
}