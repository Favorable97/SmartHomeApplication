namespace SmartHome.Data.Interfaces
{
    public interface IDevice
    {
        Guid ID { get; init; }
        string Name { get; init; }
        DevicesType Type { get; init; }
        string GetStatus();
        void TurnOn();
        void TurnOff();
    }
}
