namespace SmartHome.Data.Repositories
{
    public interface IRoomRepository
    {
        public Task<List<Room>> GetRooms();
        public Task<Room> GetRoom(Guid id);
        public Task AddRoom(Room room);
        public Task UpdateRoom(Room room);
        public Task AddDeviceToRoom(Guid roomId, IDevice device);
        public Task RemoveDeviceFromRoomById(Room room, int deviceId);
        public Task RemoveRoom(Guid roomId);
    }
}
