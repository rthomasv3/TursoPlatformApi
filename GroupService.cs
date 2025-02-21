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
using TursoPlatformApi.Responses.Groups;

namespace TursoPlatformApi
{
    /// <inheritdoc />
    public class GroupService : ApiService, ITursoGroupService
    {
        #region Constructor

        /// <summary>
        /// Creates a new instance of the <see cref="GroupService"/>.
        /// </summary>
        public GroupService(IHttpClientFactory httpClientFactory, TursoAppSettings appSettings) 
            : base(httpClientFactory, appSettings)
        { }

        #endregion

        #region Public Methods


        /// <inheritdoc />
        public async Task<Optional<List<Group>>> List()
        {
            return await List(AppSettings.DefaultOrganizationSlug);
        }

        /// <inheritdoc />
        public async Task<Optional<List<Group>>> List(string organizationSlug)
        {
            string status = null;
            string message = null;
            List<Group> groups = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}/groups");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    ListGroupsResponse groupResponse = JsonSerializer.Deserialize<ListGroupsResponse>(content, ResponseSerializerOptions);
                    groups = groupResponse.groups;
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

            return new Optional<List<Group>>(groups, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Group>> Create(string name, string location, string extensions = null)
        {
            return await Create(AppSettings.DefaultOrganizationSlug, name, location, extensions);
        }

        /// <inheritdoc />
        public async Task<Optional<Group>> Create(string organizationSlug, string name, string location, string extensions = null)
        {
            string status = null;
            string message = null;
            Group group = null;

            try
            {
                CreateGroupRequest createGroupRequest = new CreateGroupRequest()
                {
                    name = name,
                    location = location,
                    extensions = extensions,
                };
                string createGroupJson = JsonSerializer.Serialize(createGroupRequest, RequestSerializerOptions);

                using (StringContent requestContent = new StringContent(createGroupJson, System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage response = await TursoClient.PostAsync($"organizations/{organizationSlug}/groups", requestContent);
                    string content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        GroupResponse groupResponse = JsonSerializer.Deserialize<GroupResponse>(content, ResponseSerializerOptions);
                        group = groupResponse.group;
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

            return new Optional<Group>(group, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Group>> Retrieve(string groupName)
        {
            return await Retrieve(AppSettings.DefaultOrganizationSlug, groupName);
        }

        /// <inheritdoc />
        public async Task<Optional<Group>> Retrieve(string organizationSlug, string groupName)
        {
            string status = null;
            string message = null;
            Group group = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}/groups/{groupName}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    GroupResponse groupResponse = JsonSerializer.Deserialize<GroupResponse>(content, ResponseSerializerOptions);
                    group = groupResponse.group;
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

            return new Optional<Group>(group, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Group>> Delete(string groupName)
        {
            return await Delete(AppSettings.DefaultOrganizationSlug, groupName);
        }

        /// <inheritdoc />
        public async Task<Optional<Group>> Delete(string organizationSlug, string groupName)
        {
            string status = null;
            string message = null;
            Group group = null;

            try
            {
                HttpResponseMessage response = await TursoClient.DeleteAsync($"organizations/{organizationSlug}/groups/{groupName}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    GroupResponse groupResponse = JsonSerializer.Deserialize<GroupResponse>(content, ResponseSerializerOptions);
                    group = groupResponse.group;
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

            return new Optional<Group>(group, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Group>> Transfer(string groupName, string organization)
        {
            return await Transfer(AppSettings.DefaultOrganizationSlug, groupName, organization);
        }

        /// <inheritdoc />
        public async Task<Optional<Group>> Transfer(string organizationSlug, string groupName, string organization)
        {
            string status = null;
            string message = null;
            Group group = null;

            try
            {
                TransferGroupRequest transferGroupRequest = new TransferGroupRequest()
                {
                    organization = organization,
                };
                string transferGroupJson = JsonSerializer.Serialize(transferGroupRequest, RequestSerializerOptions);

                using (StringContent requestContent = new StringContent(transferGroupJson, System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage response = await TursoClient.PostAsync($"organizations/{organizationSlug}/groups/{groupName}/transfer", requestContent);
                    string content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        group = JsonSerializer.Deserialize<Group>(content, ResponseSerializerOptions);
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

            return new Optional<Group>(group, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Group>> Unarchive(string groupName)
        {
            return await Unarchive(AppSettings.DefaultOrganizationSlug, groupName);
        }

        /// <inheritdoc />
        public async Task<Optional<Group>> Unarchive(string organizationSlug, string groupName)
        {
            string status = null;
            string message = null;
            Group group = null;

            try
            {
                HttpResponseMessage response = await TursoClient.PostAsync($"organizations/{organizationSlug}/groups/{groupName}/unarchive", null);
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    GroupResponse groupResponse = JsonSerializer.Deserialize<GroupResponse>(content, ResponseSerializerOptions);
                    group = groupResponse.group;
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

            return new Optional<Group>(group, status, message);
        }


        /// <inheritdoc />
        public async Task<Optional<bool>> UpdateVersions(string groupName)
        {
            return await UpdateVersions(AppSettings.DefaultOrganizationSlug, groupName);
        }

        /// <inheritdoc />
        public async Task<Optional<bool>> UpdateVersions(string organizationSlug, string groupName)
        {
            string status = null;
            string message = null;
            bool updated = false;

            try
            {
                HttpResponseMessage response = await TursoClient.PostAsync($"organizations/{organizationSlug}/groups/{groupName}/update", null);
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    updated = true;
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

            return new Optional<bool>(updated, status, message);
        }
        /// <inheritdoc />
        public async Task<Optional<string>> CreateToken(string groupName, string expiration = null,
            string authorization = null, List<string> readAttachDatabases = null)
        {
            return await CreateToken(AppSettings.DefaultOrganizationSlug, expiration, authorization, readAttachDatabases);
        }

        /// <inheritdoc />
        public async Task<Optional<string>> CreateToken(string organizationSlug, string groupName, string expiration = null,
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
                    HttpResponseMessage response = await TursoClient.PostAsync($"organizations/{organizationSlug}/groups/{groupName}/auth/tokens{queryString}", requestContent);
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
        public async Task<Optional<bool>> InvalidateTokens(string groupName)
        {
            return await InvalidateTokens(AppSettings.DefaultOrganizationSlug, groupName);
        }

        /// <inheritdoc />
        public async Task<Optional<bool>> InvalidateTokens(string organizationSlug, string groupName)
        {
            string status = null;
            string message = null;
            bool invalidated = false;

            try
            {
                HttpResponseMessage response = await TursoClient.PostAsync($"organizations/{organizationSlug}/groups/{groupName}/auth/rotate", null);
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

        #endregion
    }
}
