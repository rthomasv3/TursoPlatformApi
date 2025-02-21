namespace TursoPlatformApi.Responses.Organizations
{
    public class Organization
    {
        /// <summary>
        /// The organization name. Every user has a personal organization for their own account.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The organization slug. This will be your username for personal accounts.
        /// </summary>
        public string slug { get; set; }

        /// <summary>
        /// The type of account this organization is. Will always be personal or team.
        /// Available options: personal, team
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// The name of the organization. Every user has a personal organization for their own account.
        /// </summary>
        public bool overages { get; set; }

        /// <summary>
        /// Returns the current status for blocked reads.
        /// </summary>
        public bool blocked_reads { get; set; }

        /// <summary>
        /// Returns the current status for blocked writes.
        /// </summary>
        public bool blocked_writes { get; set; }

        /// <summary>
        /// The pricing plan identifier this organization is subscribed to.
        /// </summary>
        public string plan_id { get; set; }

        /// <summary>
        /// The billing cycle for the paid plan, if any.
        /// </summary>
        public string plan_timeline { get; set; }

        /// <summary>
        /// The external platform this organization is managed by. Will be empty for Turso managed organizations.
        /// </summary>
        public string platform { get; set; }
    }
}
