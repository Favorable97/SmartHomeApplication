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
        public async Task<ApiResponse<Room>> AddRoom(Room userData)
        {
            Room? room = await _repository.GetRoom(userData.ID);
            if (room is not null)
                return ApiResponse<Room>.Error("Комната с таким идентификатором уже существует!");
            await _repository.AddRoom(userData);
            return ApiResponse<Room>.Ok(userData, "Комната успешно добавлена!");
        }
        public async Task<ApiResponse<Room>> UpdateRoom(Room userData)
        {
            Room? room = await _repository.GetRoom(userData.ID);
            if (room is null)
                return ApiResponse<Room>.Error($"Комнаты с ID = {userData.ID} не существует!");
            await _repository.UpdateRoom(userData);
            return ApiResponse<Room>.Ok(userData, $"Комната с ID = {userData.ID} успешно обновлена");
        }
        public async Task<ApiResponse<object>> RemoveRoom(Guid roomId)
        {
            Room? room = await _repository.GetRoom(roomId);
            if (room is null)
                return ApiResponse<object>.Error($"Комнаты с ID = {roomId} не существует!");
            await _repository.RemoveRoom(roomId);
            return ApiResponse<object>.Ok(null, "Комната удалена!");
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
