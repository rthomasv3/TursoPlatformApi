using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using TursoPlatformApi.Responses;

namespace TursoPlatformApi
{
    public class ApiService
    {
        #region Fields

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly TursoAppSettings _appSettings;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        #endregion

        #region Constructor

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

            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };
        }

        #endregion

        #region Properties

        protected HttpClient TursoClient => _httpClientFactory.CreateClient(_appSettings.TursoClientName);

        protected HttpClient DefaultClient => _httpClientFactory.CreateClient(_appSettings.DefaultClientName);

        protected TursoAppSettings AppSettings => _appSettings;

        protected JsonSerializerOptions JsonSerializerOptions => _jsonSerializerOptions;

        #endregion

        #region Protected Methods

        protected void ParseError(HttpResponseMessage response, string content, ref string status, ref string message)
        {
            bool parsedError = false;

            if (response.StatusCode == HttpStatusCode.BadRequest ||
                response.StatusCode == HttpStatusCode.Conflict ||
                response.StatusCode == HttpStatusCode.NotFound)
            {

                try
                {
                    ErrorResponse errorResponse = JsonSerializer.Deserialize<ErrorResponse>(content, JsonSerializerOptions);
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
