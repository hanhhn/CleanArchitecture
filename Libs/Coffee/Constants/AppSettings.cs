using Microsoft.Extensions.Configuration;

namespace Coffee.Constants
{
    public class AppSettings
    {
        public static AppSettings Instance { get; set; }
        public static IConfiguration Configs { get; set; }
    }
}

