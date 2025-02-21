﻿namespace TursoPlatformApi.Responses.Locations
{
    public class Region
    {
        /// <summary>
        /// The location code for the server responding.
        /// </summary>
        public string server { get; set; }

        /// <summary>
        /// The location code for the client request.
        /// </summary>
        public string client { get; set; }
    }
}
