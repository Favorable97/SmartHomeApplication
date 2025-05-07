
namespace SmartHome.Data.Models
{
    public record Chandelier : IDevice
    {
        private bool _isOn;
        public Guid ID { get; init; }
        public string Name { get; init; } = "Люстра";
        public DevicesType Type { get; init; } = DevicesType.Chandelier;
        public string GetStatus() => _isOn ? "Люстра в комнате включена" : "Люстра в комнате выключена";
        public void TurnOn() => _isOn = true;
        public void TurnOff() => _isOn = false;
    }
}
