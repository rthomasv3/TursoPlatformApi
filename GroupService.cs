using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TursoPlatformApi.Abstractions;

namespace TursoPlatformApi
{
    public class GroupService : ApiService, IGroupService
    {
        #region Fields

        #endregion

        #region Constructor

        public GroupService(IHttpClientFactory httpClientFactory, TursoAppSettings appSettings) 
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
