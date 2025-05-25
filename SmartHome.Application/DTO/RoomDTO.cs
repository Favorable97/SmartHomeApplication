namespace SmartHome.Application.DTO
{
    public class RoomDTO
    {
        public Guid ID { get; init; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<DeviceDTO> Devices { get; set; } = [];
    }
}
