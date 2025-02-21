namespace TursoPlatformApi.Responses.Databases
{
    /// <summary>
    /// Database configuration information.
    /// </summary>
    public class DatabaseConfiguration
    {
        /// <summary>
        /// The maximum size of the database in bytes. Values with units are also accepted, e.g. 1mb, 256mb, 1gb.
        /// </summary>
        public string SizeLimit { get; set; }

        /// <summary>
        /// Allow or disallow attaching databases to the current database.
        /// </summary>
        public bool AllowAttach { get; set; }

        /// <summary>
        /// Block all database reads.
        /// </summary>
        public bool BlockReads { get; set; }

        /// <summary>
        /// Block all database writes.
        /// </summary>
        public bool BlockWrites { get; set; }
    }
}
