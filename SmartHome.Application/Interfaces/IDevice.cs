namespace SmartHome.Application.Interfaces
{
    public interface IDevice
    {
        public Guid ID { get; init; }
        public string Name { get; init; }
        public DevicesType Type { get; init; }
    }
}
