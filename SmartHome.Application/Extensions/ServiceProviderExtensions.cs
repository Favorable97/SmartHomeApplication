using SmartHome.Application.Services;
using SmartHome.Data.Context;
using SmartHome.Data.Repositories;
using Microsoft.Data.SqlClient;
using SmartHome.Data.Utils;
namespace SmartHome.Application.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddStartServices(this IServiceCollection services)
        {
            //services.AddSingleton<SmartHomeDBContext>(new SmartHomeDBContext(connectionString));
            services.AddScoped<IRoomServices, RoomServices>();
            // В случае, если сервис запущен не на моей машине, то разработка ведется через List
            if (Environment.MachineName.Equals("DESKTOP-F6VA77D"))
            {
                services.AddScoped<IRoomRepository, RoomRepository>();
            }
            else
            {
                services.AddSingleton<IRoomRepository, RoomRepositoryTestWithoutDB>();
            }
            services.AddSingleton<DeviceFactory>();
        }
        public static void AddSqlService(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<SmartHomeDBContext>();
            services.AddScoped(_ => new SqlConnection(connectionString));
        }
    }
}
