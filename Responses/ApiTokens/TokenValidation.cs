namespace TursoPlatformApi.Responses.ApiTokens
{
    internal class TokenValidation
    {
        /// <summary>
        /// The time of expiration for the provided token in unix epoch seconds, or -1 if there is no expiration.
        /// </summary>
        public int exp { get; set; }
    }
}
