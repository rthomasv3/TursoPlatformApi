using System.Collections.Generic;

namespace TursoPlatformApi.Responses
{
    public class Optional<T>
    {
        public Optional()
        {
            Value = default;
            HasValue = false;
        }

        public Optional(T value, string status = null, string message = null)
        {
            Value = value;
            HasValue = !EqualityComparer<T>.Default.Equals(value, default);
            Status = status;
            Message = message;
        }

        public T Value { get; private set; }
        public bool HasValue { get; private set; }
        public string Status { get; private set; }
        public string Message { get; private set; }

        public static implicit operator Optional<T>(T value)
        {
            return new Optional<T>(value);
        }
        public static implicit operator T(Optional<T> optional)
        {
            return optional.Value;
        }
    }
}
