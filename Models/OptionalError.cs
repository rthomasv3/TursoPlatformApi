namespace TursoPlatformApi.Models
{
    internal class OptionalError
    {
        public OptionalError(string status, string message)
        {
            Status = status;
            Message = message;
        }

        public string Status { get; private set; }
        public string Message { get; private set; }
    }
}
