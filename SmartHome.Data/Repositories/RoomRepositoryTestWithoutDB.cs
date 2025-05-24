using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Repositories
{
    public class RoomRepositoryTestWithoutDB: IRoomRepository
    {
        
        /*List<Room> _rooms = [
            new Room() { Name = "Кухня-гостинная", Devices = [], Temperature = 25},
            new Room() { Name = "Маля комната", Devices = [], Temperature = 23},
            new Room() { Name = "Спальня", Devices = [], Temperature = 23},
        ];*/
        private List<Room> _rooms;
        private List<IDevice> _devices;
        public RoomRepositoryTestWithoutDB() 
        {
            _rooms = [];
            _devices = [];
        }
        public Task<List<Room>> GetRooms()
        {
            return Task.FromResult(_rooms);
        }
        public Task<Room?> GetRoom(Guid id)
        {
            Room? room = _rooms.FirstOrDefault(r => r.ID == id);
            return Task.FromResult(room);
        }
        public Task AddRoom(Room room)
        {
            _rooms.Add(room);
            return Task.CompletedTask;
        }
        public async Task UpdateRoom(Room room)
        {
            Room? updateRoom = await GetRoom(room.ID);
            updateRoom.Name = room.Name;
        }
        public async Task RemoveRoom(Guid roomId)
        {
            Room? removeRoom = await GetRoom(roomId)!;
            _rooms.Remove(removeRoom!);
        }
        public async Task AddDeviceToRoom(Guid roomId, IDevice device)
        {
            Room? room = await GetRoom(roomId);
            room!.Devices.Add(device);
            _devices.Add(device);
        }
        public async Task RemoveDeviceFromRoomById(Guid deviceId)
        {
            
        }

        

        
    }
}
