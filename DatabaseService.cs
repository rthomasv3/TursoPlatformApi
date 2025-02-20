using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using TursoPlatformApi.Abstractions;
using TursoPlatformApi.Requests;
using TursoPlatformApi.Responses;

namespace TursoPlatformApi
{
    public class DatabaseService : ApiService, IDatabaseService
    {
        #region Fields

        private readonly TursoAppSettings _appSettings;

        #endregion

        #region Constructor

        public DatabaseService(IHttpClientFactory httpClientFactory, TursoAppSettings appSettings)
            : base(httpClientFactory, appSettings)
        {
            _appSettings = appSettings;
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public async Task<Optional<List<Database>>> List(string group = null, string schema = null)
        {
            string status = null;
            string message = null;
            List<Database> databases = null;

            string queryString = string.Empty;
            NameValueCollection queryStringCollection = HttpUtility.ParseQueryString(string.Empty);

            if (!string.IsNullOrEmpty(group))
            {
                queryStringCollection.Add("group", group);
            }

            if (!string.IsNullOrEmpty(schema))
            {
                queryStringCollection.Add("schema", schema);
            }

            if (queryStringCollection.Count > 0)
            {
                queryString = $"?{queryStringCollection}";
            }

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{_appSettings.OrganizationSlug}/databases{queryString}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Databases databasesResponse = JsonSerializer.Deserialize<Databases>(content, JsonSerializerOptions);
                    databases = databasesResponse.databases;
                }
                else
                {
                    ParseError(response, content, ref status, ref message);
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<List<Database>>(databases, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Database>> Create(string name, string group, string seedType = null, 
            string seedName = null, string seedUrl = null, string seedTimestamp = null,
            string sizeLimit = null, bool isScheme = false, string schema = null)
        {
            string status = null;
            string message = null;
            Database database = null;

            Seed seed = null;

            if (string.Equals(seedType, "database") || string.Equals(seedType, "dump"))
            {
                seed = new Seed()
                {
                    name = seedName,
                    timestamp = seedTimestamp,
                    type = seedType,
                    url = seedUrl,
                };
            }

            try
            {
                CreateDatabase createDatabase = new CreateDatabase()
                {
                    name = name,
                    group = group,
                    seed = seed,
                    size_limit = sizeLimit,
                    is_schema = isScheme,
                    schema = schema,
                };
                string createDatabaseJson = JsonSerializer.Serialize(createDatabase);
                StringContent requestContent = new StringContent(createDatabaseJson, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await TursoClient.PostAsync($"organizations/{_appSettings.OrganizationSlug}/databases", requestContent);
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    GetDatabaseResponse databaseResponse = JsonSerializer.Deserialize<GetDatabaseResponse>(content, JsonSerializerOptions);
                    database = databaseResponse.Database;
                }
                else
                {
                    ParseError(response, content, ref status, ref message);
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<Database>(database, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Database>> Retrieve(string databaseName)
        {
            string status = null;
            string message = null;
            Database database = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{_appSettings.OrganizationSlug}/databases/{databaseName}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    GetDatabaseResponse databaseResponse = JsonSerializer.Deserialize<GetDatabaseResponse>(content, JsonSerializerOptions);
                    database = databaseResponse.Database;
                }
                else
                {
                    ParseError(response, content, ref status, ref message);
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<Database>(database, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<DatabaseConfiguration>> RetrieveConfiguration(string databaseName)
        {
            string status = null;
            string message = null;
            DatabaseConfiguration databaseConfiguration = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{_appSettings.OrganizationSlug}/databases/{databaseName}/configuration");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    databaseConfiguration = JsonSerializer.Deserialize<DatabaseConfiguration>(content, JsonSerializerOptions);
                }
                else
                {
                    ParseError(response, content, ref status, ref message);
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<DatabaseConfiguration>(databaseConfiguration, status, message);
        }

        /// <inheritdoc />
        public async Task<object> UpdateConfiguration(string databaseName, object configuration)
        {
            return null;
        }

        /// <inheritdoc />
        public async Task<object> Usage(string databaseName, string from = null, string to = null)
        {
            return null;
        }

        /// <inheritdoc />
        public async Task<object> Stats(string databaseName)
        {
            return null;
        }

        /// <inheritdoc />
        public async Task<Optional<string>> Delete(string databaseName)
        {
            string status = null;
            string message = null;
            string database = null;

            try
            {
                HttpResponseMessage response = await TursoClient.DeleteAsync($"organizations/{_appSettings.OrganizationSlug}/databases/{databaseName}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    DatabaseName databaseResponse = JsonSerializer.Deserialize<DatabaseName>(content, JsonSerializerOptions);
                    database = databaseResponse.Database;
                }
                else
                {
                    status = ((int)response.StatusCode).ToString();
                    message = response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<string>(database, status, message);
        }

        /// <inheritdoc />
        public async Task<object> ListInstances(string databaseName)
        {
            return null;
        }

        /// <inheritdoc />
        public async Task<object> RetrieveInstances(string databaseName, string instanceName)
        {
            return null;
        }

        /// <inheritdoc />
        public async Task<object> CreateToken(string databaseName, string expiration = null, string authorization = null)
        {
            return null;
        }

        /// <inheritdoc />
        public async Task<bool> InvalidateTokens(string databaseName)
        {
            return false;
        }

        /// <inheritdoc />
        public async Task<bool> UploadDump(byte[] file)
        {
            return false;
        }

        /// <inheritdoc />
        public async Task<string> UploadDump(string filePath)
        {
            return "";
        }

        #endregion

        #region Private Methods

        

        #endregion
    }
}
