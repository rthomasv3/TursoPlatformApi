using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TursoPlatformApi.Responses.Organizations
{
    /// <summary>
    /// Represents the response containing a list of available plans.
    /// </summary>
    internal class GetPlansResponse
    {
        /// <summary>
        /// List of available plans.
        /// </summary>
        public List<Plan> Plans { get; set; }
    }

    /// <summary>
    /// Represents a plan with its details.
    /// </summary>
    public class Plan
    {
        /// <summary>
        /// The name of the plan.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The monthly price of the plan.
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// List of prices for the plan with different timelines.
        /// </summary>
        public List<Price> Prices { get; set; }

        /// <summary>
        /// The quotas associated with the plan.
        /// </summary>
        public Quotas Quotas { get; set; }
    }

    /// <summary>
    /// Represents the price details for a plan.
    /// </summary>
    public class Price
    {
        /// <summary>
        /// Price of the available plan.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Payment regularity (e.g., monthly, annually).
        /// </summary>
        public string Timeline { get; set; }
    }

    /// <summary>
    /// Represents the quotas associated with a plan.
    /// </summary>
    public class Quotas
    {
        /// <summary>
        /// The number of rows read allowed for the specific plan.
        /// </summary>
        [JsonPropertyName("rowsRead")]
        public long RowsRead { get; set; }

        /// <summary>
        /// The number of rows written allowed for the specific plan.
        /// </summary>
        [JsonPropertyName("rowsWritten")]
        public long RowsWritten { get; set; }

        /// <summary>
        /// The number of databases allowed for the specific plan. Can be null.
        /// </summary>
        public int? Databases { get; set; }

        /// <summary>
        /// The number of locations allowed for the specific plan.
        /// </summary>
        public int Locations { get; set; }

        /// <summary>
        /// The amount of storage allowed for the specific plan, in bytes.
        /// </summary>
        public long Storage { get; set; }

        /// <summary>
        /// The number of groups allowed for the specific plan.
        /// </summary>
        public int Groups { get; set; }

        /// <summary>
        /// The number of bytes synced allowed for the specific plan, in bytes.
        /// </summary>
        [JsonPropertyName("bytesSynced")]
        public long BytesSynced { get; set; }
    }
}
