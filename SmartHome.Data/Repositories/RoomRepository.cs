using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHome.Data.Context;
using SmartHome.Data.Utils;

namespace SmartHome.Data.Repositories
{
    public class RoomRepository(SmartHomeDBContext context) : IRoomRepositury
    {
        private readonly SmartHomeDBContext _context = context;
        public async Task<List<Room>> GetRooms()
        {
            string query = "SELECT * FROM vw_Rooms";
            DataTable resultTable = await _context.ExecuteReader(query);
            List<Room> result = Utils.Utils.GetRoomList(resultTable);
            return result;
        }
        public async Task<Room?> GetRoom(Guid roomId)
        {
            string query = "SELECT * FROM vw_Rooms WHERE RoomID = @ID";
            List<SqlParam> sqlParams = [new SqlParam("@ID", roomId)];
            DataTable resultTable = await _context.ExecuteReader(query, sqlParams);
            if (resultTable.Rows.Count == 0)
                return null;
            Room? room = Utils.Utils.GetRoomList(resultTable).FirstOrDefault();
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
            string query = "DELETE FROM Room WHERE ID = @ID";
            List<SqlParam> sqlParams = new();
            sqlParams.Add(new("@ID", roomId));
            await _context.ExecuteAsync(query, sqlParams);
        }
    }
}
