using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHome.Data.Context;
using SmartHome.Data.Interfaces;
using SmartHome.Data.Models;

namespace SmartHome.Data.Repositories
{
    public class RoomRepositoryTestWithoutDB: IRoomRepository
    {
        
        /*List<Room> _rooms = [
            new Room() { Name = "Кухня-гостинная", Devices = [], Temperature = 25},
            new Room() { Name = "Маля комната", Devices = [], Temperature = 23},
            new Room() { Name = "Спальня", Devices = [], Temperature = 23},
        ];*/
        List<Room> _rooms;
        List<IDevice> _devices;
        public RoomRepositoryTestWithoutDB() 
        {
            _rooms = new List<Room>();
            _devices = new List<IDevice>();
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
        public async Task<bool> UpdateRoom(Room room)
        {
            try
            {
                Room? updateRoom = await GetRoom(room.ID);
                if (updateRoom is not null)
                {
                    updateRoom.Name = room.Name;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task RemoveRoom(Guid roomId)
        {
            Room? removeRoom = await GetRoom(roomId);
            if (removeRoom is not null)
            {
                _rooms.Remove(removeRoom);
            }
        }
        public async Task AddDeviceToRoom(Guid roomId, IDevice device)
        {
            Room? room = await GetRoom(roomId);
            if (room is not null)
            {
                room.Devices.Add(device);

            }
        }
        public async Task RemoveDeviceFromRoomById(Room room, int deviceId)
        {
            
        }

        

        
    }
}
