namespace Via;

public static class ObjectConversion
{
    extension<T>(T obj) where T : notnull
    {
        /// <summary>Wraps a non-null value in a successful result.</summary>
        public Result<T> ToResult()
        {
            return Result<T>.Success(obj);
        }

        /// <summary>Wraps a non-null value in a successful result if the predicate is satisfied; otherwise returns failure.</summary>
        public Result<T> ToResult(Func<T, bool> predicate, Error? error = null)
        {
            ArgumentNullException.ThrowIfNull(predicate);

            return predicate(obj)
                ? Result<T>.Success(obj)
                : Result<T>.Failure(error ?? new ViaError("Predicate not satisfied."));
        }
    }

    extension<T>(T? obj) where T : notnull
    {
        /// <summary>Wraps a possibly-null value in a result, optionally treating null as success.</summary>
        public Result<T> ToResult(Error? error = null, bool nullAsSuccess = false)
        {
            if (obj is null)
            {
                return nullAsSuccess
                    ? Result<T>.Success(obj!)
                    : Result<T>.Failure(error ?? new ViaError("Value is null."));
            }

            return Result<T>.Success(obj);
        }
    }

    extension<T>(T? obj) where T : notnull
    {
        /// <summary>Converts a possibly-null value into Some/None.</summary>
        public Option<T> ToOption()
        {
            return obj is not null
                ? Option<T>.Some(obj)
                : Option<T>.None;
        }
    }
}