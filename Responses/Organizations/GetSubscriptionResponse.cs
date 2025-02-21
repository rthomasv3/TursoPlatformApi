namespace TursoPlatformApi.Responses.Organizations
{
    public class GetSubscriptionResponse
    {
        public Subscription subscription { get; set; }
    }

    public class Subscription
    {
        /// <summary>
        /// The name of the plan for the current subscription.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Whether overages are enabled for the organization.
        /// </summary>
        public bool overages { get; set; }

        /// <summary>
        /// The name of the plan for the current subscription.
        /// </summary>
        public string plan { get; set; }

        /// <summary>
        /// Whether the plan is billed monthly or yearly.
        /// </summary>
        public string timeline { get; set; }
    }
}
