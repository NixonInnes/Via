namespace Via;

public static class ResultConversion
{
    extension(Result result)
    {
        /// <summary>Converts a non-generic result into a generic <c>Result&lt;Unit&gt;</c>.</summary>
        public Result<Unit> ToResultUnit()
            => result.IsSuccess
                ? Result<Unit>.Success(Unit.Value)
                : Result<Unit>.Failure(result.Error.OrUnknown());
    }

    extension(Result<Unit> result)
    {
        /// <summary>Converts a <c>Result&lt;Unit&gt;</c> into a non-generic result.</summary>
        public Result ToResult()
            => result.IsSuccess
                ? Result.Success()
                : Result.Failure(result.Error.OrUnknown());
    }
}
