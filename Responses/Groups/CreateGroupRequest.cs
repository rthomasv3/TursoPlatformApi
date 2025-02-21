namespace TursoPlatformApi.Responses.Groups
{
    internal class CreateGroupRequest
    {
        /// <summary>
        /// The name of the new group.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The location key for the new group.
        /// </summary>
        public string location { get; set; }

        /// <summary>
        /// The extensions to enable for new databases created in this group. Users looking to enable vector extensions should instead use the native libSQL vector datatype.
        /// Available options: all
        /// </summary>
        public string extensions { get; set; }
    }
}
