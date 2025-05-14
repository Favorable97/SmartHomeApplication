using SmartHome.Data.Enumerables;
using SmartHome.Data.Interfaces;
using SmartHome.Data.Models;
using SmartHome.Data.Repositories;

namespace SmartHome.Application.Services
{
    public class RoomServices(IRoomRepository repository, IDeviceFactory deviceFactory) : IRoomServices
    {
        private IRoomRepository _repository = repository;
        private IDeviceFactory _deviceFactory = deviceFactory;
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
        public async Task<ApiResponse<IDevice>> AddDeviceToRoom(AddDeviceToRoomDTO userData)
        {
            Room room = await _repository.GetRoom(userData.RoomId);
            if (room is null)
                return ApiResponse<IDevice>.Error($"Комнаты с ID = {userData.RoomId} не существует!");
            IDevice device = deviceFactory.CreateDevice(
                Guid.NewGuid(), 
                userData.DeviceType, 
                userData.DeviceName, 
                userData.WorkTemperature ?? 0
            );
            await _repository.AddDeviceToRoom(userData.RoomId, device);

            return ApiResponse<IDevice>.Ok(device, $"Устройство {userData.DeviceName} успешно добавлено в комнату ");
        }
        public Task RemoveDeviceFromRoomById(Room room, int deviceId)
        {
            throw new NotImplementedException();
        }
    }
}
