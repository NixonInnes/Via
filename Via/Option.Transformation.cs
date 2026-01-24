namespace Via;

public static class OptionTransformation
{
    extension<T>(Option<T> option) where T : notnull
    {
        /// <summary>Transforms the contained value when Some; preserves None.</summary>
        public Option<TOut> Map<TOut>(Func<T, TOut> map)
            where TOut : notnull
        {
            ArgumentNullException.ThrowIfNull(map);

            return option.IsSome
                ? Option<TOut>.Some(map(option.Value))
                : Option<TOut>.None;
        }
    }
}