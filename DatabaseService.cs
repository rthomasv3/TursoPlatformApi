using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using TursoPlatformApi.Abstractions;
using TursoPlatformApi.Requests;
using TursoPlatformApi.Responses;
using TursoPlatformApi.Responses.Databases;

namespace TursoPlatformApi
{
    /// <inheritdoc />
    public class DatabaseService : ApiService, ITursoDatabaseService
    {
        #region Constructor

        /// <summary>
        /// Creates a new instance of the <see cref="DatabaseService"/>.
        /// </summary>
        public DatabaseService(IHttpClientFactory httpClientFactory, TursoAppSettings appSettings)
            : base(httpClientFactory, appSettings)
        { }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public async Task<Optional<List<Database>>> List(string group = null, string schema = null)
        {
            return await List(AppSettings.DefaultOrganizationSlug, group, schema);
        }

        /// <inheritdoc />
        public async Task<Optional<List<Database>>> List(string organizationSlug, string group = null, string schema = null)
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
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}/databases{queryString}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    ListDatabases databasesResponse = JsonSerializer.Deserialize<ListDatabases>(content, ResponseSerializerOptions);
                    databases = databasesResponse.Databases;
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
        public async Task<Optional<Database>> Create(string name, string group, string seedType = null, string seedName = null, 
            string seedUrl = null, string seedTimestamp = null, string sizeLimit = null, bool isScheme = false, 
            string schema = null)
        {
            return await Create(AppSettings.DefaultOrganizationSlug, name, group, seedType, seedName, seedUrl, seedTimestamp, 
                sizeLimit, isScheme, schema);
        }

        /// <inheritdoc />
        public async Task<Optional<Database>> Create(string organizationSlug, string name, string group, string seedType = null,
            string seedName = null, string seedUrl = null, string seedTimestamp = null, string sizeLimit = null, 
            bool isScheme = false, string schema = null)
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
                string createDatabaseJson = JsonSerializer.Serialize(createDatabase, RequestSerializerOptions);

                using (StringContent requestContent = new StringContent(createDatabaseJson, System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage response = await TursoClient.PostAsync($"organizations/{organizationSlug}/databases", requestContent);
                    string content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        GetDatabaseResponse databaseResponse = JsonSerializer.Deserialize<GetDatabaseResponse>(content, ResponseSerializerOptions);
                        database = databaseResponse.Database;
                    }
                    else
                    {
                        ParseError(response, content, ref status, ref message);
                    }
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
            return await Retrieve(AppSettings.DefaultOrganizationSlug, databaseName);
        }

        /// <inheritdoc />
        public async Task<Optional<Database>> Retrieve(string organizationSlug, string databaseName)
        {
            string status = null;
            string message = null;
            Database database = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}/databases/{databaseName}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    GetDatabaseResponse databaseResponse = JsonSerializer.Deserialize<GetDatabaseResponse>(content, ResponseSerializerOptions);
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
            return await RetrieveConfiguration(AppSettings.DefaultOrganizationSlug, databaseName);
        }

        /// <inheritdoc />
        public async Task<Optional<DatabaseConfiguration>> RetrieveConfiguration(string organizationSlug, string databaseName)
        {
            string status = null;
            string message = null;
            DatabaseConfiguration databaseConfiguration = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}/databases/{databaseName}/configuration");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    databaseConfiguration = JsonSerializer.Deserialize<DatabaseConfiguration>(content, ResponseSerializerOptions);
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
        public async Task<Optional<DatabaseConfiguration>> UpdateConfiguration(string databaseName, string sizeLimit = null, 
            bool? allowAttach = null, bool? blockReads = null, bool? blockWrites = null)
        {
            return await UpdateConfiguration(AppSettings.DefaultOrganizationSlug, databaseName, sizeLimit, 
                allowAttach, blockReads, blockWrites);
        }

        /// <inheritdoc />
        public async Task<Optional<DatabaseConfiguration>> UpdateConfiguration(string organizationSlug, string databaseName, 
            string sizeLimit = null, bool? allowAttach = null, bool? blockReads = null, bool? blockWrites = null)
        {
            string status = null;
            string message = null;
            DatabaseConfiguration databaseConfiguration = null;

            if (!string.IsNullOrWhiteSpace(sizeLimit) || allowAttach.HasValue || blockReads.HasValue || blockWrites.HasValue)
            {
                try
                {
                    UpdateConfigurationRequest patchConfiguration = new UpdateConfigurationRequest()
                    {
                        size_limit = sizeLimit,
                        allow_attach = allowAttach,
                        block_reads = blockReads,
                        block_writes = blockWrites,
                    };
                    string configurationJson = JsonSerializer.Serialize(patchConfiguration, RequestSerializerOptions);

                    using (StringContent requestContent = new StringContent(configurationJson, System.Text.Encoding.UTF8, "application/json"))
                    {
                        HttpResponseMessage response = await TursoClient.PatchAsync($"organizations/{organizationSlug}/databases/{databaseName}/configuration", requestContent);
                        string content = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            databaseConfiguration = JsonSerializer.Deserialize<DatabaseConfiguration>(content, ResponseSerializerOptions);
                        }
                        else
                        {
                            ParseError(response, content, ref status, ref message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    status = "Exception";
                    message = ex.ToString();
                }
            }
            else
            {
                status = "BadRequest";
                message = "No configuration parameters provided";
            }

            return new Optional<DatabaseConfiguration>(databaseConfiguration, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<DatabaseUsage>> Usage(string databaseName, string from = null, string to = null)
        {
            return await Usage(AppSettings.DefaultOrganizationSlug, databaseName, from, to);
        }

        /// <inheritdoc />
        public async Task<Optional<DatabaseUsage>> Usage(string organizationSlug, string databaseName, 
            string from = null, string to = null)
        {
            string status = null;
            string message = null;
            DatabaseUsage databaseUsage = null;

            string queryString = string.Empty;
            NameValueCollection queryStringCollection = HttpUtility.ParseQueryString(string.Empty);

            if (!string.IsNullOrEmpty(from))
            {
                queryStringCollection.Add("from", from);
            }

            if (!string.IsNullOrEmpty(to))
            {
                queryStringCollection.Add("to", to);
            }

            if (queryStringCollection.Count > 0)
            {
                queryString = $"?{queryStringCollection}";
            }

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}/databases/{databaseName}/usage{queryString}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    DatabaseUsageResponse usageResponse = JsonSerializer.Deserialize<DatabaseUsageResponse>(content, ResponseSerializerOptions);
                    databaseUsage = usageResponse.Database;
                    databaseUsage.Total = usageResponse.Total;
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

            return new Optional<DatabaseUsage>(databaseUsage, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<List<TopQuery>>> Stats(string databaseName)
        {
            return await Stats(AppSettings.DefaultOrganizationSlug, databaseName);
        }

        /// <inheritdoc />
        public async Task<Optional<List<TopQuery>>> Stats(string organizationSlug, string databaseName)
        {
            string status = null;
            string message = null;
            List<TopQuery> topQueries = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}/databases/{databaseName}/stats");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    StatsResponse statsResponse = JsonSerializer.Deserialize<StatsResponse>(content, ResponseSerializerOptions);
                    topQueries = statsResponse.TopQueries;
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

            return new Optional<List<TopQuery>>(topQueries, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<string>> Delete(string databaseName)
        {
            return await Delete(AppSettings.DefaultOrganizationSlug, databaseName);
        }

        /// <inheritdoc />
        public async Task<Optional<string>> Delete(string organizationSlug, string databaseName)
        {
            string status = null;
            string message = null;
            string database = null;

            try
            {
                HttpResponseMessage response = await TursoClient.DeleteAsync($"organizations/{organizationSlug}/databases/{databaseName}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    DatabaseName databaseResponse = JsonSerializer.Deserialize<DatabaseName>(content, ResponseSerializerOptions);
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
        public async Task<Optional<List<DatabaseInstance>>> ListInstances(string databaseName)
        {
            return await ListInstances(AppSettings.DefaultOrganizationSlug, databaseName);
        }

        /// <inheritdoc />
        public async Task<Optional<List<DatabaseInstance>>> ListInstances(string organizationSlug, string databaseName)
        {
            string status = null;
            string message = null;
            List<DatabaseInstance> instances = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}/databases/{databaseName}/instances");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    ListInstancesResponse instancesResponse = JsonSerializer.Deserialize<ListInstancesResponse>(content, ResponseSerializerOptions);
                    instances = instancesResponse.instances;
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

            return new Optional<List<DatabaseInstance>>(instances, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<DatabaseInstance>> RetrieveInstance(string databaseName, string instanceName)
        {
            return await RetrieveInstance(AppSettings.DefaultOrganizationSlug, databaseName, instanceName);
        }

        /// <inheritdoc />
        public async Task<Optional<DatabaseInstance>> RetrieveInstance(string organizationSlug, string databaseName, string instanceName)
        {
            string status = null;
            string message = null;
            DatabaseInstance instance = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}/databases/{databaseName}/instances/{instanceName}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    RetrieveInstanceResponse instanceResponse = JsonSerializer.Deserialize<RetrieveInstanceResponse>(content, ResponseSerializerOptions);
                    instance = instanceResponse.instance;
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

            return new Optional<DatabaseInstance>(instance, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<string>> CreateToken(string databaseName, string expiration = null,
            string authorization = null, List<string> readAttachDatabases = null)
        {
            return await CreateToken(AppSettings.DefaultOrganizationSlug, databaseName, expiration, authorization, readAttachDatabases);
        }

        /// <inheritdoc />
        public async Task<Optional<string>> CreateToken(string organizationSlug, string databaseName, string expiration = null, 
            string authorization = null, List<string> readAttachDatabases = null)
        {
            string status = null;
            string message = null;
            string token = null;

            string queryString = string.Empty;
            NameValueCollection queryStringCollection = HttpUtility.ParseQueryString(string.Empty);

            if (!string.IsNullOrEmpty(expiration))
            {
                queryStringCollection.Add("expiration", expiration);
            }

            if (!string.IsNullOrEmpty(authorization))
            {
                queryStringCollection.Add("authorization", authorization);
            }

            if (queryStringCollection.Count > 0)
            {
                queryString = $"?{queryStringCollection}";
            }

            try
            {
                CreateTokenRequest createTokenRequest = new CreateTokenRequest()
                {
                    permissions = new Permissions()
                    {
                        read_attach = new ReadAttach()
                        {
                            databases = readAttachDatabases?.ToArray() ?? Array.Empty<string>(),
                        },
                    }
                };
                string createTokenJson = JsonSerializer.Serialize(createTokenRequest, RequestSerializerOptions);

                using (StringContent requestContent = new StringContent(createTokenJson, System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage response = await TursoClient.PostAsync($"organizations/{organizationSlug}/databases/{databaseName}/auth/tokens{queryString}", requestContent);
                    string content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        CreateTokenResponse tokenResponse = JsonSerializer.Deserialize<CreateTokenResponse>(content, ResponseSerializerOptions);
                        token = tokenResponse.jwt;
                    }
                    else
                    {
                        ParseError(response, content, ref status, ref message);
                    }
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }


            return new Optional<string>(token, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<bool>> InvalidateTokens(string databaseName)
        {
            return await InvalidateTokens(AppSettings.DefaultOrganizationSlug, databaseName);
        }

        /// <inheritdoc />
        public async Task<Optional<bool>> InvalidateTokens(string organizationSlug, string databaseName)
        {
            string status = null;
            string message = null;
            bool invalidated = false;

            try
            {
                HttpResponseMessage response = await TursoClient.PostAsync($"organizations/{organizationSlug}/databases/{databaseName}/auth/rotate", null);
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    invalidated = true;
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

            return new Optional<bool>(invalidated, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<string>> UploadDump(string filePath)
        {
            return await UploadDump(AppSettings.DefaultOrganizationSlug, Path.GetFileName(filePath), File.ReadAllBytes(filePath));
        }

        /// <inheritdoc />
        public async Task<Optional<string>> UploadDump(string organizationSlug, string filePath)
        {
            return await UploadDump(organizationSlug, Path.GetFileName(filePath), File.ReadAllBytes(filePath));
        }

        /// <inheritdoc />
        public async Task<Optional<string>> UploadDump(string fileName, byte[] fileData)
        {
            return await UploadDump(AppSettings.DefaultOrganizationSlug, fileName, fileData);
        }

        /// <inheritdoc />
        public async Task<Optional<string>> UploadDump(string organizationSlug, string fileName, byte[] fileData)
        {
            string status = null;
            string message = null;
            string dumpUrl = null;

            try
            {
                using (MultipartFormDataContent formData = new MultipartFormDataContent())
                {
                    ByteArrayContent fileContent = new ByteArrayContent(fileData);
                    fileContent.Headers.Add("Content-Type", "application/octet-stream");
                    formData.Add(fileContent, "file", fileName);

                    HttpResponseMessage response = await TursoClient.PostAsync($"organizations/{organizationSlug}/databases/dumps", formData);
                    string content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        UploadDumpResponse dumpResponse = JsonSerializer.Deserialize<UploadDumpResponse>(content, ResponseSerializerOptions);
                        dumpUrl = dumpResponse.dump_url;
                    }
                    else
                    {
                        ParseError(response, content, ref status, ref message);
                    }
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<string>(dumpUrl, status, message);
        }

        #endregion
    }
}
