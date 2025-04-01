
namespace SmartHome.Data.Models
{
    public record Chandelier : IDevice
    {
        public Guid ID { get; init; }
        public string Name { get; init; } = "Люстра";
        public DevicesType Type { get; init; } = DevicesType.Chandelier;
    }
}
