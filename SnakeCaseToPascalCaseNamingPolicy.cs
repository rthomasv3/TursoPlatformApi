using System.Text.Json;

namespace TursoPlatformApi
{
    internal class SnakeCaseToPascalCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            var parts = name.Split('_');

            for (int i = 0; i < parts.Length; i++)
            {
                if (string.IsNullOrEmpty(parts[i]))
                    continue;

                parts[i] = char.ToUpper(parts[i][0]) + parts[i].Substring(1);
            }

            return string.Concat(parts);
        }
    }
}
