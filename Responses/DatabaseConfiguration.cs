namespace TursoPlatformApi.Responses
{
    public class DatabaseConfiguration
    {
        public string size_limit { get; set; }
        public bool allow_attach { get; set; }
        public bool block_reads { get; set; }
        public bool block_writes { get; set; }
    }
}
