namespace SmartHome.Data.Repositories
{
    public interface IRoomRepositury
    {
        public Task<List<Room>> GetRooms();
        public Task<Room> GetRoom(int id);
        public Task AddRoom(Room room);
        public Task UpdateRoom(Room room);
        public Task AddDeviceToRoom(int id, IDevice device);
        public Task RemoveRoom(int id);
    }
}
