﻿namespace TursoPlatformApi
{
    public class TursoAppSettings
    {
        public string OrganizationSlug { get; set; }
        public string AuthToken { get; set; }
        public string TursoClientName { get; set; } = "TursoClient";
        public string DefaultClientName { get; set; } = "DefaultClient";
    }
}
