
namespace SmartHome.Application.Models
{
    public record Conditioner : IDevice
    {
        public Guid ID { get; init; }
        public string Name { get; init; } = "Кондиционер";
        public DevicesType Type { get; init; } = DevicesType.Conditioner;
        public double WorkTemperature { get; init; }
        public Conditioner(int id, string name)
        {
            this.ID = id;
            this.Name = name;
            this.WorkTemperature = 21;
        }
        public Conditioner(int id, string name, double WorkTemperature)
        {
            this.ID = id;
            this.Name = name;
            this.WorkTemperature = WorkTemperature;
        }
    }
}
