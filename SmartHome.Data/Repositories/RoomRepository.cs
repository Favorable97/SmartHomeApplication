using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SmartHome.Data.Context;

namespace SmartHome.Data.Repositories
{
    public class RoomRepository(SmartHomeDBContext context) : IRoomRepositury
    {
        private readonly SmartHomeDBContext _context = context;

        public async Task<List<Room>> GetRooms()
        {
            string query = "SELECT * FROM Room";
            DataTable resultTable = await _context.ExecuteReader(query);
            List<Room> result = [];
            foreach (DataRow row in resultTable.Rows)
            {
                result.Add(new Room() { ID = (Guid)row["ID"], Name = row["Name"].ToString()!, Temperature = (double)row["Temperature"] });
            }
            return result;
        }
        public Task<Room> GetRoom(int roomId)
        {
            throw new NotImplementedException();
        }
        public async Task AddRoom(Room room)
        {
            string query = "INSERT INTO Room VALUES(@ID, @Name, @Temperature)";
            SqlParameter[] sql_params = 
            [
                new(){ParameterName = "@ID", DbType = System.Data.DbType.Guid, Value = room.ID},
                new(){ParameterName = "@Name", SqlDbType = System.Data.SqlDbType.VarChar, Value = room.Name},
                new(){ParameterName = "@Temperature", SqlDbType = System.Data.SqlDbType.Float, Value = room.Temperature}
            ];
            await _context.ExecuteAsync(query, sql_params);
        }
        public Task UpdateRoom(Room room)
        {
            throw new NotImplementedException();
        }
        public Task AddDeviceToRoom(int roomId, IDevice device)
        {
            throw new NotImplementedException();
        }
        public Task RemoveDeviceFromRoomById(Room room, int deviceId)
        {
            throw new NotImplementedException();
        }
        public Task RemoveRoom(int roomId)
        {
            throw new NotImplementedException();
        }
    }
}
