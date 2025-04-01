namespace SmartHome.Data.Models
{
    public record Room
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<IDevice> Devices { get; set; } = [];
        public double Temperature { get; set; } = 21;
    }
}
