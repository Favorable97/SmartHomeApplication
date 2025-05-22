namespace SmartHome.Application.DTO
{
    public class DeleteDeviceFromRoomDTO
    {
        public Guid RoomID { get; set; }
        public Guid DeviceID { get; set; }
    }
}
