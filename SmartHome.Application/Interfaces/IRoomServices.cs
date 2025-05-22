using SmartHome.Data.Models;
using SmartHome.Data.Interfaces;
namespace SmartHome.Application.Interfaces
{
    public interface IRoomServices
    {
        public Task<ApiResponse<List<Room>>> GetRooms();
        public Task<ApiResponse<Room>> GetRoom(Guid roomId);
        public Task<ApiResponse<Room>> AddRoom(Room room);
        public Task<ApiResponse<Room>> UpdateRoom(Room room);
        public Task<ApiResponse<IDevice>> AddDeviceToRoom(AddDeviceToRoomDTO userData);
        public Task<ApiResponse<object>> RemoveDeviceFromRoomById(DeleteDeviceFromRoomDTO userData);
        public Task<ApiResponse<object>> RemoveRoom(Guid roomId);
    }
}
