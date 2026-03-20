namespace Via;

public static class ResultTMatching
{
    extension<T>(Result<T> result)
    {
        /// <summary>Maps a successful value or failure error into a single output value.</summary>
        public TOut Match<TOut>(Func<T, TOut> onSuccess, Func<Error, TOut> onFailure)
        {
            ArgumentNullException.ThrowIfNull(onSuccess);
            ArgumentNullException.ThrowIfNull(onFailure);

            return result.IsSuccess
                ? onSuccess(result.Value!)
                : onFailure(result.Error.OrUnknown());
        }

        /// <summary>Executes the matching callback for success or failure.</summary>
        public void Switch(Action<T> onSuccess, Action<Error> onFailure)
        {
            ArgumentNullException.ThrowIfNull(onSuccess);
            ArgumentNullException.ThrowIfNull(onFailure);

            if (result.IsSuccess)
            {
                onSuccess(result.Value!);
                return;
            }

            onFailure(result.Error.OrUnknown());
        }
    }
}