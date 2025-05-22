using Microsoft.Data.SqlClient;
using SmartHome.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Repositories
{
    public class DeviceRepository(SmartHomeDBContext context, IDeviceFactory deviceFactory) : IDeviceRepository
    {
        private readonly SmartHomeDBContext _context = context;
        private readonly IDeviceFactory _deviceFactory = deviceFactory;
        public async Task<List<IDevice>> GetDevicesByRoomId(Guid roomId)
        {
            string query = "SELECT * FROM Device WHERE RoomID = @RoomID";
            SqlParameter parameter = new()
            {
                ParameterName = "@RoomID",
                Value = roomId
            };
            DataTable resultTable = await _context.ExecuteReader(query, parameter);
            return resultTable.ToDeviceList(_deviceFactory);
        }
        public async Task<IDevice?> GetDeviceById(Guid deviceId)
        {
            string query = "SELECT * FROM Device WHERE ID = @DeviceID";
            SqlParameter parameter = new()
            {
                ParameterName = "@DeviceID",
                Value = deviceId
            };
            DataTable resultTable = await _context.ExecuteReader(query, parameter);
            return resultTable.ToDeviceList(_deviceFactory).First() ?? null;
        }
    }
}
