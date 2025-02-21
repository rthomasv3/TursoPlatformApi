using System.Collections.Generic;

namespace TursoPlatformApi.Responses.Members
{
    /// <summary>
    /// Represents the response from the API.
    /// </summary>
    public class ListMembersResponse
    {
        /// <summary>
        /// List of members in the response.
        /// </summary>
        public List<Member> Members { get; set; }
    }

    /// <summary>
    /// Represents a member in the API response.
    /// </summary>
    public class Member
    {
        /// <summary>
        /// The username for the member.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The role assigned to the member.
        /// Available options: owner, admin, member, viewer
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// The email for the member.
        /// </summary>
        public string Email { get; set; }
    }
}
