using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TursoPlatformApi.Abstractions;
using TursoPlatformApi.Requests;
using TursoPlatformApi.Responses;
using TursoPlatformApi.Responses.Members;

namespace TursoPlatformApi
{
    /// <inheritdoc />
    public class MembersService : ApiService, ITursoMembersService
    {
        #region Fields

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the <see cref="MembersService"/>.
        /// </summary>
        public MembersService(IHttpClientFactory httpClientFactory, TursoAppSettings appSettings) 
            : base(httpClientFactory, appSettings)
        { }

        #endregion

        #region Public Methods


        /// <inheritdoc />
        public async Task<Optional<List<Member>>> List()
        {
            return await List(AppSettings.DefaultOrganizationSlug);
        }

        /// <inheritdoc />
        public async Task<Optional<List<Member>>> List(string organizationSlug)
        {
            string status = null;
            string message = null;
            List<Member> members = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}/members");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    ListMembersResponse membersResponse = JsonSerializer.Deserialize<ListMembersResponse>(content, ResponseSerializerOptions);
                    members = membersResponse.Members;
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

            return new Optional<List<Member>>(members, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Member>> Retrieve(string username)
        {
            return await Retrieve(AppSettings.DefaultOrganizationSlug, username);
        }

        /// <inheritdoc />
        public async Task<Optional<Member>> Retrieve(string organizationSlug, string username)
        {
            string status = null;
            string message = null;
            Member member = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}/members/{username}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MemberResponse memberResponse = JsonSerializer.Deserialize<MemberResponse>(content, ResponseSerializerOptions);
                    member = memberResponse.member;
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

            return new Optional<Member>(member, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<AddedMember>> Add(string username, string role)
        {
            return await Add(AppSettings.DefaultOrganizationSlug, username, role);
        }

        /// <inheritdoc />
        public async Task<Optional<AddedMember>> Add(string organizationSlug, string username, string role)
        {
            string status = null;
            string message = null;
            AddedMember addedMember = null;

            try
            {
                CreateMemberRequest createMemberRequest = new CreateMemberRequest()
                {
                    username = username,
                    role = role
                };
                string createMemberJson = JsonSerializer.Serialize(createMemberRequest, RequestSerializerOptions);

                using (StringContent requestContent = new StringContent(createMemberJson, Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage response = await TursoClient.PostAsync($"organizations/{organizationSlug}/members", requestContent);
                    string content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        addedMember = JsonSerializer.Deserialize<AddedMember>(content, ResponseSerializerOptions);
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

            return new Optional<AddedMember>(addedMember, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Member>> Update(string username, string role)
        {
            return await Update(AppSettings.DefaultOrganizationSlug, username, role);
        }

        /// <inheritdoc />
        public async Task<Optional<Member>> Update(string organizationSlug, string username, string role)
        {
            string status = null;
            string message = null;
            Member member = null;

            try
            {
                CreateMemberRequest createMemberRequest = new CreateMemberRequest()
                {
                    role = role
                };
                string createMemberJson = JsonSerializer.Serialize(createMemberRequest, RequestSerializerOptions);

                using (StringContent requestContent = new StringContent(createMemberJson, Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage response = await TursoClient.PatchAsync($"organizations/{organizationSlug}/members", requestContent);
                    string content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MemberResponse memberResponse = JsonSerializer.Deserialize<MemberResponse>(content, ResponseSerializerOptions);
                        member = memberResponse.member;
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

            return new Optional<Member>(member, status, message);
        }


        /// <inheritdoc />
        public async Task<Optional<string>> Remove(string username)
        {
            return await Remove(AppSettings.DefaultOrganizationSlug, username);
        }

        /// <inheritdoc />
        public async Task<Optional<string>> Remove(string organizationSlug, string username)
        {
            string status = null;
            string message = null;
            string member = null;

            try
            {
                HttpResponseMessage response = await TursoClient.DeleteAsync($"organizations/{organizationSlug}/members/{username}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    RemoveMemberResponse memberResponse = JsonSerializer.Deserialize<RemoveMemberResponse>(content, ResponseSerializerOptions);
                    member = memberResponse.member;
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

            return new Optional<string>(member, status, message);
        }

        #endregion
    }
}
