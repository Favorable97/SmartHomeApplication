using SmartHome.Data.Enumerables;

namespace SmartHome.Application.DTO
{
    public class AddDeviceToRoomDTO
    {
        public Guid DeviceID { get; set; }
        public Guid RoomId { get; set; }
        public DevicesType DeviceType { get; set; }
        public string DeviceName { get; set; } = string.Empty;
        public double? WorkTemperature { get; set; }
    }
}
