using System.Collections.Generic;

namespace TursoPlatformApi.Responses.Groups
{
    /// <summary>
    /// Represents a group with its associated properties.
    /// </summary>
    public class Group
    {
        /// <summary>
        /// The group name, unique across your organization.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The current libSQL server version the databases in that group are running.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The group universal unique identifier (UUID).
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// An array of location keys the group is located.
        /// </summary>
        public List<string> Locations { get; set; }

        /// <summary>
        /// The primary location key.
        /// </summary>
        public string Primary { get; set; }

        /// <summary>
        /// Indicates whether the group is archived. Groups on the free tier get archived after some inactivity.
        /// </summary>
        public bool Archived { get; set; }
    }
}
