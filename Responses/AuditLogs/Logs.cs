using System;
using System.Collections.Generic;

namespace TursoPlatformApi.Responses.AuditLogs
{
    /// <summary>
    /// Represents the response from the API containing audit logs and pagination details.
    /// </summary>
    public class Logs
    {
        /// <summary>
        /// List of audit logs.
        /// </summary>
        public List<AuditLog> AuditLogs { get; set; }

        /// <summary>
        /// Pagination details for the response.
        /// </summary>
        public Pagination Pagination { get; set; }
    }

    /// <summary>
    /// Represents an individual audit log entry.
    /// </summary>
    public class AuditLog
    {
        /// <summary>
        /// The code associated with the action taken.
        /// Available options: user-signup, db-create, db-delete, instance-create, instance-delete, org-create, org-delete, 
        /// org-member-add, org-member-rm, org-member-leave, org-plan-update, org-set-overages, group-create, group-delete, 
        /// mfa-enable, mfa-disable 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Additional context from the performed action.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Where this action was performed. Will be either cli or web depending on the User-Agent sent to the API.
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// The username of the user who performed the action.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// A formatted ISO 8601 timestamp this action was performed.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The payload of the action performed.
        /// </summary>
        public object Data { get; set; }
    }

    /// <summary>
    /// Represents the pagination details of the response.
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// The current page number.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// The number of items per page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The total number of pages.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// The total number of items.
        /// </summary>
        public long TotalRows { get; set; }
    }
}
