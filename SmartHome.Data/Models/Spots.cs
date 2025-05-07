
namespace SmartHome.Data.Models
{
    public record Spots : IDevice
    {
        private bool _isOn;
        public Guid ID { get; init; }
        public string Name { get; init; } = "Споты";
        public DevicesType Type { get; init; } = DevicesType.Spots;
        public string GetStatus() => _isOn ? "Споты в комнате включены" : "Споты в комнате выключены";
        public void TurnOn() => _isOn = true;
        public void TurnOff() => _isOn = false;
    }
}
