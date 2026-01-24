namespace Via;

public static class ResultTLinq
{
    extension<T>(Result<T> result)
    {
        /// <summary>LINQ Select for Result (maps the success value).</summary>
        public Result<TOut> Select<TOut>(Func<T?, TOut> selector)
        {
            ArgumentNullException.ThrowIfNull(selector);

            return result.IsSuccess
                ? Result<TOut>.Success(selector(result.Value))
                : Result<TOut>.Failure(result.Error.GetValueOrDefault());
        }

        /// <summary>LINQ SelectMany for Result (binds and projects).</summary>
        public Result<TOut> SelectMany<TMiddle, TOut>(
            Func<T?, Result<TMiddle>> bind,
            Func<T?, TMiddle?, TOut> project)
        {
            ArgumentNullException.ThrowIfNull(bind);
            ArgumentNullException.ThrowIfNull(project);

            if (result.IsFailure)
            {
                return Result<TOut>.Failure(result.Error.GetValueOrDefault());
            }

            var middle = bind(result.Value);
            if (middle.IsFailure)
            {
                return Result<TOut>.Failure(middle.Error.GetValueOrDefault());
            }

            return Result<TOut>.Success(project(result.Value, middle.Value));
        }

        /// <summary>Filters a successful result by predicate, otherwise returns failure with the provided error.</summary>
        public Result<T> Where(Func<T?, bool> predicate, Error error)
        {
            ArgumentNullException.ThrowIfNull(predicate);

            if (result.IsFailure)
            {
                return result;
            }

            return predicate(result.Value) ? result : Result<T>.Failure(error);
        }
    }
}
