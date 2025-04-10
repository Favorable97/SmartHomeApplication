using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<Room?> GetRoom(Guid roomId)
        {
            string query = "SELECT *  FROM Room WHERE ID = @ID";
            List<SqlParam> sqlParams = [new SqlParam("@ID", roomId)];
            DataTable resultTable =  await _context.ExecuteReader(query, sqlParams);
            if (resultTable.Rows.Count == 0)
                return null;
            Room room = new() { ID = (Guid)resultTable.Rows[0]["ID"], Name = resultTable.Rows[0]["Name"].ToString()!, Temperature = (double)resultTable.Rows[0]["Temperature"] };
            return room;
        }
        public async Task AddRoom(Room room)
        {
            string query = "INSERT INTO Room VALUES(@ID, @Name, @Temperature)";
            List<SqlParam> sqlParams = new();
            sqlParams.Add(new("@ID", room.ID));
            sqlParams.Add(new("@Name", room.Name));
            sqlParams.Add(new("@Temperature", room.Temperature));
            await _context.ExecuteAsync(query, sqlParams);
        }
        public async Task UpdateRoom(Room room)
        {
            string query = "UPDATE Room SET Name = @Name WHERE ID = @ID";
            List<SqlParam> sqlParams = new();
            sqlParams.Add(new("@ID", room.ID));
            sqlParams.Add(new("@Name", room.Name));
            await _context.ExecuteAsync(query, sqlParams);
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
            List<SqlParam> sqlParams = new();
            sqlParams.Add(new("@ID", roomId));
            await _context.ExecuteAsync(query, sqlParams);
        }
    }
}
