using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SmartHome.Data.Context;
using SmartHome.Data.Utils;

namespace SmartHome.Data.Repositories
{
    public class RoomRepository(SmartHomeDBContext context) : IRoomRepository
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
            SqlParameter _id = new()
            {
                ParameterName = "@ID",
                Value = roomId
            };
            DataTable resultTable = await _context.ExecuteReader(query, _id);
            if (resultTable.Rows.Count == 0)
                return null;
            Room? room = Utils.Utils.GetRoomList(resultTable).FirstOrDefault();
            return room;
        }
        public async Task AddRoom(Room room)
        {
            string query = "INSERT INTO Room VALUES(@ID, @Name, @Temperature)";
            SqlParameter[] parameters =
            [
                new("@ID", room.ID),
                new("@Name", room.Name),
                new("@Temperature", room.Temperature)
            ];
            await _context.ExecuteAsync(query, parameters);
        }
        public async Task<bool> UpdateRoom(Room room)
        {
            Room? _room = await GetRoom(room.ID);
            if (_room is null) return false;
            string query = "UPDATE Room SET Name = @Name WHERE ID = @ID";
            SqlParameter[] parameters =
            [
                new("@ID", room.ID),
                new("@Name", room.Name)
            ];
            int updateRow = await _context.ExecuteAsync(query, parameters);
            return updateRow > 0;
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
            SqlParameter _id = new()
            {
                ParameterName = "@ID",
                Value = roomId
            };
            await _context.ExecuteAsync(query, _id);
        }
    }
}
