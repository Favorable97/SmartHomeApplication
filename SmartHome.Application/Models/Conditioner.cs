
namespace SmartHome.Application.Models
{
    public record Conditioner : IDevice
    {
        public Guid ID { get; init; }
        public string Name { get; init; } = "Кондиционер";
        public DevicesType Type { get; init; } = DevicesType.Conditioner;
        public double WorkTemperature { get; init; } = 21.0;
        
    }
}
