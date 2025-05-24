using SmartHome.Data.Context;
using SmartHome.Data.Repositories;
using Microsoft.Data.SqlClient;
using SmartHome.Application.Interfaces;
using SmartHome.Application.Services;
using SmartHome.Data.Services;
namespace SmartHome.Application
{
    public static class ServiceProviderExtensions
    {
        public static void AddStartServices(this IServiceCollection services)
        {
            //services.AddSingleton<SmartHomeDBContext>(new SmartHomeDBContext(connectionString));
            services.AddScoped<IDeviceFactory, DeviceFactory>();
            services.AddScoped<IRoomServices, RoomServices>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            // В случае, если сервис запущен не на моей машине, то разработка ведется через List
            if (Environment.MachineName.Equals("DESKTOP-F6VA77D"))
            {
                services.AddScoped<IRoomRepository, RoomRepository>();
            }
            else
            {
                services.AddSingleton<IRoomRepository, RoomRepositoryTestWithoutDB>();
            }
        }
        public static void AddSqlService(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<SmartHomeDBContext>();
            services.AddScoped<SqlConnection>(_ => new SqlConnection(connectionString));
        }
    }
}
