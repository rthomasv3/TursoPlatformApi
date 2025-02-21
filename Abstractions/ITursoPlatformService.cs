namespace TursoPlatformApi.Abstractions
{
    public interface ITursoPlatformService
    {
        ITursoDatabaseService Databases { get; }
        ITursoGroupService Groups { get; }
        ITursoLocationService Locations { get; }
        ITursoOrganizationsService Organizations { get; }
        ITursoMembersService Members { get; }
        ITursoInvitesService Invites { get; }
        ITursoAuditLogsService AuditLogs { get; }
        ITursoApiTokensService ApiTokens { get; }
    }
}
