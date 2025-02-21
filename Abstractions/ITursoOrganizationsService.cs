using System.Collections.Generic;
using System.Threading.Tasks;
using TursoPlatformApi.Responses;
using TursoPlatformApi.Responses.Organizations;

namespace TursoPlatformApi.Abstractions
{
    /// <summary>
    /// Used to manage Turso organizations.
    /// </summary>
    public interface ITursoOrganizationsService
    {
        /// <summary>
        /// Returns a list of organizations the authenticated user owns or is a member of.
        /// </summary>
        /// <returns>The list of organizations.</returns>
        Task<Optional<List<Organization>>> List();

        /// <summary>
        /// Retrieve details of the default organization.
        /// </summary>
        /// <returns>The organization details.</returns>
        Task<Optional<Organization>> Retrieve();

        /// <summary>
        /// Retrieve details of a specific organization.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <returns>The organization details.</returns>
        Task<Optional<Organization>> Retrieve(string organizationSlug);

        /// <summary>
        /// Update the default organization that you own or are a member of.
        /// </summary>
        /// <param name="overages">Enable or disable overages for the organization.</param>
        /// <returns>The updated organization.</returns>
        Task<Optional<Organization>> Update(bool overages);

        /// <summary>
        /// Update an organization you own or are a member of.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="overages">Enable or disable overages for the organization.</param>
        /// <returns>The updated organization.</returns>
        Task<Optional<Organization>> Update(string organizationSlug, bool overages);

        /// <summary>
        /// Returns a list of available plans and their quotas for the organization the client was set up.
        /// </summary>
        /// <returns>The list of plans.</returns>
        Task<Optional<List<Plan>>> Plans();

        /// <summary>
        /// Returns a list of available plans and their quotas.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <returns>The list of plans.</returns>
        Task<Optional<List<Plan>>> Plans(string organizationSlug);

        /// <summary>
        /// Returns the current subscription details for the default organization.
        /// </summary>
        /// <returns>The subscription details.</returns>
        Task<Optional<Subscription>> CurrentSubscription();

        /// <summary>
        /// Returns the current subscription details for the organization.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <returns>The subscription details.</returns>
        Task<Optional<Subscription>> CurrentSubscription(string organizationSlug);

        /// <summary>
        /// Returns a list of invoices for the default organization.
        /// </summary>
        /// <param name="type">The type of invoice to retrieve. Available options: all, upcoming, issued</param>
        /// <returns>The list of invoices for the organization.</returns>
        Task<Optional<List<Invoice>>> Invoices(string type = null);

        /// <summary>
        /// Returns a list of invoices for the organization.
        /// </summary>
        /// <param name="organizationSlug">The slug of the organization or user account.</param>
        /// <param name="type">The type of invoice to retrieve. Available options: all, upcoming, issued</param>
        /// <returns>The list of invoices for the organization.</returns>
        Task<Optional<List<Invoice>>> Invoices(string organizationSlug, string type = null);

        /// <summary>
        /// Fetch current billing cycle usage for the default organization.
        /// </summary>
        /// <returns>The organization usage object, containing the total usage for rows read and written, as well as the total storage size (in bytes).</returns>
        Task<Optional<OrganizationUsage>> CurrentUsage();

        /// <summary>
        /// Fetch current billing cycle usage for an organization.
        /// </summary>
        /// <param name="organizationSlug"></param>
        /// <returns>The organization usage object, containing the total usage for rows read and written, as well as the total storage size (in bytes).</returns>
        Task<Optional<OrganizationUsage>> CurrentUsage(string organizationSlug);
    }
}
