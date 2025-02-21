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

        /// <summary>
        /// Creates a new instance of the <see cref="TursoPlatformService"/>.
        /// </summary>
        /// <remarks>Not recommended for manual use. Used in DI.</remarks>
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

        /// <summary>
        /// Create a new instance ofthe the <see cref="TursoPlatformService"/>.
        /// </summary>
        /// <param name="organizationSlug">The default organization to use when not provided to the method.</param>
        /// <param name="authToken">The Turso API auth token.</param>
        public TursoPlatformService(string organizationSlug, string authToken)
        {
            IServiceProvider serviceProvider = new ServiceCollection()
                .AddTursoServices(new TursoAppSettings()
                {
                    AuthToken = authToken,
                    DefaultOrganizationSlug = organizationSlug,
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

        /// <summary>
        /// Get or create a new static instance. Use <see cref="Initialize"/> first to set configuration options.
        /// </summary>
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

        /// <inheritdoc />
        public ITursoDatabaseService Databases => _databaseService;

        /// <inheritdoc />
        public ITursoGroupService Groups => _groupService;

        /// <inheritdoc />
        public ITursoLocationService Locations => _locationService;

        /// <inheritdoc />
        public ITursoOrganizationsService Organizations => _organizationsService;

        /// <inheritdoc />
        public ITursoMembersService Members => _membersService;

        /// <inheritdoc />
        public ITursoInvitesService Invites => _invitesService;

        /// <inheritdoc />
        public ITursoAuditLogsService AuditLogs => _auditLogsService;

        /// <inheritdoc />
        public ITursoApiTokensService ApiTokens => _apiTokensService;

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes the default organization and sets the platform API token.
        /// </summary>
        /// <param name="organizationSlug">The default organization to use when not provided to the method.</param>
        /// <param name="authToken">The Turso API auth token.</param>
        /// <remarks>This should be called before using <see cref="Instance"/>.</remarks>
        public static void Initialize(string organizationSlug, string authToken)
        {
            _appSettings = new TursoAppSettings()
            {
                AuthToken = authToken,
                DefaultOrganizationSlug = organizationSlug,
            };
        }

        #endregion
    }
}
