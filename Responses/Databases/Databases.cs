using System.Collections.Generic;

namespace TursoPlatformApi.Responses.Databases
{
    /// <summary>
    /// Represents the response containing a list of databases.
    /// </summary>
    public class Databases
    {
        /// <summary>
        /// A list of database objects.
        /// </summary>
        public List<Database> databases { get; set; }
    }
}
