namespace Via;

public static class ResultTSideEffects
{
    extension<T>(Result<T> result)
    {
        /// <summary>Runs an action with the success value and returns the original result.</summary>
        public Result<T> OnSuccess(Action<T?> action)
        {
            ArgumentNullException.ThrowIfNull(action);

            if (result.IsSuccess)
            {
                action(result.Value);
            }

            return result;
        }

        /// <summary>Runs an action when the result is a failure and returns the original result.</summary>
        public Result<T> OnFailure(Action<Error> action)
        {
            ArgumentNullException.ThrowIfNull(action);

            if (result.IsFailure)
            {
                action(result.Error.GetValueOrDefault());
            }

            return result;
        }
    }
}