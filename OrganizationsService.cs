using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using TursoPlatformApi.Abstractions;
using TursoPlatformApi.Requests;
using TursoPlatformApi.Responses;
using TursoPlatformApi.Responses.Organizations;

namespace TursoPlatformApi
{
    public class OrganizationsService : ApiService, IOrganizationsService
    {
        #region Fields

        #endregion

        #region Constructor

        public OrganizationsService(IHttpClientFactory httpClientFactory, TursoAppSettings appSettings)
            : base(httpClientFactory, appSettings)
        { }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public async Task<Optional<List<Organization>>> List()
        {
            string status = null;
            string message = null;
            List<Organization> organizations = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync("organizations");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    organizations = JsonSerializer.Deserialize<List<Organization>>(content, JsonSerializerOptions);
                }
                else
                {
                    ParseError(response, content, ref status, ref message);
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<List<Organization>>(organizations, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Organization>> Retrieve()
        {
            string status = null;
            string message = null;
            Organization organization = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{AppSettings.OrganizationSlug}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    GetOrganizationResponse organizationResponse = JsonSerializer.Deserialize<GetOrganizationResponse>(content, JsonSerializerOptions);
                    organization = organizationResponse.organization;
                }
                else
                {
                    ParseError(response, content, ref status, ref message);
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<Organization>(organization, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Organization>> Retrieve(string organizationSlug)
        {
            string status = null;
            string message = null;
            Organization organization = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    GetOrganizationResponse organizationResponse = JsonSerializer.Deserialize<GetOrganizationResponse>(content, JsonSerializerOptions);
                    organization = organizationResponse.organization;
                }
                else
                {
                    ParseError(response, content, ref status, ref message);
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<Organization>(organization, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Organization>> Update(bool overages)
        {
            string status = null;
            string message = null;
            Organization organization = null;

            try
            {
                UpdateOrganizationRequest updateOrgRequest = new UpdateOrganizationRequest()
                {
                    overages = overages
                };
                string updateOrgJson = JsonSerializer.Serialize(updateOrgRequest, JsonSerializerOptions);

                using (StringContent requestContent = new StringContent(updateOrgJson, System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage response = await TursoClient.PatchAsync($"organizations/{AppSettings.OrganizationSlug}", requestContent);
                    string content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        GetOrganizationResponse organizationResponse = JsonSerializer.Deserialize<GetOrganizationResponse>(content, JsonSerializerOptions);
                        organization = organizationResponse.organization;
                    }
                    else
                    {
                        ParseError(response, content, ref status, ref message);
                    }
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<Organization>(organization, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Organization>> Update(string organizationSlug, bool overages)
        {
            string status = null;
            string message = null;
            Organization organization = null;

            try
            {
                UpdateOrganizationRequest updateOrgRequest = new UpdateOrganizationRequest()
                {
                    overages = overages
                };
                string updateOrgJson = JsonSerializer.Serialize(updateOrgRequest, JsonSerializerOptions);

                using (StringContent requestContent = new StringContent(updateOrgJson, System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage response = await TursoClient.PatchAsync($"organizations/{organizationSlug}", requestContent);
                    string content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        GetOrganizationResponse organizationResponse = JsonSerializer.Deserialize<GetOrganizationResponse>(content, JsonSerializerOptions);
                        organization = organizationResponse.organization;
                    }
                    else
                    {
                        ParseError(response, content, ref status, ref message);
                    }
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<Organization>(organization, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<List<Plan>>> Plans()
        {
            string status = null;
            string message = null;
            List<Plan> plans = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{AppSettings.OrganizationSlug}/plans");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    GetPlansResponse plansResponse = JsonSerializer.Deserialize<GetPlansResponse>(content, JsonSerializerOptions);
                    plans = plansResponse.plans;
                }
                else
                {
                    ParseError(response, content, ref status, ref message);
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<List<Plan>>(plans, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<List<Plan>>> Plans(string organizationSlug)
        {
            string status = null;
            string message = null;
            List<Plan> plans = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}/plans");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    GetPlansResponse plansResponse = JsonSerializer.Deserialize<GetPlansResponse>(content, JsonSerializerOptions);
                    plans = plansResponse.plans;
                }
                else
                {
                    ParseError(response, content, ref status, ref message);
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<List<Plan>>(plans, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Subscription>> CurrentSubscription()
        {
            string status = null;
            string message = null;
            Subscription subscription = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{AppSettings.OrganizationSlug}/subscription");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    GetSubscriptionResponse subscriptionResponse = JsonSerializer.Deserialize<GetSubscriptionResponse>(content, JsonSerializerOptions);
                    subscription = subscriptionResponse.subscription;
                }
                else
                {
                    ParseError(response, content, ref status, ref message);
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<Subscription>(subscription, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<Subscription>> CurrentSubscription(string organizationSlug)
        {
            string status = null;
            string message = null;
            Subscription subscription = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}/subscription");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    GetSubscriptionResponse subscriptionResponse = JsonSerializer.Deserialize<GetSubscriptionResponse>(content, JsonSerializerOptions);
                    subscription = subscriptionResponse.subscription;
                }
                else
                {
                    ParseError(response, content, ref status, ref message);
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<Subscription>(subscription, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<List<Invoice>>> Invoices(string type = null)
        {
            string status = null;
            string message = null;
            List<Invoice> invoices = null;

            try
            {
                string queryString = string.Empty;
                NameValueCollection queryStringCollection = HttpUtility.ParseQueryString(string.Empty);

                if (!string.IsNullOrEmpty(type))
                {
                    queryStringCollection.Add("expiration", type);
                }

                if (queryStringCollection.Count > 0)
                {
                    queryString = $"?{queryStringCollection}";
                }

                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{AppSettings.OrganizationSlug}/invoices{queryString}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    GetInvoicesResponse invoicesResponse = JsonSerializer.Deserialize<GetInvoicesResponse>(content, JsonSerializerOptions);
                    invoices = invoicesResponse.invoices;
                }
                else
                {
                    ParseError(response, content, ref status, ref message);
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<List<Invoice>>(invoices, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<List<Invoice>>> Invoices(string organizationSlug, string type = null)
        {
            string status = null;
            string message = null;
            List<Invoice> invoices = null;

            try
            {
                string queryString = string.Empty;
                NameValueCollection queryStringCollection = HttpUtility.ParseQueryString(string.Empty);

                if (!string.IsNullOrEmpty(type))
                {
                    queryStringCollection.Add("expiration", type);
                }

                if (queryStringCollection.Count > 0)
                {
                    queryString = $"?{queryStringCollection}";
                }

                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{organizationSlug}/invoices{queryString}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    GetInvoicesResponse invoicesResponse = JsonSerializer.Deserialize<GetInvoicesResponse>(content, JsonSerializerOptions);
                    invoices = invoicesResponse.invoices;
                }
                else
                {
                    ParseError(response, content, ref status, ref message);
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<List<Invoice>>(invoices, status, message);
        }

        /// <inheritdoc />
        public async Task<Optional<OrganizationUsage>> CurrentUsage()
        {
            string status = null;
            string message = null;
            OrganizationUsage organizationUsage = null;

            try
            {
                HttpResponseMessage response = await TursoClient.GetAsync($"organizations/{AppSettings.OrganizationSlug}/usage");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    GetUsageResponse usageResponse = JsonSerializer.Deserialize<GetUsageResponse>(content, JsonSerializerOptions);
                    organizationUsage = usageResponse.organization;
                    organizationUsage.total = usageResponse.total;
                }
                else
                {
                    ParseError(response, content, ref status, ref message);
                }
            }
            catch (Exception ex)
            {
                status = "Exception";
                message = ex.ToString();
            }

            return new Optional<OrganizationUsage>(organizationUsage, status, message);
        }

        #endregion
    }
}
