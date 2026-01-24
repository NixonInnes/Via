namespace Via;

public static class ResultTTransformation
{
    extension<T>(Result<T> result)
    {
        /// <summary>Transforms the success value while preserving failure.</summary>
        public Result<TOut> Map<TOut>(Func<T?, TOut> map)
        {
            ArgumentNullException.ThrowIfNull(map);

            return result.IsSuccess
                ? Result<TOut>.Success(map(result.Value))
                : Result<TOut>.Failure(result.Error.GetValueOrDefault());
        }

        /// <summary>Transforms the error value when the result is a failure.</summary>
        public Result<T> MapError(Func<Error, Error> mapError)
        {
            ArgumentNullException.ThrowIfNull(mapError);

            return result.IsSuccess ? result : Result<T>.Failure(mapError(result.Error.GetValueOrDefault()));
        }
    }
}