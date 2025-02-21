using System.Threading.Tasks;
using TursoPlatformApi.Responses;
using TursoPlatformApi.Responses.AuditLogs;

namespace TursoPlatformApi.Abstractions
{
    public interface ITursoAuditLogsService
    {
        /// <summary>
        /// Return the audit logs for the organization the client was set up with, ordered by the created_at field in descending order.
        /// </summary>
        /// <param name="pageSize">The limit of items to return per page. Defaults to 100.</param>
        /// <param name="page">The page number to return. Defaults to 1.</param>
        /// <returns>The audit logs.</returns>
        Task<Optional<Logs>> List(int pageSize = 100, int page = 1);

        /// <summary>
        /// Return the audit logs for the given organization, ordered by the created_at field in descending order.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="pageSize">The limit of items to return per page. Defaults to 100.</param>
        /// <param name="page">The page number to return. Defaults to 1.</param>
        /// <returns>The audit logs.</returns>
        Task<Optional<Logs>> List(string organizationSlug, int pageSize = 100, int page = 1);
    }
}
