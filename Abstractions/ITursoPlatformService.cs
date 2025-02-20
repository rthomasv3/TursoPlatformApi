namespace TursoPlatformApi.Abstractions
{
    public interface ITursoPlatformService
    {
        IDatabaseService Databases { get; }
        IGroupService Groups { get; }
        ILocationService Locations { get; }
        IOrganizationsService Organizations { get; }
        IMembersService Members { get; }
        IInvitesService Invites { get; }
        IAuditLogsService AuditLogs { get; }
        IApiTokensService ApiTokens { get; }
    }
}
