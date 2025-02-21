using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TursoPlatformApi.Responses.Invites
{
    public class ListInvitesResponse
    {
        public List<Invite> invites { get; set; }
    }

    public class Invite
    {
        /// <summary>
        /// The unique ID for the invite.
        /// </summary>
        [JsonPropertyName("ID")]
        public int ID { get; set; }

        /// <summary>
        /// The datetime the invite was created in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The datetime the invite was updated in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// The datetime the invite was deleted (or revoked) in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("DeletedAt")]
        public DateTime DeletedAt { get; set; }

        /// <summary>
        /// The assigned role for the invited user.
        /// Available options: admin, member, viewer.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// The email of the person invited.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The ID of the organization the user was invited to.
        /// </summary>
        [JsonPropertyName("OrganizationID")]
        public int OrganizationID { get; set; }

        /// <summary>
        /// The unique token used to verify the invite.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The organization object associated with the invite.
        /// </summary>
        public Organization Organization { get; set; }

        /// <summary>
        /// The current status of the invite.
        /// </summary>
        public bool Accepted { get; set; }
    }

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
        /// The type of account this organization is. Will always be personal or team. Available options: personal, team 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The name of the organization. Every user has a personal organization for their own account.
        /// </summary>
        public bool Overages { get; set; }

        /// <summary>
        /// Returns the current status for blocked reads.
        /// </summary>
        [JsonPropertyName("blocked_reads")]
        public bool BlockedReads { get; set; }

        /// <summary>
        /// Returns the current status for blocked writes.
        /// </summary>
        [JsonPropertyName("blocked_writes")]
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
