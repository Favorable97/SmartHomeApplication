using SmartHome.Data.Interfaces;
using SmartHome.Data.Repositories;

namespace SmartHome.Application.Services
{
    public class RoomServices(IRoomRepositury repository) : IRoomServices
    {
        private IRoomRepositury _repository = repository;
        public Task AddDeviceToRoom(int id, IDevice device)
        {
            throw new NotImplementedException();
        }

        public async Task AddRoom(Room room)
        {
            await _repository.AddRoom(room);
        }

        public Task<Room> GetRoom(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _repository.GetRooms();
        }

        public Task RemoveDeviceFromRoomById(Room room, int deviceId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRoom(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRoom(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
