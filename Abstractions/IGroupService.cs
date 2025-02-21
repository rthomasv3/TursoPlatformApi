﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TursoPlatformApi.Responses;
using TursoPlatformApi.Responses.Groups;

namespace TursoPlatformApi.Abstractions
{
    public interface IGroupService
    {
        /// <summary>
        /// Returns a list of groups belonging to the organization or user.
        /// </summary>
        /// <returns>The list of groups.</returns>
        Task<Optional<List<Group>>> List();

        /// <summary>
        /// Creates a new group for the organization or user.
        /// </summary>
        /// <param name="name">The name of the new group.</param>
        /// <param name="location">The location key for the new group.</param>
        /// <param name="extensions">The extensions to enable for new databases created in this group. Users looking to enable vector extensions should instead use the native libSQL vector datatype. Available options: all</param>
        /// <returns>The newly created group</returns>
        Task<Optional<Group>> Create(string name, string location, string extensions = null);

        /// <summary>
        /// Returns a group belonging to the organization or user.
        /// </summary>
        /// <param name="groupName">The name of the group.</param>
        /// <returns>The group details.</returns>
        Task<Optional<Group>> Retrieve(string groupName);

        /// <summary>
        /// Delete a group belonging to the organization or user.
        /// </summary>
        /// <param name="groupName">The name of the group.</param>
        /// <returns>The deleted group details.</returns>
        Task<Optional<Group>> Delete(string groupName);

        /// <summary>
        /// Transfer a group to another organization that you own or a member of.
        /// </summary>
        /// <param name="groupName">The name of the group.</param>
        /// <param name="organization">The slug of the organization to transfer the group to.</param>
        /// <returns>The transfered group details.</returns>
        Task<Optional<Group>> Transfer(string groupName, string organization);

        /// <summary>
        /// Unarchive a group that has been archived due to inactivity.
        /// </summary>
        /// <param name="groupName">The name of the group.</param>
        /// <returns>The unarchived group details.</returns>
        Task<Optional<Group>> Unarchive(string groupName);

        /// <summary>
        /// Updates all databases in the group to the latest libSQL version.
        /// </summary>
        /// <param name="groupName">The name of the group.</param>
        /// <returns>A value indicating if the update request was successful.</returns>
        /// <remarks>
        /// This operation causes some amount of downtime to occur during the update process. The version of libSQL server is taken from the latest built docker image.
        /// </remarks>
        Task<Optional<bool>> UpdateVersions(string groupName);

        /// <summary>
        /// Generates an authorization token for the specified group.
        /// </summary>
        /// <param name="groupName">The name of the group.</param>
        /// <param name="expiration">Expiration time for the token (e.g., 2w1d30m).</param>
        /// <param name="authorization">Authorization level for the token (full-access or read-only).</param>
        /// <param name="readAttachDatabases">Read ATTACH permission for the token to read other databases.</param>
        /// <returns>The newly created jwt token.</returns>
        Task<Optional<string>> CreateToken(string groupName, string expiration = null,
            string authorization = null, List<string> readAttachDatabases = null);

        /// <summary>
        /// Invalidates all authorization tokens for the specified group.
        /// </summary>
        /// <param name="groupName">The name of the group.</param>
        /// <returns>A value indicating if the tokens were invalidated successfully.</returns>
        Task<Optional<bool>> InvalidateTokens(string groupName);
    }
}
