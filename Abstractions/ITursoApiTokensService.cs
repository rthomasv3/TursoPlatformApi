using System.Collections.Generic;
using System.Threading.Tasks;
using TursoPlatformApi.Responses;
using TursoPlatformApi.Responses.ApiTokens;

namespace TursoPlatformApi.Abstractions
{
    /// <summary>
    /// Used to manage Turso API tokens.
    /// </summary>
    public interface ITursoApiTokensService
    {
        /// <summary>
        /// Returns a new API token belonging to a user.
        /// </summary>
        /// <param name="tokenName">The name of the api token.</param>
        /// <returns>The created API token.</returns>
        /// <remarks>The token in the response is never revealed again. Store this somewhere safe, and never share or commit it to source control.</remarks>
        Task<Optional<CreatedApiToken>> Create(string tokenName);

        /// <summary>
        /// Validates the API token the default organization.
        /// </summary>
        /// <returns>The time of expiration for the provided token in unix epoch seconds, or -1 if there is no expiration.</returns>
        Task<Optional<int>> Validate();

        /// <summary>
        /// Validates an API token belonging to a user.
        /// </summary>
        /// <param name="authToken">The auth token to validate.</param>
        /// <returns>The time of expiration for the provided token in unix epoch seconds, or -1 if there is no expiration.</returns>
        Task<Optional<int>> Validate(string authToken);

        /// <summary>
        /// Returns a list of API tokens belonging to a user.
        /// </summary>
        /// <returns>The list of tokens with their name and ID.</returns>
        Task<Optional<List<ApiToken>>> List();

        /// <summary>
        /// Revokes the provided API token belonging to a user.
        /// </summary>
        /// <param name="tokenName">The name of the api token.</param>
        /// <returns>The revoked token name.</returns>
        Task<Optional<string>> Revoke(string tokenName);
    }
}
