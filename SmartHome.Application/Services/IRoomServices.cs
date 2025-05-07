using SmartHome.Data.Models;
using SmartHome.Data.Interfaces;
namespace SmartHome.Application.Services
{
    public interface IRoomServices
    {
        public Task<ApiResponse<List<Room>>> GetRooms();
        public Task<ApiResponse<Room>> GetRoom(Guid roomId);
        public Task<ApiResponse<Room>> AddRoom(Room room);
        public Task<ApiResponse<Room>> UpdateRoom(Room room);
        public Task AddDeviceToRoom(AddDeviceToRoomDTO userData);
        public Task RemoveDeviceFromRoomById(Room room, int deviceId);
        public Task<ApiResponse<object>> RemoveRoom(Guid roomId);
    }
}
