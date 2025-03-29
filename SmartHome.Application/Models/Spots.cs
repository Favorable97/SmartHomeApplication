
namespace SmartHome.Application.Models
{
    public record Spots : IDevice
    {
        public Guid ID { get; init; }
        public string Name { get; init; } = "Споты";
        public DevicesType Type { get; init; } = DevicesType.Spots;
        public Spots(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
