namespace SmartHome.Data.Models
{
    public record Room
    {
        public Guid ID { get; init; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<IDevice> Devices { get; set; } = [];
        public double Temperature { get; set; } = 21;
    }
}
