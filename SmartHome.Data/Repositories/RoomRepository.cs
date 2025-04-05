using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SmartHome.Data.Context;
using SmartHome.Data.Models;

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
        public async Task<Room?> GetRoom(Guid roomId)
        {
            string query = "SELECT *  FROM Room WHERE ID = @ID";
            SqlParameter[] sql_params =
            [
                new() { ParameterName = "@ID", SqlDbType = SqlDbType.UniqueIdentifier, Value = roomId },
            ];
            DataTable resultTable =  await _context.ExecuteReader(query, sql_params);
            if (resultTable.Rows.Count == 0)
                return null;
            Room room = new() { ID = (Guid)resultTable.Rows[0]["ID"], Name = resultTable.Rows[0]["Name"].ToString()!, Temperature = (double)resultTable.Rows[0]["Temperature"] };
            return room;
        }
        public async Task AddRoom(Room room)
        {
            string query = "INSERT INTO Room VALUES(@ID, @Name, @Temperature)";
            SqlParameter[] sql_params = 
            [
                new(){ ParameterName = "@ID", SqlDbType = SqlDbType.UniqueIdentifier, Value = room.ID },
                new(){ ParameterName = "@Name", SqlDbType = SqlDbType.VarChar, Value = room.Name },
                new(){ ParameterName = "@Temperature", SqlDbType = SqlDbType.Float, Value = room.Temperature }
            ];
            await _context.ExecuteAsync(query, sql_params);
        }
        public async Task UpdateRoom(Room room)
        {
            string query = "UPDATE Room SET Name = @Name WHERE ID = @ID";
            SqlParameter[] sql_params =
            [
                new() { ParameterName = "@ID", SqlDbType = SqlDbType.UniqueIdentifier, Value = room.ID },
                new() {ParameterName = "@Name", SqlDbType = SqlDbType.VarChar, Value = room.Name }
            ];
            await _context.ExecuteAsync(query, sql_params);
        }
        public Task AddDeviceToRoom(Guid roomId, IDevice device)
        {
            throw new NotImplementedException();
        }
        public Task RemoveDeviceFromRoomById(Room room, int deviceId)
        {
            throw new NotImplementedException();
        }
        public async Task RemoveRoom(Guid roomId)
        {
            string query = "DELETE Room WHERE ID = @ID";
            SqlParameter[] sql_params =
            [
                new() { ParameterName = "@ID", SqlDbType = SqlDbType.UniqueIdentifier, Value = roomId },
            ];
            await _context.ExecuteAsync(query, sql_params);
        }
    }
}
