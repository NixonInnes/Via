namespace Via;

public static class ResultSideEffects
{
    extension(Result result)
    {
        /// <summary>Runs an action when the result is successful and returns the original result.</summary>
        public Result OnSuccess(Action action)
        {
            ArgumentNullException.ThrowIfNull(action);

            if (result.IsSuccess)
            {
                action();
            }

            return result;
        }

        /// <summary>Runs an action when the result is a failure and returns the original result.</summary>
        public Result OnFailure(Action<Error> action)
        {
            ArgumentNullException.ThrowIfNull(action);

            if (result.IsFailure)
            {
                action(result.Error.OrUnknown());
            }

            return result;
        }
    }
}