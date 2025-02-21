using System.Collections.Generic;
using System.Threading.Tasks;
using TursoPlatformApi.Responses;
using TursoPlatformApi.Responses.Members;

namespace TursoPlatformApi.Abstractions
{
    public interface IMembersService
    {
        /// <summary>
        /// Returns a list of members part of the organization.
        /// </summary>
        /// <returns>A list of member details.</returns>
        Task<Optional<List<Member>>> List();

        /// <summary>
        /// Retrieve details of a specific member in the organization.
        /// </summary>
        /// <param name="username">The username of a Turso user or organization member.</param>
        /// <returns>The member details.</returns>
        Task<Optional<Member>> Retrieve(string username);

        /// <summary>
        /// Add an existing Turso user to an organization.
        /// </summary>
        /// <param name="username">The username of an existing Turso user.</param>
        /// <param name="role">The role given to the user. Available options: admin, member, viewer</param>
        /// <returns>The added member details.</returns>
        Task<Optional<AddedMember>> Add(string username, string role);

        /// <summary>
        /// Update the role of an organization member. Only organization admins or owners can perform this action.
        /// </summary>
        /// <param name="username">The username of a Turso user or organization member.</param>
        /// <param name="role">The new role to assign to the member. Available options: admin, member, viewer</param>
        /// <returns>The details of the updated member.</returns>
        Task<Optional<Member>> Update(string username, string role);

        /// <summary>
        /// Remove a user from the organization by username.
        /// </summary>
        /// <param name="username">The username of a Turso user or organization member.</param>
        /// <returns>The removed member.</returns>
        Task<Optional<string>> Remove(string username);
    }
}
