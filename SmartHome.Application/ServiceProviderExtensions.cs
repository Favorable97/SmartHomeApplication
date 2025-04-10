using SmartHome.Application.Services;
using SmartHome.Data.Context;
using SmartHome.Data.Repositories;
using Microsoft.Data.SqlClient;
namespace SmartHome.Application
{
    public static class ServiceProviderExtensions
    {
        public static void AddStartServices(this IServiceCollection services)
        {
            //services.AddSingleton<SmartHomeDBContext>(new SmartHomeDBContext(connectionString));
            services.AddScoped<IRoomServices, RoomServices>();
            services.AddScoped<IRoomRepositury, RoomRepository>();
        }
        public static void AddSqlService(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<SmartHomeDBContext>();
            services.AddScoped<SqlConnection>(_ => new SqlConnection(connectionString));
        }
    }
}
