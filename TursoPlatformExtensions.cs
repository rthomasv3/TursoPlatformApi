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
            TursoAppSettings appSettings = new TursoAppSettings()
            {
                TursoClientName = "TursoClient",
            };

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

            services.AddHttpClient(appSettings.TursoClientName, configureClient =>
            {
                configureClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {appSettings.AuthToken}");
                configureClient.BaseAddress = new Uri("https://api.turso.tech/v1/");
            });

            services.AddSingleton(appSettings);
            services.AddSingleton<ITursoPlatformService, TursoPlatformService>();
            services.AddSingleton<IDatabaseService, DatabaseService>();
            services.AddSingleton<IGroupService, GroupService>();
            services.AddSingleton<ILocationService, LocationService>();
            services.AddSingleton<IOrganizationsService, OrganizationsService>();
            services.AddSingleton<IMembersService, MembersService>();
            services.AddSingleton<IInvitesService, InvitesService>();
            services.AddSingleton<IAuditLogsService, AuditLogsService>();
            services.AddSingleton<IApiTokensService, ApiTokensService>();

            return services;
        }
    }
}
