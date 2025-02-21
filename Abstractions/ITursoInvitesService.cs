using System.Collections.Generic;
using System.Threading.Tasks;
using TursoPlatformApi.Responses;
using TursoPlatformApi.Responses.Invites;

namespace TursoPlatformApi.Abstractions
{
    /// <summary>
    /// Used to manage Turso invites.
    /// </summary>
    public interface ITursoInvitesService
    {
        /// <summary>
        /// Returns a list of invites for the default organization.
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
        /// Invite a user (who isn’t already a Turso user) to the default organization.
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
        /// Invite a user (who isn’t already a Turso user) to an organization.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="email">The email of the user you want to invite.</param>
        /// <param name="role">The role given to the user. Available options: admin, member, viewer</param>
        /// <returns>The invite info.</returns>
        /// <remarks>
        /// If you want to invite someone who is already a registered Turso user, you can add them instead.
        /// You must be an owner or admin to invite other users. You can only invite users to a team and not your personal account.
        /// </remarks>
        Task<Optional<Invite>> Create(string organizationSlug, string email, string role = "member");

        /// <summary>
        /// Delete an invite for the default organization by email.
        /// </summary>
        /// <param name="email">The email of the user invited.</param>
        /// <returns>A value indicating if the invite was deleted successfully.</returns>
        Task<Optional<bool>> Delete(string email);

        /// <summary>
        /// Delete an invite for the organization by email.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="email">The email of the user invited.</param>
        /// <returns>A value indicating if the invite was deleted successfully.</returns>
        Task<Optional<bool>> Delete(string organizationSlug, string email);
    }
}
