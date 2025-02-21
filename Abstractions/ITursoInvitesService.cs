using System.Collections.Generic;
using System.Threading.Tasks;
using TursoPlatformApi.Responses;
using TursoPlatformApi.Responses.Invites;

namespace TursoPlatformApi.Abstractions
{
    public interface ITursoInvitesService
    {
        /// <summary>
        /// Returns a list of invites for the organization the client was set up with.
        /// </summary>
        /// <returns>The list of invites.</returns>
        Task<Optional<List<Invite>>> List();

        /// <summary>
        /// Invite a user (who isn’t already a Turso user) to an organization.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <returns>The list of invites.</returns>
        Task<Optional<List<Invite>>> List(string organizationSlug);

        /// <summary>
        /// Invite a user (who isn’t already a Turso user) to an organization.
        /// </summary>
        /// <param name="email">The email of the user you want to invite.</param>
        /// <param name="role">The role given to the user. Available options: admin, member, viewer</param>
        /// <returns>The invite info.</returns>
        /// <remarks>
        /// If you want to invite someone who is already a registered Turso user, you can add them instead.
        /// You must be an owner or admin to invite other users. You can only invite users to a team and not your personal account.
        /// </remarks>
        Task<Optional<Invite>> Create(string email, string role = "member");

        /// <summary>
        /// Delete an invite for the organization by email.
        /// </summary>
        /// <param name="email">The email of the user invited.</param>
        /// <returns>A value indicating if the invite was deleted successfully.</returns>
        Task<Optional<bool>> Delete(string email);
    }
}
