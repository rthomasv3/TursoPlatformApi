namespace TursoPlatformApi.Abstractions
{
    /// <summary>
    /// Used to perform actions using the Turso Platform API.
    /// </summary>
    public interface ITursoPlatformService
    {
        /// <summary>
        /// Manage Turso databases.
        /// </summary>
        ITursoDatabaseService Databases { get; }

        /// <summary>
        /// Manage Turso groups.
        /// </summary>
        ITursoGroupService Groups { get; }

        /// <summary>
        /// View Turso locations.
        /// </summary>
        ITursoLocationService Locations { get; }

        /// <summary>
        /// Manage Turso organizations.
        /// </summary>
        ITursoOrganizationsService Organizations { get; }

        /// <summary>
        /// Manage Turso members.
        /// </summary>
        ITursoMembersService Members { get; }

        /// <summary>
        /// Manage Turso invites.
        /// </summary>
        ITursoInvitesService Invites { get; }

        /// <summary>
        /// View Turso audit logs.
        /// </summary>
        ITursoAuditLogsService AuditLogs { get; }

        /// <summary>
        /// Manage Turso API tokens.
        /// </summary>
        ITursoApiTokensService ApiTokens { get; }
    }
}
