namespace Via;

public static class OptionMatching
{
    extension<T>(Option<T> option) where T : notnull
    {
        /// <summary>Maps Some or None into a single output value.</summary>
        public TOut Match<TOut>(Func<T, TOut> onSome, Func<TOut> onNone)
        {
            ArgumentNullException.ThrowIfNull(onSome);
            ArgumentNullException.ThrowIfNull(onNone);

            return option.IsSome ? onSome(option.Value) : onNone();
        }

        /// <summary>Executes the matching callback for Some or None.</summary>
        public void Switch(Action<T> onSome, Action onNone)
        {
            ArgumentNullException.ThrowIfNull(onSome);
            ArgumentNullException.ThrowIfNull(onNone);

            if (option.IsSome)
            {
                onSome(option.Value);
                return;
            }

            onNone();
        }
    }
}