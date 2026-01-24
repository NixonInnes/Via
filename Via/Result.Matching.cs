namespace Via;

public static class ResultMatching
{
    extension(Result result)
    {
        /// <summary>Maps a success or failure result into a single output value.</summary>
        public TOut Match<TOut>(Func<TOut> onSuccess, Func<Error, TOut> onFailure)
        {
            ArgumentNullException.ThrowIfNull(onSuccess);
            ArgumentNullException.ThrowIfNull(onFailure);

            return result.IsSuccess
                ? onSuccess()
                : onFailure(result.Error.GetValueOrDefault());
        }

        /// <summary>Executes the matching callback for success or failure.</summary>
        public void Switch(Action onSuccess, Action<Error> onFailure)
        {
            ArgumentNullException.ThrowIfNull(onSuccess);
            ArgumentNullException.ThrowIfNull(onFailure);

            if (result.IsSuccess)
            {
                onSuccess();
                return;
            }

            onFailure(result.Error.GetValueOrDefault());
        }
    }
}