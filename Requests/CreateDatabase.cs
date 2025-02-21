namespace TursoPlatformApi.Requests
{
    /// <summary>
    /// Represents the data required to create a new database.
    /// </summary>
    internal class CreateDatabase
    {
        /// <summary>
        /// The name of the new database. Must contain only lowercase letters, numbers, dashes. No longer than 64 characters.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The name of the group where the database should be created. The group must already exist.
        /// </summary>
        public string group { get; set; }

        /// <summary>
        /// The seed configuration for creating the database.
        /// </summary>
        public Seed seed { get; set; }

        /// <summary>
        /// The maximum size of the database in bytes. Values with units are also accepted, e.g. 1mb, 256mb, 1gb.
        /// </summary>
        public string size_limit { get; set; }

        /// <summary>
        /// Mark this database as the parent schema database that updates child databases with any schema changes. See Multi-DB Schemas.
        /// </summary>
        public bool is_schema { get; set; }

        /// <summary>
        /// The name of the parent database to use as the schema. See Multi-DB Schemas.
        /// </summary>
        public string schema { get; set; }
    }

    /// <summary>
    /// Represents the seed configuration for creating a new database.
    /// </summary>
    public class Seed
    {
        /// <summary>
        /// The type of seed to be used to create a new database.
        /// Available options: database, dump
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// The name of the existing database when database is used as a seed type.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The URL returned by upload dump can be used with the dump seed type.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// A formatted ISO 8601 recovery point to create a database from. This must be within the last 24 hours, or 30 days on the scaler plan.
        /// </summary>
        public string timestamp { get; set; }
    }
}
