
namespace SmartHome.Data.Models
{
    public record Spots : IDevice
    {
        public Guid ID { get; init; }
        public string Name { get; init; } = "Споты";
        public DevicesType Type { get; init; } = DevicesType.Spots;
    }
}
