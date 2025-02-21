namespace TursoPlatformApi.Responses.Organizations
{
    internal class GetUsageResponse
    {
        public OrganizationUsage Organization { get; set; }

        public TotalUsage Total { get; set; }
    }

    /// <summary>
    /// Represents the organization usage object, containing the total usage for rows read and written, as well as the total storage size (in bytes).
    /// </summary>
    public class OrganizationUsage
    {
        /// <summary>
        /// The UUID of the organization.
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// The usage object for the organization.
        /// </summary>
        public Usage Usage { get; set; }

        /// <summary>
        /// The databases for the organization and their usage.
        /// </summary>
        public Database[] Databases { get; set; }

        /// <summary>
        /// The total usage for the databases.
        /// </summary>
        public TotalUsage Total { get; set; }
    }

    /// <summary>
    /// Represents the usage object for the organization.
    /// </summary>
    public class Usage
    {
        /// <summary>
        /// The number of rows read allowed for the specific plan.
        /// </summary>
        public long RowsRead { get; set; }

        /// <summary>
        /// The number of rows written allowed for the specific plan.
        /// </summary>
        public long RowsWritten { get; set; }

        /// <summary>
        /// The number of databases allowed for the specific plan.
        /// </summary>
        public int Databases { get; set; }

        /// <summary>
        /// The number of locations allowed for the specific plan.
        /// </summary>
        public int Locations { get; set; }

        /// <summary>
        /// The amount of storage allowed for the specific plan, in bytes.
        /// </summary>
        public long StorageBytes { get; set; }

        /// <summary>
        /// The number of groups allowed for the specific plan.
        /// </summary>
        public int Groups { get; set; }

        /// <summary>
        /// The number of bytes synced allowed for the specific plan, in bytes.
        /// </summary>
        public long BytesSynced { get; set; }
    }

    /// <summary>
    /// Represents a database and its usage.
    /// </summary>
    public class Database
    {
        /// <summary>
        /// The UUID of the database.
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// The usage objects for instances of the current database.
        /// </summary>
        public Instance[] Instances { get; set; }
    }

    /// <summary>
    /// Represents an instance of a database and its usage.
    /// </summary>
    public class Instance
    {
        /// <summary>
        /// The instance universal unique identifier (UUID).
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// The usage for the current database instance.
        /// </summary>
        public InstanceUsage Usage { get; set; }
    }

    /// <summary>
    /// Represents the usage for a database instance.
    /// </summary>
    public class InstanceUsage
    {
        /// <summary>
        /// The total rows read in the time period.
        /// </summary>
        public long RowsRead { get; set; }

        /// <summary>
        /// The total rows written in the time period.
        /// </summary>
        public long RowsWritten { get; set; }

        /// <summary>
        /// The total storage used.
        /// </summary>
        public long StorageBytes { get; set; }

        /// <summary>
        /// The total bytes synced.
        /// </summary>
        public long BytesSynced { get; set; }
    }

    /// <summary>
    /// Represents the total usage for a database.
    /// </summary>
    public class TotalUsage
    {
        /// <summary>
        /// The total rows read in the time period.
        /// </summary>
        public long Rowsread { get; set; }

        /// <summary>
        /// The total rows written in the time period.
        /// </summary>
        public long RowsWritten { get; set; }

        /// <summary>
        /// The total storage used.
        /// </summary>
        public long StorageBytes { get; set; }

        /// <summary>
        /// The total bytes synced.
        /// </summary>
        public long BytesSynced { get; set; }
    }
}
