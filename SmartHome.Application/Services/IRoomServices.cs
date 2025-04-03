using SmartHome.Data.Models;
using SmartHome.Data.Interfaces;
namespace SmartHome.Application.Services
{
    public interface IRoomServices
    {
        public Task<List<Room>> GetRooms();
        public Task<Room> GetRoom(int id);
        public Task AddRoom(Room room);
        public Task UpdateRoom(Room room);
        public Task AddDeviceToRoom(int id, IDevice device);
        public Task RemoveDeviceFromRoomById(Room room, int deviceId);
        public Task RemoveRoom(int id);
    }
}
