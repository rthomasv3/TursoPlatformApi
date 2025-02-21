using System;
using Microsoft.Extensions.DependencyInjection;
using TursoPlatformApi.Abstractions;

namespace TursoPlatformApi
{
    /// <summary>
    /// Class used to perform actions using the Turso Platform API.
    /// </summary>
    public class TursoPlatformService : ITursoPlatformService
    {
        #region Fields

        private static TursoPlatformService _instance;
        private static TursoAppSettings _appSettings;

        private readonly ITursoDatabaseService _databaseService;
        private readonly ITursoGroupService _groupService;
        private readonly ITursoLocationService _locationService;
        private readonly ITursoOrganizationsService _organizationsService;
        private readonly ITursoMembersService _membersService;
        private readonly ITursoInvitesService _invitesService;
        private readonly ITursoAuditLogsService _auditLogsService;
        private readonly ITursoApiTokensService _apiTokensService;

        #endregion

        #region Constructors

        public TursoPlatformService(ITursoDatabaseService databaseService, ITursoGroupService groupService, ITursoLocationService locationService,
            ITursoOrganizationsService organizationsService, ITursoMembersService membersService, ITursoInvitesService invitesService,
            ITursoAuditLogsService auditLogsService, ITursoApiTokensService apiTokensService)
        {
            if (databaseService == null)
            {
                throw new ArgumentNullException("databaseService");
            }

            if (groupService == null)
            {
                throw new ArgumentNullException("groupService");
            }

            if (locationService == null)
            {
                throw new ArgumentNullException("locationService");
            }

            if (organizationsService == null)
            {
                throw new ArgumentNullException("organizationsService");
            }

            if (membersService == null)
            {
                throw new ArgumentNullException("membersService");
            }

            if (invitesService == null)
            {
                throw new ArgumentNullException("invitesService");
            }

            if (auditLogsService == null)
            {
                throw new ArgumentNullException("auditLogsService");
            }

            if (apiTokensService == null)
            {
                throw new ArgumentNullException("apiTokensService");
            }

            _databaseService = databaseService;
            _groupService = groupService;
            _locationService = locationService;
            _organizationsService = organizationsService;
            _membersService = membersService;
            _invitesService = invitesService;
            _auditLogsService = auditLogsService;
            _apiTokensService = apiTokensService;
        }

        public TursoPlatformService(string organizationSlug, string authToken)
        {
            IServiceProvider serviceProvider = new ServiceCollection()
                .AddTursoServices(new TursoAppSettings()
                {
                    AuthToken = authToken,
                    OrganizationSlug = organizationSlug,
                })
                .BuildServiceProvider();

            _databaseService = serviceProvider.GetRequiredService<ITursoDatabaseService>();
            _groupService = serviceProvider.GetRequiredService<ITursoGroupService>();
            _locationService = serviceProvider.GetRequiredService<ITursoLocationService>();
            _organizationsService = serviceProvider.GetRequiredService<ITursoOrganizationsService>();
            _membersService = serviceProvider.GetRequiredService<ITursoMembersService>();
            _invitesService = serviceProvider.GetRequiredService<ITursoInvitesService>();
            _auditLogsService = serviceProvider.GetRequiredService<ITursoAuditLogsService>();
            _apiTokensService = serviceProvider.GetRequiredService<ITursoApiTokensService>();
        }

        private TursoPlatformService()
        {
            IServiceProvider serviceProvider = new ServiceCollection()
                .AddTursoServices(_appSettings)
                .BuildServiceProvider();

            _databaseService = serviceProvider.GetRequiredService<ITursoDatabaseService>();
            _groupService = serviceProvider.GetRequiredService<ITursoGroupService>();
            _locationService = serviceProvider.GetRequiredService<ITursoLocationService>();
            _organizationsService = serviceProvider.GetRequiredService<ITursoOrganizationsService>();
            _membersService = serviceProvider.GetRequiredService<ITursoMembersService>();
            _invitesService = serviceProvider.GetRequiredService<ITursoInvitesService>();
            _auditLogsService = serviceProvider.GetRequiredService<ITursoAuditLogsService>();
            _apiTokensService = serviceProvider.GetRequiredService<ITursoApiTokensService>();
        }

        #endregion

        #region Properties

        public static TursoPlatformService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TursoPlatformService();
                }
                return _instance;
            }
        }

        public ITursoDatabaseService Databases => _databaseService;

        public ITursoGroupService Groups => _groupService;

        public ITursoLocationService Locations => _locationService;

        public ITursoOrganizationsService Organizations => _organizationsService;

        public ITursoMembersService Members => _membersService;

        public ITursoInvitesService Invites => _invitesService;

        public ITursoAuditLogsService AuditLogs => _auditLogsService;

        public ITursoApiTokensService ApiTokens => _apiTokensService;

        #endregion

        #region Public Methods

        public static void Initialize(string organizationSlug, string authToken)
        {
            _appSettings = new TursoAppSettings()
            {
                AuthToken = authToken,
                OrganizationSlug = organizationSlug,
            };
        }

        #endregion
    }
}
