using SmartHome.Data.Enumerables;

namespace SmartHome.Application.DTO
{
    public class DeviceDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = "";
        public DevicesType Type { get; set; }
        public double? WorkTemperature { get; set; }
    }
}
