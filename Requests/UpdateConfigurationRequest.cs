namespace TursoPlatformApi.Requests
{
    internal class UpdateConfigurationRequest
    {
        /// <summary>
        /// The maximum size of the database in bytes. Values with units are also accepted, e.g. 1mb, 256mb, 1gb.
        /// </summary>
        public string size_limit { get; set; }

        /// <summary>
        /// Allow or disallow attaching databases to the current database.
        /// </summary>
        public bool? allow_attach { get; set; }

        /// <summary>
        /// Block all database reads.
        /// </summary>
        public bool? block_reads { get; set; }

        /// <summary>
        /// Block all database writes.
        /// </summary>
        public bool? block_writes { get; set; }
    }
}
