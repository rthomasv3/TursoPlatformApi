namespace TursoPlatformApi.Responses.Databases
{
    /// <summary>
    /// Database instance information.
    /// </summary>
    public class DatabaseInstance
    {
        /// <summary>
        /// The instance universal unique identifier (UUID).
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// The name of the instance (location code).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of database instance this, will be primary or replica. Available options: primary, replica.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The location code for the region this instance is located.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// The DNS hostname used for client libSQL and HTTP connections (specific to this instance only).
        /// </summary>
        public string Hostname { get; set; }
    }
}
