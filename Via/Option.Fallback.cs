namespace Via;

public static class OptionFallback
{
    extension<T>(Option<T> option) where T : notnull
    {
        /// <summary>Returns the value when Some, otherwise returns the provided fallback value.</summary>
        public T ValueOr(T fallback)
            => option.IsSome ? option.Value : fallback;

        /// <summary>Returns the value when Some, otherwise evaluates and returns a fallback value.</summary>
        public T ValueOr(Func<T> fallback)
        {
            ArgumentNullException.ThrowIfNull(fallback);
            return option.IsSome ? option.Value : fallback();
        }
    }
}