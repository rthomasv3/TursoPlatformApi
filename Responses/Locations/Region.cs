namespace TursoPlatformApi.Responses.Locations
{
    public class Region
    {
        /// <summary>
        /// The location code for the server responding.
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// The location code for the client request.
        /// </summary>
        public string Client { get; set; }
    }
}
