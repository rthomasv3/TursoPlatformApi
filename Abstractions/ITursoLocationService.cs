using System.Collections.Generic;
using System.Threading.Tasks;
using TursoPlatformApi.Responses;
using TursoPlatformApi.Responses.Locations;

namespace TursoPlatformApi.Abstractions
{
    public interface ITursoLocationService
    {
        /// <summary>
        /// Returns a list of locations where you can create or replicate databases.
        /// </summary>
        /// <returns>A mapping of location codes to location names.</returns>
        Task<Optional<Dictionary<string, string>>> List();

        /// <summary>
        /// Returns the closest region to the user’s location.
        /// </summary>
        /// <returns>The closest region server and client.</returns>
        Task<Optional<Region>> ClosestRegion();
    }
}
