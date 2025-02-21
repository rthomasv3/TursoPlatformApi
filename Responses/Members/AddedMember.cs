namespace TursoPlatformApi.Responses.Members
{
    /// <summary>
    /// Information about the added member.
    /// </summary>
    public class AddedMember
    {
        /// <summary>
        /// Member name.
        /// </summary>
        public string Member { get; set; }

        /// <summary>
        /// The role given to the user.
        /// </summary>
        public string Role { get; set; }
    }
}
