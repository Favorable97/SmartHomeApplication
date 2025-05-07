using SmartHome.Data.Enumerables;

namespace SmartHome.Application.DTO
{
    public class AddDeviceToRoomDTO
    {
        public Guid ID { get; set; }
        public Guid RoomId { get; set; }
        public DevicesType DeviceType { get; set; }
        public string DeviceName { get; set; }
        public double? WorkTemperature { get; set; }
    }
}
