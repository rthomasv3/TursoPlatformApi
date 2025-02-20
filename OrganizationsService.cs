using System.Net.Http;
using TursoPlatformApi.Abstractions;

namespace TursoPlatformApi
{
    public class OrganizationsService : ApiService, IOrganizationsService
    {
        #region Fields

        #endregion

        #region Constructor

        public OrganizationsService(IHttpClientFactory httpClientFactory, TursoAppSettings appSettings)
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
