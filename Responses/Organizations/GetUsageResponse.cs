namespace TursoPlatformApi.Responses.Organizations
{
    public class GetUsageResponse
    {
        public OrganizationUsage organization { get; set; }

        public TotalUsage total { get; set; }
    }

    /// <summary>
    /// Represents the organization usage object, containing the total usage for rows read and written, as well as the total storage size (in bytes).
    /// </summary>
    public class OrganizationUsage
    {
        /// <summary>
        /// The UUID of the organization.
        /// </summary>
        public string uuid { get; set; }

        /// <summary>
        /// The usage object for the organization.
        /// </summary>
        public Usage usage { get; set; }

        /// <summary>
        /// The databases for the organization and their usage.
        /// </summary>
        public Database[] databases { get; set; }

        /// <summary>
        /// The total usage for the databases.
        /// </summary>
        public TotalUsage total { get; set; }
    }

    /// <summary>
    /// Represents the usage object for the organization.
    /// </summary>
    public class Usage
    {
        /// <summary>
        /// The number of rows read allowed for the specific plan.
        /// </summary>
        public long rows_read { get; set; }

        /// <summary>
        /// The number of rows written allowed for the specific plan.
        /// </summary>
        public long rows_written { get; set; }

        /// <summary>
        /// The number of databases allowed for the specific plan.
        /// </summary>
        public int databases { get; set; }

        /// <summary>
        /// The number of locations allowed for the specific plan.
        /// </summary>
        public int locations { get; set; }

        /// <summary>
        /// The amount of storage allowed for the specific plan, in bytes.
        /// </summary>
        public long storage_bytes { get; set; }

        /// <summary>
        /// The number of groups allowed for the specific plan.
        /// </summary>
        public int groups { get; set; }

        /// <summary>
        /// The number of bytes synced allowed for the specific plan, in bytes.
        /// </summary>
        public long bytes_synced { get; set; }
    }

    /// <summary>
    /// Represents a database and its usage.
    /// </summary>
    public class Database
    {
        /// <summary>
        /// The UUID of the database.
        /// </summary>
        public object uuid { get; set; }

        /// <summary>
        /// The usage objects for instances of the current database.
        /// </summary>
        public Instance[] instances { get; set; }

        /// <summary>
        /// The total usage for the database.
        /// </summary>
        public TotalUsage total { get; set; }
    }

    /// <summary>
    /// Represents an instance of a database and its usage.
    /// </summary>
    public class Instance
    {
        /// <summary>
        /// The instance universal unique identifier (UUID).
        /// </summary>
        public string uuid { get; set; }

        /// <summary>
        /// The usage for the current database instance.
        /// </summary>
        public InstanceUsage usage { get; set; }
    }

    /// <summary>
    /// Represents the usage for a database instance.
    /// </summary>
    public class InstanceUsage
    {
        /// <summary>
        /// The total rows read in the time period.
        /// </summary>
        public long rows_read { get; set; }

        /// <summary>
        /// The total rows written in the time period.
        /// </summary>
        public long rows_written { get; set; }

        /// <summary>
        /// The total storage used.
        /// </summary>
        public long storage_bytes { get; set; }

        /// <summary>
        /// The total bytes synced.
        /// </summary>
        public long bytes_synced { get; set; }
    }

    /// <summary>
    /// Represents the total usage for a database.
    /// </summary>
    public class TotalUsage
    {
        /// <summary>
        /// The total rows read in the time period.
        /// </summary>
        public long rows_read { get; set; }

        /// <summary>
        /// The total rows written in the time period.
        /// </summary>
        public long rows_written { get; set; }

        /// <summary>
        /// The total storage used.
        /// </summary>
        public long storage_bytes { get; set; }

        /// <summary>
        /// The total bytes synced.
        /// </summary>
        public long bytes_synced { get; set; }
    }
}
