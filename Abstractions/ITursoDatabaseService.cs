using System.Collections.Generic;
using System.Threading.Tasks;
using TursoPlatformApi.Responses;
using TursoPlatformApi.Responses.Databases;

namespace TursoPlatformApi.Abstractions
{
    public interface ITursoDatabaseService
    {
        /// <summary>
        /// Returns a list of databases belonging to the organization or user the client was set up with.
        /// </summary>
        /// <param name="group">Filter databases by group name.</param>
        /// <param name="schema">The schema database name that can be used to get databases that belong to that parent schema.</param>
        /// <returns>A list of database information.</returns>
        Task<Optional<List<Database>>> List(string group = null, string schema = null);

        /// <summary>
        /// Returns a list of databases belonging to the organization or user.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="group">Filter databases by group name.</param>
        /// <param name="schema">The schema database name that can be used to get databases that belong to that parent schema.</param>
        /// <returns>A list of database information.</returns>
        Task<Optional<List<Database>>> List(string organizationSlug, string group = null, string schema = null);

        /// <summary>
        /// Creates a new database in a group for the organization or user the client was set up with.
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
        /// <returns>The created database information.</returns>
        Task<Optional<Database>> Create(string name, string group, string seedType = null,
            string seedName = null, string seedUrl = null, string seedTimestamp = null,
            string sizeLimit = null, bool isScheme = false, string schema = null);

        /// <summary>
        /// Creates a new database in a group for the organization or user.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="name">The name of the new database. Must contain only lowercase letters, numbers, dashes. No longer than 64 characters.</param>
        /// <param name="group">The name of the group where the database should be created. The group must already exist.</param>
        /// <param name="seedType">The type of seed to be used to create a new database. Available options: database, dump</param>
        /// <param name="seedName">The name of the existing database when database is used as a seed type.</param>
        /// <param name="seedUrl">The URL returned by upload dump can be used with the dump seed type.</param>
        /// <param name="seedTimestamp">A formatted ISO 8601 recovery point to create a database from. This must be within the last 24 hours, or 30 days on the scaler plan.</param>
        /// <param name="sizeLimit">The maximum size of the database in bytes. Values with units are also accepted, e.g. 1mb, 256mb, 1gb.</param>
        /// <param name="isScheme">[Deprecated] Mark this database as the parent schema database that updates child databases with any schema changes.</param>
        /// <param name="schema">[Deprecated] The name of the parent database to use as the schema.</param>
        /// <returns>The created database information.</returns>
        Task<Optional<Database>> Create(string organizationSlug, string name, string group, string seedType = null,
            string seedName = null, string seedUrl = null, string seedTimestamp = null, string sizeLimit = null,
            bool isScheme = false, string schema = null);

        /// <summary>
        /// Returns a database belonging to the organization or user the client was set up with.
        /// </summary>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns>The database information.</returns>
        Task<Optional<Database>> Retrieve(string databaseName);

        /// <summary>
        /// Returns a database belonging to the organization or user.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns>The database information.</returns>
        Task<Optional<Database>> Retrieve(string organizationSlug, string databaseName);

        /// <summary>
        /// Retrieve an individual database configuration belonging to the organization or user the client was set up with.
        /// </summary>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns>The database configuration data.</returns>
        Task<Optional<DatabaseConfiguration>> RetrieveConfiguration(string databaseName);


        /// <summary>
        /// Retrieve an individual database configuration belonging to the organization or user.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns>The database configuration data.</returns>
        Task<Optional<DatabaseConfiguration>> RetrieveConfiguration(string organizationSlug, string databaseName);

        /// <summary>
        /// Update a database configuration belonging to the organization or user the client was set up with.
        /// </summary>
        /// <param name="databaseName">The name of the database.</param>
        /// <param name="sizeLimit">The maximum size of the database in bytes. Values with units are also accepted, e.g. 1mb, 256mb, 1gb.</param>
        /// <param name="allowAttach">Allow or disallow attaching databases to the current database.</param>
        /// <param name="blockReads">Block all database reads.</param>
        /// <param name="blockWrites">Block all database writes.</param>
        /// <returns>The database configuration data.</returns>
        Task<Optional<DatabaseConfiguration>> UpdateConfiguration(string databaseName, string sizeLimit = null,
            bool? allowAttach = null, bool? blockReads = null, bool? blockWrites = null);

        /// <summary>
        /// Update a database configuration belonging to the organization or user.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="databaseName">The name of the database.</param>
        /// <param name="sizeLimit">The maximum size of the database in bytes. Values with units are also accepted, e.g. 1mb, 256mb, 1gb.</param>
        /// <param name="allowAttach">Allow or disallow attaching databases to the current database.</param>
        /// <param name="blockReads">Block all database reads.</param>
        /// <param name="blockWrites">Block all database writes.</param>
        /// <returns>The database configuration data.</returns>
        Task<Optional<DatabaseConfiguration>> UpdateConfiguration(string organizationSlug, string databaseName,
            string sizeLimit = null, bool? allowAttach = null, bool? blockReads = null, bool? blockWrites = null);

        /// <summary>
        /// Fetch activity usage for a database in a given time period.
        /// </summary>
        /// <param name="databaseName">The name of the database.</param>
        /// <param name="from">The datetime to retrieve usage from in ISO 8601 format. Defaults to the current calendar month if not provided. Example: 2023-01-01T00:00:00Z</param>
        /// <param name="to">The datetime to retrieve usage to in ISO 8601 format. Defaults to the current calendar month if not provided. Example: 2023-02-01T00:00:00Z</param>
        /// <returns>The database usage stats.</returns>
        Task<Optional<DatabaseUsage>> Usage(string databaseName, string from = null, string to = null);

        /// <summary>
        /// Fetch activity usage for a database in a given time period for the organization or user the client was set up with.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="databaseName">The name of the database.</param>
        /// <param name="from">The datetime to retrieve usage from in ISO 8601 format. Defaults to the current calendar month if not provided. Example: 2023-01-01T00:00:00Z</param>
        /// <param name="to">The datetime to retrieve usage to in ISO 8601 format. Defaults to the current calendar month if not provided. Example: 2023-02-01T00:00:00Z</param>
        /// <returns>The database usage stats.</returns>
        Task<Optional<DatabaseUsage>> Usage(string organizationSlug, string databaseName,
            string from = null, string to = null);

        /// <summary>
        /// Fetch the top queries of a database, including the count of rows read and written.
        /// </summary>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns>The list of top queries.</returns>
        Task<Optional<List<TopQuery>>> Stats(string databaseName);

        /// <summary>
        /// Fetch the top queries of a database, including the count of rows read and written, for the organization or user the client was set up with.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns>The list of top queries.</returns>
        Task<Optional<List<TopQuery>>> Stats(string organizationSlug, string databaseName);

        /// <summary>
        /// Delete a database belonging to the organization or user the client was set up with.
        /// </summary>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns>The name of the database that was deleted.</returns>
        Task<Optional<string>> Delete(string databaseName);

        /// <summary>
        /// Delete a database belonging to the organization or user.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns>The name of the database that was deleted.</returns>
        Task<Optional<string>> Delete(string organizationSlug, string databaseName);

        /// <summary>
        /// Returns a list of instances of a database. Instances are the individual primary or replica databases in each region defined by the group.
        /// </summary>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns>A list of instances of the given database.</returns>
        Task<Optional<List<DatabaseInstance>>> ListInstances(string databaseName);

        /// <summary>
        /// Returns a list of instances of a database for the organization or user the client was set up with. Instances are the individual primary or replica databases in each region defined by the group.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns>A list of instances of the given database.</returns>
        Task<Optional<List<DatabaseInstance>>> ListInstances(string organizationSlug, string databaseName);

        /// <summary>
        /// Return the individual database instance by name for the organization or user the client was set up with.
        /// </summary>
        /// <param name="databaseName">The name of the database.</param>
        /// <param name="instanceName">The name of the instance (location code).</param>
        /// <returns>Database instance information.</returns>
        Task<Optional<DatabaseInstance>> RetrieveInstance(string databaseName, string instanceName);

        /// <summary>
        /// Return the individual database instance by name.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="databaseName">The name of the database.</param>
        /// <param name="instanceName">The name of the instance (location code).</param>
        /// <returns>Database instance information.</returns>
        Task<Optional<DatabaseInstance>> RetrieveInstance(string organizationSlug, string databaseName, string instanceName);

        /// <summary>
        /// Generates an authorization token for the specified database for the organization or user the client was set up with.
        /// </summary>
        /// <param name="databaseName">The name of the database.</param>
        /// <param name="expiration">Expiration time for the token (e.g., 2w1d30m).</param>
        /// <param name="authorization">Authorization level for the token (full-access or read-only). Available options: full-access, read-only</param>
        /// <param name="readAttachDatabases">Read ATTACH permission for the token to read other databases.</param>
        /// <returns>The newly created jwt token.</returns>
        Task<Optional<string>> CreateToken(string databaseName, string expiration = null,
            string authorization = null, List<string> readAttachDatabases = null);

        /// <summary>
        /// Generates an authorization token for the specified database.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="databaseName">The name of the database.</param>
        /// <param name="expiration">Expiration time for the token (e.g., 2w1d30m).</param>
        /// <param name="authorization">Authorization level for the token (full-access or read-only). Available options: full-access, read-only</param>
        /// <param name="readAttachDatabases">Read ATTACH permission for the token to read other databases.</param>
        /// <returns>The newly created jwt token.</returns>
        Task<Optional<string>> CreateToken(string organizationSlug, string databaseName, string expiration = null,
            string authorization = null, List<string> readAttachDatabases = null);

        /// <summary>
        /// Invalidates all authorization tokens for the specified database for the organization or user the client was set up with.
        /// </summary>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns>A value indicating if the tokens were invalidated successfully.</returns>
        Task<Optional<bool>> InvalidateTokens(string databaseName);

        /// <summary>
        /// Invalidates all authorization tokens for the specified database.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns>A value indicating if the tokens were invalidated successfully.</returns>
        Task<Optional<bool>> InvalidateTokens(string organizationSlug, string databaseName);

        /// <summary>
        /// Upload a SQL dump to be used when creating a new database from seed for the organization or user the client was set up with.
        /// </summary>
        /// <param name="filePath">The path of the sql dump file to upload.</param>
        /// <returns>URL of the uploaded database dump.</returns>
        Task<Optional<string>> UploadDump(string filePath);

        /// <summary>
        /// Upload a SQL dump to be used when creating a new database from seed.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="filePath">The path of the sql dump file to upload.</param>
        /// <returns>URL of the uploaded database dump.</returns>
        Task<Optional<string>> UploadDump(string organizationSlug, string filePath);

        /// <summary>
        /// Upload a SQL dump to be used when creating a new database from seed for the organization or user the client was set up with.
        /// </summary>
        /// <param name="fileName">The name of the sql dump file.</param>
        /// <param name="fileData">The sql dump file data.</param>
        /// <returns>URL of the uploaded database dump.</returns>
        Task<Optional<string>> UploadDump(string fileName, byte[] fileData);

        /// <summary>
        /// Upload a SQL dump to be used when creating a new database from seed.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="fileName">The name of the sql dump file.</param>
        /// <param name="fileData">The sql dump file data.</param>
        /// <returns>URL of the uploaded database dump.</returns>
        Task<Optional<string>> UploadDump(string organizationSlug, string fileName, byte[] fileData);
    }
}
