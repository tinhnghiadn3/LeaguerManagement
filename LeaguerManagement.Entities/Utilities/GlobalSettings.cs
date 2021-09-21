using LeaguerManagement.Entities.Utilities.Helper;
using Microsoft.Extensions.Configuration;

namespace LeaguerManagement.Entities.Utilities
{
    public static class GlobalSettingHelper
    {
        public static GlobalSettings GetGlobalSettings(this IConfiguration configuration)
        {
            return configuration.GetSection("GlobalSettings").Value.JsonToObject<GlobalSettings>();
        }
    }

    public class GlobalSettings
    {
        public string RunningMode { get; set; }
        public Token Token { get; set; }
        public string ConnectionStrings { get; set; }
        public int StaticFilesCachedHours { get; set; }
        public int MaxFilesPerRequest { get; set; }
        public int MaxFileSize { get; set; }
        public int MaxFileNameLength { get; set; }
        public int DefaultPerformancePeriodReview { get; set; }
        public float TimeZoneDefault { get; set; }
    }

    public class Token
    {
        public string TokenSecretKey { get; set; }
        public string TokenStartWith { get; set; }
        public int Expires { get; set; }
        public int LongExpires { get; set; }
    }
}