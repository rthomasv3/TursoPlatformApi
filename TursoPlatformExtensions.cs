using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TursoPlatformApi.Abstractions;

namespace TursoPlatformApi
{
    public static class TursoPlatformExtensions
    {
        public static IServiceCollection AddTursoPlatformService(this IServiceCollection services)
        {
            TursoAppSettings appSettings = new TursoAppSettings();

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();

            IConfigurationSection tursoSection = configuration.GetSection("TursoPlatformApi");

            if (tursoSection.Exists())
            {
                appSettings.OrganizationSlug = tursoSection["OrganizationSlug"];
                appSettings.AuthToken = tursoSection["AuthToken"];
            }

            services.AddTursoServices(appSettings);

            return services;
        }

        public static IServiceCollection AddTursoPlatformService(this IServiceCollection services, string organizationSlug, string authToken)
        {
            TursoAppSettings appSettings = new TursoAppSettings()
            {
                OrganizationSlug = organizationSlug,
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
