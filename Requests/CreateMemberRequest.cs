namespace TursoPlatformApi.Requests
{
    internal class CreateMemberRequest
    {
        /// <summary>
        /// The username for the member.
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// The role assigned to the member.
        /// Available options: owner, admin, member, viewer
        /// </summary>
        public string role { get; set; }
    }
}
