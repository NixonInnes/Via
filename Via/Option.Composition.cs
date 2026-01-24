namespace Via;

public static class OptionComposition
{
    extension<T>(Option<T> option) where T : notnull
    {
        /// <summary>Chains a computation that returns a new option when Some.</summary>
        public Option<TOut> Bind<TOut>(Func<T, Option<TOut>> bind)
            where TOut : notnull
        {
            ArgumentNullException.ThrowIfNull(bind);

            return option.IsSome ? bind(option.Value) : Option<TOut>.None;
        }
    }

    extension<T>(Option<Option<T>> option) where T : notnull
    {
        /// <summary>Flattens a nested option (outer None stays None; otherwise returns inner option).</summary>
        public Option<T> Unwrap()
            => option.IsSome ? option.Value : Option<T>.None;
    }
}