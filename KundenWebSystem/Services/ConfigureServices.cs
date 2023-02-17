using Microsoft.Extensions.DependencyInjection;

namespace KundenWebSystem.Services
{
    public static class ConfigureServices
    {
        public static void ConfigureKWSServices(this IServiceCollection services)
        {
            services.AddSingleton<SessionStorageService>();
            // Configure KWS Services here
        }
    }
}