using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using TursoPlatformApi.Responses;

namespace TursoPlatformApi
{
    /// <summary>
    /// The base API service providing common functionality.
    /// </summary>
    public class ApiService
    {
        #region Fields

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly TursoAppSettings _appSettings;
        private readonly JsonSerializerOptions _requestSerializerOptions;
        private readonly JsonSerializerOptions _responseSerializerOptions;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of an <see cref="ApiService"/>.
        /// </summary>
        /// <param name="httpClientFactory">The <see cref="IHttpClientFactory"/> used to create <see cref="HttpClient"/> instances.</param>
        /// <param name="appSettings">App settings for configuration.</param>
        /// <exception cref="ArgumentNullException">All parameters are required.</exception>
        public ApiService(IHttpClientFactory httpClientFactory, TursoAppSettings appSettings)
        {
            if (httpClientFactory == null)
            {
                throw new ArgumentNullException("httpClientFactory");
            }

            if (appSettings == null)
            {
                throw new ArgumentNullException("appSettings");
            }

            _httpClientFactory = httpClientFactory;
            _appSettings = appSettings;

            _requestSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };

            _responseSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };
        }

        #endregion

        #region Properties

        /// <summary>
        /// An <see cref="HttpClient"/> configured with the Turso API base address and auth token.
        /// </summary>
        protected HttpClient TursoClient => _httpClientFactory.CreateClient(_appSettings.TursoClientName);

        /// <summary>
        /// A default <see cref="HttpClient"/>.
        /// </summary>
        protected HttpClient DefaultClient => _httpClientFactory.CreateClient(_appSettings.DefaultClientName);

        /// <summary>
        /// Configuration settings.
        /// </summary>
        protected TursoAppSettings AppSettings => _appSettings;

        /// <summary>
        /// Serailization options used for serializing requests to the Turso API.
        /// </summary>
        protected JsonSerializerOptions RequestSerializerOptions => _requestSerializerOptions;

        /// <summary>
        /// Serailization options used for deserializing responses from the Turso API.
        /// </summary>
        protected JsonSerializerOptions ResponseSerializerOptions => _responseSerializerOptions;

        #endregion

        #region Protected Methods

        /// <summary>
        /// Method used to parse error messages from the Turso API.
        /// </summary>
        /// <param name="response">The API response message.</param>
        /// <param name="content">The API response content.</param>
        /// <param name="status">A reference to a string used to store the API status code.</param>
        /// <param name="message">A references to a used used to store the API error message.</param>
        protected void ParseError(HttpResponseMessage response, string content, ref string status, ref string message)
        {
            bool parsedError = false;

            if (response.StatusCode == HttpStatusCode.BadRequest ||
                response.StatusCode == HttpStatusCode.Conflict ||
                response.StatusCode == HttpStatusCode.NotFound)
            {

                try
                {
                    ErrorResponse errorResponse = JsonSerializer.Deserialize<ErrorResponse>(content, ResponseSerializerOptions);
                    message = $"{response.ReasonPhrase}: {errorResponse.Error}";
                    parsedError = true;
                }
                catch { }
            }

            if (!parsedError)
            {
                message = $"{response.ReasonPhrase}: {content}";
            }

            status = ((int)response.StatusCode).ToString();
        }

        #endregion
    }
}
