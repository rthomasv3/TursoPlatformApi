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
        public string name { get; set; }

        /// <summary>
        /// The current libSQL server version the databases in that group are running.
        /// </summary>
        public string version { get; set; }

        /// <summary>
        /// The group universal unique identifier (UUID).
        /// </summary>
        public string uuid { get; set; }

        /// <summary>
        /// An array of location keys the group is located.
        /// </summary>
        public List<string> locations { get; set; }

        /// <summary>
        /// The primary location key.
        /// </summary>
        public string primary { get; set; }

        /// <summary>
        /// Indicates whether the group is archived. Groups on the free tier get archived after some inactivity.
        /// </summary>
        public bool archived { get; set; }
    }
}
