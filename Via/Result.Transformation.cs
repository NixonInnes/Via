namespace Via;

public static class ResultTransformation
{
    extension(Result result)
    {
        /// <summary>Transforms the error value when the result is a failure.</summary>
        public Result MapError(Func<Error, Error> mapError)
        {
            ArgumentNullException.ThrowIfNull(mapError);

            return result.IsSuccess
                ? Result.Success()
                : Result.Failure(mapError(result.Error.GetValueOrDefault()));
        }
    }
}