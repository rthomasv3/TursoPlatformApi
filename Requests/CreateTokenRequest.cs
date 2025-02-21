namespace TursoPlatformApi.Requests
{
    /// <summary>
    /// Represents the body of the request containing additional context such as claims required for the token.
    /// </summary>
    public class CreateTokenRequest
    {
        /// <summary>
        /// The permissions for the token.
        /// </summary>
        public Permissions permissions { get; set; }
    }

    /// <summary>
    /// Represents the permissions for the token.
    /// </summary>
    public class Permissions
    {
        /// <summary>
        /// Read ATTACH permission for the token.
        /// </summary>
        public ReadAttach read_attach { get; set; }
    }

    /// <summary>
    /// Represents the read ATTACH permission for the token.
    /// </summary>
    public class ReadAttach
    {
        /// <summary>
        /// The databases associated with the read ATTACH permission.
        /// </summary>
        public string[] databases { get; set; }
    }
}
