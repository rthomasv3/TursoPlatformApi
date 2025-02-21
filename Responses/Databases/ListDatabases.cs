using System.Collections.Generic;

namespace TursoPlatformApi.Responses.Databases
{
    /// <summary>
    /// Represents the response containing a list of databases.
    /// </summary>
    internal class ListDatabases
    {
        /// <summary>
        /// A list of database objects.
        /// </summary>
        public List<Database> Databases { get; set; }
    }
}
