using System.Text.Json.Serialization;

namespace TursoPlatformApi.Responses.Databases
{
    /// <summary>
    /// Represents a database object returned by the API.
    /// </summary>
    public class Database
    {
        /// <summary>
        /// The database name, unique across your organization.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The database universal unique identifier (UUID).
        /// </summary>
        [JsonPropertyName("DbId")]
        public string DbId { get; set; }

        /// <summary>
        /// The DNS hostname used for client libSQL and HTTP connections.
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// The current status for blocked reads.
        /// </summary>
        public bool BlockReads { get; set; }

        /// <summary>
        /// The current status for blocked writes.
        /// </summary>
        public bool BlockWrites { get; set; }

        /// <summary>
        /// The current status for allowing the database to be attached to another.
        /// </summary>
        public bool AllowAttach { get; set; }

        /// <summary>
        /// A list of regions for the group the database belongs to.
        /// </summary>
        public string[] Regions { get; set; }

        /// <summary>
        /// The primary region location code the group the database belongs to.
        /// </summary>
        [JsonPropertyName("primaryRegion")]
        public string PrimaryRegion { get; set; }

        /// <summary>
        /// The string representing the object type.
        /// </summary>
        public string Type { get; set; } = "logical";

        /// <summary>
        /// The current libSQL version the database is running.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The name of the group the database belongs to.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// If this database controls other child databases then this will be true. See Multi-DB Schemas.
        /// </summary>
        public bool IsSchema { get; set; }

        /// <summary>
        /// The name of the parent database that owns the schema for this database. See Multi-DB Schemas.
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// The current status of the database. If true, the database is archived and requires a manual unarchive step.
        /// </summary>
        public bool Archived { get; set; }
    }
}
