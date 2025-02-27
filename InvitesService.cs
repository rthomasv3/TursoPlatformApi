﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TursoPlatformApi.Abstractions;
using TursoPlatformApi.Requests;
using TursoPlatformApi.Responses;
using TursoPlatformApi.Responses.AuditLogs;
using TursoPlatformApi.Responses.Invites;

namespace TursoPlatformApi
{
    /// <inheritdoc />
    public class InvitesService : ApiService, ITursoInvitesService
    {
        #region Fields

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the <see cref="InvitesService"/>.
        /// </summary>
        /// <param name="httpClientFactory"></param>
        /// <param name="appSettings"></param>
        public InvitesService(IHttpClientFactory httpClientFactory, TursoAppSettings appSettings) 
            : base(httpClientFactory, appSettings)
        { }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public async Task<Optional<List<Invite>>> List()
        {
            return await List(AppSettings.DefaultOrganizationSlug);
        }

        /// <inheritdoc />
        public async Task<Optional<List<Invite>>> List(string organizationSlug)
        {
            string status = null;
            string message = null;
            List<Invite> invites = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}/invites");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    ListInvitesResponse invitesResponse = JsonSerializer.Deserialize<ListInvitesResponse>(content, ResponseSerializerOptions);
                    invites = invitesResponse.invites;
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

            return new Optional<List<Invite>>(invites, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Invite>> Create(string email, string role = "member")
        {
            return await Create(AppSettings.DefaultOrganizationSlug, email, role);
        }

        /// <inheritdoc />
        public async Task<Optional<Invite>> Create(string organizationSlug, string email, string role = "member")
        {
            string status = null;
            string message = null;
            Invite invite = null;

            try
            {
                CreateInviteRequest createInviteRequest = new CreateInviteRequest()
                {
                    email = email,
                    role = role,
                };
                string createInviteJson = JsonSerializer.Serialize(createInviteRequest, RequestSerializerOptions);

                using (StringContent requestContent = new StringContent(createInviteJson, System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage response = await TursoClient.PostAsync($"organizations/{organizationSlug}/invites", requestContent);
                    string content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        CreateInviteResponse inviteResponse = JsonSerializer.Deserialize<CreateInviteResponse>(content, ResponseSerializerOptions);
                        invite = inviteResponse.invited;
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

            return new Optional<Invite>(invite, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<bool>> Delete(string email)
        {
            return await Delete(AppSettings.DefaultOrganizationSlug, email);
        }

        /// <inheritdoc />
        public async Task<Optional<bool>> Delete(string organizationSlug, string email)
        {
            string status = null;
            string message = null;
            bool deleted = false;

            try
            {
                HttpResponseMessage response = await TursoClient.DeleteAsync($"organizations/{organizationSlug}/invites/{email}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    deleted = true;
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

            return new Optional<bool>(deleted, status, message);
        }

        #endregion
    }
}
