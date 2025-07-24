using System;
using System.Collections;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TursoPlatformApi.Abstractions;

namespace TursoPlatformApi
{
    /// <summary>
    /// Extension methods used to setup the Turso platform API for dependency injection.
    /// </summary>
    public static class TursoPlatformExtensions
    {
        /// <summary>
        /// Adds the Turso API services using the configuration from appsettings.json.
        /// </summary>
        /// <param name="services">The services collection.</param>
        /// <returns>The services collection.</returns>
        public static IServiceCollection AddTursoPlatformService(this IServiceCollection services)
        {
            TursoAppSettings appSettings = new TursoAppSettings();

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            IConfigurationRoot configuration = builder.Build();

            IConfigurationSection tursoSection = configuration.GetSection("TursoPlatformApi");

            if (tursoSection.Exists())
            {
                appSettings.DefaultOrganizationSlug = tursoSection["DefaultOrganizationSlug"];
                appSettings.AuthToken = tursoSection["AuthToken"];
            }
            
            if (String.IsNullOrWhiteSpace(appSettings.DefaultOrganizationSlug))
            {
                IDictionary envVariables = Environment.GetEnvironmentVariables();

                if (envVariables.Contains("TursoPlatformApi:DefaultOrganizationSlug"))
                {
                    appSettings.DefaultOrganizationSlug = envVariables["TursoPlatformApi:DefaultOrganizationSlug"].ToString();
                }
                else if (envVariables.Contains("TursoPlatformApiDefaultOrganizationSlug"))
                {
                    appSettings.DefaultOrganizationSlug = envVariables["TursoPlatformApiDefaultOrganizationSlug"].ToString();
                }
            }

            if (String.IsNullOrWhiteSpace(appSettings.AuthToken))
            {
                IDictionary envVariables = Environment.GetEnvironmentVariables();

                if (envVariables.Contains("TursoPlatformApi:AuthToken"))
                {
                    appSettings.AuthToken = envVariables["TursoPlatformApi:AuthToken"].ToString();
                }
                else if (envVariables.Contains("TursoPlatformApiAuthToken"))
                {
                    appSettings.AuthToken = envVariables["TursoPlatformApiAuthToken"].ToString();
                }
            }

            services.AddTursoServices(appSettings);

            return services;
        }

        /// <summary>
        /// Adds the Turso API services using the provided configuration.
        /// </summary>
        /// <param name="services">The services collection.</param>
        /// <param name="organizationSlug">The default organization slug to use when not provided to the method.</param>
        /// <param name="authToken">Your Turso platform API auth token.</param>
        /// <returns>The services collection.</returns>
        public static IServiceCollection AddTursoPlatformService(this IServiceCollection services, string organizationSlug, string authToken)
        {
            TursoAppSettings appSettings = new TursoAppSettings()
            {
                DefaultOrganizationSlug = organizationSlug,
                AuthToken = authToken,
            };

            services.AddTursoServices(appSettings);

            return services;
        }

        internal static IServiceCollection AddTursoServices(this IServiceCollection services, TursoAppSettings appSettings)
        {
            services.AddHttpClient(appSettings.TursoClientName, configureClient =>
            {
                configureClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {appSettings.AuthToken}");
                configureClient.BaseAddress = new Uri("https://api.turso.tech/v1/");
            });

            services.AddHttpClient(appSettings.DefaultClientName);

            services.AddSingleton(appSettings)
                    .AddSingleton<ITursoPlatformService, TursoPlatformService>()
                    .AddSingleton<ITursoDatabaseService, DatabaseService>()
                    .AddSingleton<ITursoGroupService, GroupService>()
                    .AddSingleton<ITursoLocationService, LocationService>()
                    .AddSingleton<ITursoOrganizationsService, OrganizationsService>()
                    .AddSingleton<ITursoMembersService, MembersService>()
                    .AddSingleton<ITursoInvitesService, InvitesService>()
                    .AddSingleton<ITursoAuditLogsService, AuditLogsService>()
                    .AddSingleton<ITursoApiTokensService, ApiTokensService>();

            return services;
        }
    }
}
