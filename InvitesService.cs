using System.Net.Http;
using TursoPlatformApi.Abstractions;

namespace TursoPlatformApi
{
    public class InvitesService : ApiService, IInvitesService
    {
        #region Fields

        #endregion

        #region Constructor

        public InvitesService(IHttpClientFactory httpClientFactory, TursoAppSettings appSettings) 
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
