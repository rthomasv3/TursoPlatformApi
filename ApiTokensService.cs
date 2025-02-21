using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TursoPlatformApi.Abstractions;
using TursoPlatformApi.Responses;
using TursoPlatformApi.Responses.ApiTokens;

namespace TursoPlatformApi
{
    /// <inheritdoc />
    public class ApiTokensService : ApiService, ITursoApiTokensService
    {
        #region Fields

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the <see cref="ApiTokensService"/>.
        /// </summary>
        public ApiTokensService(IHttpClientFactory httpClientFactory, TursoAppSettings appSettings) 
            : base(httpClientFactory, appSettings)
        { }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public async Task<Optional<CreatedApiToken>> Create(string tokenName)
        {
            string status = null;
            string message = null;
            CreatedApiToken apiToken = null;

            try
            {
                HttpResponseMessage response = await TursoClient.PostAsync($"auth/api-tokens/{tokenName}", null);
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    apiToken = JsonSerializer.Deserialize<CreatedApiToken>(content, ResponseSerializerOptions);
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

            return new Optional<CreatedApiToken>(apiToken, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<int>> Validate()
        {
            return await Validate(AppSettings.AuthToken);
        }

        /// <inheritdoc />
        public async Task<Optional<int>> Validate(string authToken)
        {
            string status = null;
            string message = null;
            int expiration = 0;

            try
            {
                HttpClient tursoClient = TursoClient;
                tursoClient.DefaultRequestHeaders.Remove("Authorization");
                tursoClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");
                HttpResponseMessage response = await tursoClient.GetAsync("auth/validate");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    TokenValidation tokenValidation = JsonSerializer.Deserialize<TokenValidation>(content, ResponseSerializerOptions);
                    expiration = tokenValidation.exp;
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

            return new Optional<int>(expiration, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<List<ApiToken>>> List()
        {
            string status = null;
            string message = null;
            List<ApiToken> apiTokens = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"auth/api-tokens");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    ListTokensResponse tokensResponse = JsonSerializer.Deserialize<ListTokensResponse>(content, ResponseSerializerOptions);
                    apiTokens = tokensResponse.tokens;
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

            return new Optional<List<ApiToken>>(apiTokens, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<string>> Revoke(string tokenName)
        {
            string status = null;
            string message = null;
            string token = null;

            try
            {
                HttpResponseMessage response = await TursoClient.DeleteAsync($"auth/api-tokens/{tokenName}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    RevokeTokenResponse revokeResponse = JsonSerializer.Deserialize<RevokeTokenResponse>(content, ResponseSerializerOptions);
                    token = revokeResponse.token;
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

            return new Optional<string>(token, status, message);
        }

        #endregion
    }
}
