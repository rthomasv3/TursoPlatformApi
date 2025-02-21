using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TursoPlatformApi.Abstractions;
using TursoPlatformApi.Responses;
using TursoPlatformApi.Responses.Locations;

namespace TursoPlatformApi
{
    public class LocationService : ApiService, ITursoLocationService
    {
        #region Fields

        #endregion

        #region Constructor

        public LocationService(IHttpClientFactory httpClientFactory, TursoAppSettings appSettings) 
            : base(httpClientFactory, appSettings)
        { }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public async Task<Optional<Dictionary<string, string>>> List()
        {
            string status = null;
            string message = null;
            Dictionary<string, string> locations = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync("locations");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    LocationsResponse locationsResponse = JsonSerializer.Deserialize<LocationsResponse>(content, ResponseSerializerOptions);
                    locations = locationsResponse.locations;
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

            return new Optional<Dictionary<string, string>>(locations, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Region>> ClosestRegion()
        {
            string status = null;
            string message = null;
            Region region = null;

            try
            {
                HttpResponseMessage response = await DefaultClient.GetAsync("https://region.turso.io");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    region = JsonSerializer.Deserialize<Region>(content, ResponseSerializerOptions);
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

            return new Optional<Region>(region, status, message);
        }

        #endregion
    }
}
