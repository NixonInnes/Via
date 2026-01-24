namespace Via;

public static class OptionLinq
{
    extension<T>(Option<T> option) where T : notnull
    {
        /// <summary>LINQ Select for Option (maps the contained value when Some).</summary>
        public Option<TOut> Select<TOut>(Func<T, TOut> selector)
            where TOut : notnull
        {
            ArgumentNullException.ThrowIfNull(selector);

            return option.IsSome ? Option<TOut>.Some(selector(option.Value)) : Option<TOut>.None;
        }

        /// <summary>LINQ SelectMany for Option (binds and projects).</summary>
        public Option<TOut> SelectMany<TMiddle, TOut>(
            Func<T, Option<TMiddle>> bind,
            Func<T, TMiddle, TOut> project)
            where TMiddle : notnull
            where TOut : notnull
        {
            ArgumentNullException.ThrowIfNull(bind);
            ArgumentNullException.ThrowIfNull(project);

            if (option.IsNone)
            {
                return Option<TOut>.None;
            }

            var middle = bind(option.Value);
            if (middle.IsNone)
            {
                return Option<TOut>.None;
            }

            return Option<TOut>.Some(project(option.Value, middle.Value));
        }

        /// <summary>Filters an option by predicate (Some that fails the predicate becomes None).</summary>
        public Option<T> Where(Func<T, bool> predicate)
        {
            ArgumentNullException.ThrowIfNull(predicate);
            return option.IsSome && predicate(option.Value) ? option : Option<T>.None;
        }
    }
}
