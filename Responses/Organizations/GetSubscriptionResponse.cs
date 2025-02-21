namespace TursoPlatformApi.Responses.Organizations
{
    internal class GetSubscriptionResponse
    {
        public Subscription Subscription { get; set; }
    }

    /// <summary>
    /// Subscription information.
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// The name of the plan for the current subscription.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether overages are enabled for the organization.
        /// </summary>
        public bool Overages { get; set; }

        /// <summary>
        /// The name of the plan for the current subscription.
        /// </summary>
        public string Plan { get; set; }

        /// <summary>
        /// Whether the plan is billed monthly or yearly.
        /// </summary>
        public string Timeline { get; set; }
    }
}
