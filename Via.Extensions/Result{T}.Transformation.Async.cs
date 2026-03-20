namespace Via;

public static class ResultTTransformationAsync
{
    extension<T>(Result<T> result)
    {
        /// <summary>Asynchronously transforms the success value while preserving failure.</summary>
        public Task<Result<TOut>> MapAsync<TOut>(Func<T?, Task<TOut>> map)
        {
            ArgumentNullException.ThrowIfNull(map);

            if (result.IsFailure)
            {
                return Task.FromResult(Result<TOut>.Failure(result.Error.OrUnknown()));
            }

            return MapAsyncSuccess(map, result.Value);
        }

        private static async Task<Result<TOut>> MapAsyncSuccess<TOut>(Func<T?, Task<TOut>> map, T? value)
        {
            var mapped = await map(value).ConfigureAwait(false);
            return Result<TOut>.Success(mapped);
        }
    }
}