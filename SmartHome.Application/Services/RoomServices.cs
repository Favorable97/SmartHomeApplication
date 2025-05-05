using SmartHome.Data.Interfaces;
using SmartHome.Data.Repositories;

namespace SmartHome.Application.Services
{
    public class RoomServices(IRoomRepository repository) : IRoomServices
    {
        private IRoomRepository _repository = repository;
        public async Task<List<Room>> GetRooms()
        {
            return await _repository.GetRooms();
        }
        public async Task AddRoom(Room room)
        {
            await _repository.AddRoom(room);
        }
        public async Task<Room> GetRoom(Guid id)
        {
            return await _repository.GetRoom(id);
        }
        public Task AddDeviceToRoom(Guid roomId, IDevice device)
        {
            throw new NotImplementedException();
        }
        public Task RemoveDeviceFromRoomById(Room room, int deviceId)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateRoom(Room room)
        {
            return await _repository.UpdateRoom(room);
        }
        public async Task RemoveRoom(Guid roomId)
        {
            await _repository.RemoveRoom(roomId);
        }
    }
}
