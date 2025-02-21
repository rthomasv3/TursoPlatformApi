using System.Collections.Generic;

namespace TursoPlatformApi.Responses.Organizations
{
    /// <summary>
    /// Represents the response containing a list of available plans.
    /// </summary>
    public class GetPlansResponse
    {
        /// <summary>
        /// List of available plans.
        /// </summary>
        public List<Plan> plans { get; set; }
    }

    /// <summary>
    /// Represents a plan with its details.
    /// </summary>
    public class Plan
    {
        /// <summary>
        /// The name of the plan.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The monthly price of the plan.
        /// </summary>
        public string price { get; set; }

        /// <summary>
        /// List of prices for the plan with different timelines.
        /// </summary>
        public List<Price> prices { get; set; }

        /// <summary>
        /// The quotas associated with the plan.
        /// </summary>
        public Quotas quotas { get; set; }
    }

    /// <summary>
    /// Represents the price details for a plan.
    /// </summary>
    public class Price
    {
        /// <summary>
        /// Price of the available plan.
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// Payment regularity (e.g., monthly, annually).
        /// </summary>
        public string timeline { get; set; }
    }

    /// <summary>
    /// Represents the quotas associated with a plan.
    /// </summary>
    public class Quotas
    {
        /// <summary>
        /// The number of rows read allowed for the specific plan.
        /// </summary>
        public long rowsRead { get; set; }

        /// <summary>
        /// The number of rows written allowed for the specific plan.
        /// </summary>
        public long rowsWritten { get; set; }

        /// <summary>
        /// The number of databases allowed for the specific plan. Can be null.
        /// </summary>
        public int? databases { get; set; }

        /// <summary>
        /// The number of locations allowed for the specific plan.
        /// </summary>
        public int locations { get; set; }

        /// <summary>
        /// The amount of storage allowed for the specific plan, in bytes.
        /// </summary>
        public long storage { get; set; }

        /// <summary>
        /// The number of groups allowed for the specific plan.
        /// </summary>
        public int groups { get; set; }

        /// <summary>
        /// The number of bytes synced allowed for the specific plan, in bytes.
        /// </summary>
        public long bytesSynced { get; set; }
    }
}
