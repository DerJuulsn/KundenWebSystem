using KundenWebSystem.Data;
using KundenWebSystem.Data.Eventseite;
using Microsoft.Extensions.DependencyInjection;

namespace KundenWebSystem.Services
{
    public static class ConfigureServices
    {
        public static void ConfigureKWSServices(this IServiceCollection services)
        {
            services.AddScoped<SessionStorageService>();
            // Configure KWS Services here
            services.AddScoped<EventService>();
            services.AddScoped<BookingService>();
        }
    }
}