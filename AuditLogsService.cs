using System.Net.Http;
using TursoPlatformApi.Abstractions;

namespace TursoPlatformApi
{
    public class AuditLogsService : ApiService, IAuditLogsService
    {
        #region Fields

        #endregion

        #region Constructor

        public AuditLogsService(IHttpClientFactory httpClientFactory, TursoAppSettings appSettings) 
            : base(httpClientFactory, appSettings)
        {

        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
