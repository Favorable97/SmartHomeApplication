namespace SmartHome.Data.Interfaces
{
    public interface IRoomRepository
    {
        public Task<List<Room>> GetRooms();
        public Task<Room> GetRoom(Guid id);
        public Task AddRoom(Room room);
        public Task UpdateRoom(Room room);
        public Task AddDeviceToRoom(Guid roomId, IDevice device);
        public Task RemoveDeviceFromRoomById(Guid deviceId);
        public Task RemoveRoom(Guid roomId);
    }
}
