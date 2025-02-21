using System.Collections.Generic;

namespace TursoPlatformApi.Responses.Databases
{
    /// <summary>
    /// Represents the response containing database usage information.
    /// </summary>
    public class DatabaseUsageResponse
    {
        /// <summary>
        /// The database usage object, containing the total and individual instance usage for rows read and written, as well as the total storage size (in bytes).
        /// </summary>
        public DatabaseUsage database { get; set; }

        /// <summary>
        /// The total usage for the database.
        /// </summary>
        public TotalUsage total { get; set; }
    }

    /// <summary>
    /// Represents the database usage object.
    /// </summary>
    public class DatabaseUsage
    {
        /// <summary>
        /// The universal unique identifier (UUID) of the database.
        /// </summary>
        public string uuid { get; set; }

        /// <summary>
        /// The usage objects for instances of the current database.
        /// </summary>
        public List<UsageInstance> instances { get; set; }

        /// <summary>
        /// The total usage for the database.
        /// </summary>
        public TotalUsage total { get; set; }
    }

    /// <summary>
    /// Represents the usage information for a specific database instance.
    /// </summary>
    public class UsageInstance
    {
        /// <summary>
        /// The universal unique identifier (UUID) of the instance.
        /// </summary>
        public string uuid { get; set; }

        /// <summary>
        /// The usage for the current database instance.
        /// </summary>
        public Usage usage { get; set; }
    }

    /// <summary>
    /// Represents the usage details for a database instance.
    /// </summary>
    public class Usage
    {
        /// <summary>
        /// The total rows read in the time period.
        /// </summary>
        public int rows_read { get; set; }

        /// <summary>
        /// The total rows written in the time period.
        /// </summary>
        public int rows_written { get; set; }

        /// <summary>
        /// The total storage used.
        /// </summary>
        public int storage_bytes { get; set; }

        /// <summary>
        /// The total bytes synced.
        /// </summary>
        public int bytes_synced { get; set; }
    }

    /// <summary>
    /// Represents the total usage for the database.
    /// </summary>
    public class TotalUsage
    {
        /// <summary>
        /// The total rows read in the time period.
        /// </summary>
        public int rows_read { get; set; }

        /// <summary>
        /// The total rows written in the time period.
        /// </summary>
        public int rows_written { get; set; }

        /// <summary>
        /// The total storage used.
        /// </summary>
        public int storage_bytes { get; set; }

        /// <summary>
        /// The total bytes synced.
        /// </summary>
        public int bytes_synced { get; set; }
    }
}
