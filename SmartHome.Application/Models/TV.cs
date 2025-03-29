namespace SmartHome.Application.Models
{
    public record TV : IDevice
    {
        public Guid ID { get; init; }
        public string Name { get; init; } = "Телевизор";
        public DevicesType Type { get; init; } = DevicesType.TV;
        public TV(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
