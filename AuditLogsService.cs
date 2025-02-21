using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using TursoPlatformApi.Abstractions;
using TursoPlatformApi.Responses;
using TursoPlatformApi.Responses.AuditLogs;

namespace TursoPlatformApi
{
    public class AuditLogsService : ApiService, ITursoAuditLogsService
    {
        #region Fields

        #endregion

        #region Constructor

        public AuditLogsService(IHttpClientFactory httpClientFactory, TursoAppSettings appSettings) 
            : base(httpClientFactory, appSettings)
        { }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public async Task<Optional<Logs>> List(int pageSize = 100, int page = 1)
        {
            return await List(AppSettings.OrganizationSlug, pageSize, page);
        }

        /// <inheritdoc />
        public async Task<Optional<Logs>> List(string organizationSlug, int pageSize = 100, int page = 1)
        {
            string status = null;
            string message = null;
            Logs auditLogs = null;

            try
            {
                string queryString = string.Empty;
                NameValueCollection queryStringCollection = HttpUtility.ParseQueryString(string.Empty);
                queryStringCollection.Add("page_size", pageSize.ToString());
                queryStringCollection.Add("page", page.ToString());
                queryString = $"?{queryStringCollection}";

                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}/audit-logs/{queryString}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    auditLogs = JsonSerializer.Deserialize<Logs>(content, ResponseSerializerOptions);
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

            return new Optional<Logs>(auditLogs, status, message);
        }

        #endregion
    }
}
