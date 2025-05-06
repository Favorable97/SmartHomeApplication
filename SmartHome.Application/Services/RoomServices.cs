using SmartHome.Data.Interfaces;
using SmartHome.Data.Repositories;

namespace SmartHome.Application.Services
{
    public class RoomServices(IRoomRepository repository) : IRoomServices
    {
        private IRoomRepository _repository = repository;
        public async Task<ApiResponse<List<Room>>> GetRooms()
        {
            var rooms = await _repository.GetRooms();
            return rooms.Count == 0
                ? ApiResponse<List<Room>>.Error("Комнат нет")
                : ApiResponse<List<Room>>.Ok(rooms);
        }
        public async Task<ApiResponse<Room>> GetRoom(Guid id)
        {
            Room? room = await _repository.GetRoom(id);
            return room is null  
                    ? ApiResponse<Room>.Error("Комната была удалена!")
                    : ApiResponse<Room>.Ok(room);
        }
        public async Task<ApiResponse<object>> AddRoom(Room userData)
        {
            Room? room = await _repository.GetRoom(userData.ID);
            if (room is not null)
                return ApiResponse<object>.Error("Комната с таким идентификатором уже существует!");
            await _repository.AddRoom(userData);
            return true;
        }
        public async Task<bool> UpdateRoom(Room userData)
        {
            Room? room = await _repository.GetRoom(userData.ID);
            if (room is null)
                return false;
            return await _repository.UpdateRoom(room);
        }
        public async Task RemoveRoom(Guid roomId)
        {
            Room? room = await _repository.GetRoom(roomId);
            if (room is not null)
                await _repository.RemoveRoom(roomId);
        }
        public Task AddDeviceToRoom(Guid roomId, IDevice device)
        {
            throw new NotImplementedException();
        }
        public Task RemoveDeviceFromRoomById(Room room, int deviceId)
        {
            throw new NotImplementedException();
        }
    }
}
