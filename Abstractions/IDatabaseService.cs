using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TursoPlatformApi.Responses;

namespace TursoPlatformApi.Abstractions
{
    public interface IDatabaseService
    {
        /// <summary>
        /// Returns a list of databases belonging to the organization or user.
        /// </summary>
        /// <param name="group">Filter databases by group name.</param>
        /// <param name="schema">The schema database name that can be used to get databases that belong to that parent schema.</param>
        /// <returns>An Optional wrapped list of databases.</returns>
        Task<Optional<List<Database>>> List(string group = null, string schema = null);

        /// <summary>
        /// Creates a new database in a group for the organization or user.
        /// </summary>
        /// <param name="name">The name of the new database. Must contain only lowercase letters, numbers, dashes. No longer than 64 characters.</param>
        /// <param name="group">The name of the group where the database should be created. The group must already exist.</param>
        /// <param name="seedType">The type of seed to be used to create a new database. Available options: database, dump</param>
        /// <param name="seedName">The name of the existing database when database is used as a seed type.</param>
        /// <param name="seedUrl">The URL returned by upload dump can be used with the dump seed type.</param>
        /// <param name="seedTimestamp">A formatted ISO 8601 recovery point to create a database from. This must be within the last 24 hours, or 30 days on the scaler plan.</param>
        /// <param name="sizeLimit">The maximum size of the database in bytes. Values with units are also accepted, e.g. 1mb, 256mb, 1gb.</param>
        /// <param name="isScheme">[Deprecated] Mark this database as the parent schema database that updates child databases with any schema changes.</param>
        /// <param name="schema">[Deprecated] The name of the parent database to use as the schema.</param>
        /// <returns>An Optional wrapped database.</returns>
        Task<Optional<Database>> Create(string name, string group, string seedType = null,
            string seedName = null, string seedUrl = null, string seedTimestamp = null,
            string sizeLimit = null, bool isScheme = false, string schema = null);

        /// <summary>
        /// Returns a database belonging to the organization or user.
        /// </summary>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns>An Optional wrapped database.</returns>
        Task<Optional<Database>> Retrieve(string databaseName);

        /// <summary>
        /// Retrieve an individual database configuration belonging to the organization or user.
        /// </summary>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns></returns>
        Task<Optional<DatabaseConfiguration>> RetrieveConfiguration(string databaseName);




        /// <summary>
        /// Delete a database belonging to the organization or user.
        /// </summary>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns>The name of the database that was deleted.</returns>
        Task<Optional<string>> Delete(string databaseName);
    }
}
