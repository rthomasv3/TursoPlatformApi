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

        private readonly IDatabaseService _databaseService;
        private readonly IGroupService _groupService;
        private readonly ILocationService _locationService;
        private readonly IOrganizationsService _organizationsService;
        private readonly IMembersService _membersService;
        private readonly IInvitesService _invitesService;
        private readonly IAuditLogsService _auditLogsService;
        private readonly IApiTokensService _apiTokensService;

        #endregion

        #region Constructors

        public TursoPlatformService(IDatabaseService databaseService, IGroupService groupService, ILocationService locationService,
            IOrganizationsService organizationsService, IMembersService membersService, IInvitesService invitesService,
            IAuditLogsService auditLogsService, IApiTokensService apiTokensService)
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

            _databaseService = serviceProvider.GetRequiredService<IDatabaseService>();
            _groupService = serviceProvider.GetRequiredService<IGroupService>();
            _locationService = serviceProvider.GetRequiredService<ILocationService>();
            _organizationsService = serviceProvider.GetRequiredService<IOrganizationsService>();
            _membersService = serviceProvider.GetRequiredService<IMembersService>();
            _invitesService = serviceProvider.GetRequiredService<IInvitesService>();
            _auditLogsService = serviceProvider.GetRequiredService<IAuditLogsService>();
            _apiTokensService = serviceProvider.GetRequiredService<IApiTokensService>();
        }

        private TursoPlatformService()
        {
            IServiceProvider serviceProvider = new ServiceCollection()
                .AddTursoServices(_appSettings)
                .BuildServiceProvider();

            _databaseService = serviceProvider.GetRequiredService<IDatabaseService>();
            _groupService = serviceProvider.GetRequiredService<IGroupService>();
            _locationService = serviceProvider.GetRequiredService<ILocationService>();
            _organizationsService = serviceProvider.GetRequiredService<IOrganizationsService>();
            _membersService = serviceProvider.GetRequiredService<IMembersService>();
            _invitesService = serviceProvider.GetRequiredService<IInvitesService>();
            _auditLogsService = serviceProvider.GetRequiredService<IAuditLogsService>();
            _apiTokensService = serviceProvider.GetRequiredService<IApiTokensService>();
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

        public IDatabaseService Databases => _databaseService;

        public IGroupService Groups => _groupService;

        public ILocationService Locations => _locationService;

        public IOrganizationsService Organizations => _organizationsService;

        public IMembersService Members => _membersService;

        public IInvitesService Invites => _invitesService;

        public IAuditLogsService AuditLogs => _auditLogsService;

        public IApiTokensService ApiTokens => _apiTokensService;

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
