using System.Diagnostics.CodeAnalysis;

namespace Via;

public static class OptionInspection
{
    extension<T>(Option<T> option) where T : notnull
    {
        /// <summary>Gets the value if the option is Some.</summary>
        public bool TryGetValue([NotNullWhen(true)] out T? value)
        {
            if (option.IsSome)
            {
                value = option.Value;
                return true;
            }

            value = default;
            return false;
        }
    }
}