namespace TursoPlatformApi.Responses.Organizations
{
    /// <summary>
    /// Organization information.
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// The organization name. Every user has a personal organization for their own account.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The organization slug. This will be your username for personal accounts.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// The type of account this organization is. Will always be personal or team.
        /// Available options: personal, team
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The name of the organization. Every user has a personal organization for their own account.
        /// </summary>
        public bool Overages { get; set; }

        /// <summary>
        /// Returns the current status for blocked reads.
        /// </summary>
        public bool BlockedReads { get; set; }

        /// <summary>
        /// Returns the current status for blocked writes.
        /// </summary>
        public bool BlockedWrites { get; set; }

        /// <summary>
        /// The pricing plan identifier this organization is subscribed to.
        /// </summary>
        public string PlanId { get; set; }

        /// <summary>
        /// The billing cycle for the paid plan, if any.
        /// </summary>
        public string PlanTimeline { get; set; }

        /// <summary>
        /// The external platform this organization is managed by. Will be empty for Turso managed organizations.
        /// </summary>
        public string Platform { get; set; }
    }
}
