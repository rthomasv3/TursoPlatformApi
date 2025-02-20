using System.Net.Http;
using TursoPlatformApi.Abstractions;

namespace TursoPlatformApi
{
    public class ApiTokensService : ApiService, IApiTokensService
    {
        #region Fields

        #endregion

        #region Constructor

        public ApiTokensService(IHttpClientFactory httpClientFactory, TursoAppSettings appSettings) 
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
