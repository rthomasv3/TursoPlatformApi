using System.Collections.Generic;

namespace TursoPlatformApi.Responses.Databases
{
    /// <summary>
    /// Represents the response containing the top queries performed on a database.
    /// </summary>
    public class StatsResponse
    {
        /// <summary>
        /// The top queries performed on the given database as well as the total rows read and written.
        /// </summary>
        public List<TopQuery> top_queries { get; set; }
    }

    /// <summary>
    /// Represents a single top query with its details.
    /// </summary>
    public class TopQuery
    {
        /// <summary>
        /// A string representing the SQL query executed.
        /// </summary>
        public string query { get; set; }

        /// <summary>
        /// An integer indicating the number of rows read by the query, which reflects the volume of data the query processed from the database.
        /// </summary>
        public int rows_read { get; set; }

        /// <summary>
        /// An integer indicating the number of rows written (inserted, updated, or deleted) by the query, which reflects the impact of the query on the database data.
        /// </summary>
        public int rows_written { get; set; }
    }
}
