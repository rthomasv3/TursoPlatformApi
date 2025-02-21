using System;
using System.Collections.Generic;

namespace TursoPlatformApi.Responses
{
    /// <summary>
    /// Class used to wrap return types. Provides error and status messages returned from the API.
    /// </summary>
    public class Optional<T>
    {
        /// <summary>
        /// Creates a new default <see cref="Optional{T}"/> instance.
        /// </summary>
        public Optional()
        {
            Value = default;
            HasValue = false;
        }

        /// <summary>
        /// Create a new <see cref="Optional{T}"/> instance.
        /// </summary>
        /// <param name="value">The value to wrap.</param>
        /// <param name="status">API status code.</param>
        /// <param name="message">Any error messages.</param>
        public Optional(T value, string status = null, string message = null)
        {
            Value = value;
            HasValue = !EqualityComparer<T>.Default.Equals(value, default);
            Status = status;
            Message = message;
        }

        /// <summary>
        /// The wrapped value.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// True if the value provided is not equal to default.
        /// </summary>
        public bool HasValue { get; private set; }

        /// <summary>
        /// The status code return from the API when there is an error.
        /// </summary>
        public string Status { get; private set; }

        /// <summary>
        /// The message returned from the API when there is an error.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Implicitly converts a value of type <typeparamref name="T"/> to an <see cref="Optional{T}"/> instance.
        /// This allows for seamless creation of an <see cref="Optional{T}"/> object by directly assigning a value of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value">The value to wrap in an <see cref="Optional{T}"/> instance.</param>

        public static implicit operator Optional<T>(T value)
        {
            return new Optional<T>(value);
        }

        /// <summary>
        /// Implicitly converts an <see cref="Optional{T}"/> instance to its underlying value of type <typeparamref name="T"/>.
        /// This allows for seamless extraction of the wrapped value from an <see cref="Optional{T}"/> object.
        /// </summary>
        /// <param name="optional">The <see cref="Optional{T}"/> instance to unwrap.</param>
        /// <returns>The underlying value of type <typeparamref name="T"/> contained in the <see cref="Optional{T}"/> instance.</returns>
        /// <exception cref="NullReferenceException">Thrown if the <see cref="Optional{T}"/> instance contains no value (e.g., is null or represents an error state).</exception>
        public static implicit operator T(Optional<T> optional)
        {
            return optional.Value;
        }
    }
}
