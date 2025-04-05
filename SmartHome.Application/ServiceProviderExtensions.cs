using SmartHome.Application.Services;
using SmartHome.Data.Context;
using SmartHome.Data.Repositories;
namespace SmartHome.Application
{
    public static class ServiceProviderExtensions
    {
        public static void AddStartServices(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<SmartHomeDBContext>(new SmartHomeDBContext(connectionString));
            services.AddScoped<IRoomServices, RoomServices>();
            services.AddScoped<IRoomRepositury, RoomRepository>();
        }
    }
}
