namespace TursoPlatformApi
{
    /// <summary>
    /// Class used to provide configuration options.
    /// </summary>
    public class TursoAppSettings
    {
        /// <summary>
        /// The default organization slug to use when not provided.
        /// </summary>
        public string DefaultOrganizationSlug { get; set; }

        /// <summary>
        /// The Turso API auth token.
        /// </summary>
        public string AuthToken { get; set; }

        /// <summary>
        /// The name of the client configured for use with the Turso API.
        /// </summary>
        public string TursoClientName { get; set; } = "TursoClient";

        /// <summary>
        /// The name of the default client.
        /// </summary>
        public string DefaultClientName { get; set; } = "DefaultClient";
    }
}
