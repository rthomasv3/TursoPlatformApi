namespace TursoPlatformApi.Responses.ApiTokens
{
    /// <summary>
    /// The created API token and information.
    /// </summary>
    public class CreatedApiToken
    {
        /// <summary>
        /// The token name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The token id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The actual token contents as a JWT. This is used with the Bearer header, see Authentication for more details. This token is never revealed again.
        /// </summary>
        public string Token { get; set; }
    }
}
