namespace SmartHome.Data.Models
{
    public record TV : IDevice
    {
        private bool _isOn;
        public Guid ID { get; init; }
        public string Name { get; init; } = "Телевизор";
        public DevicesType Type { get; init; } = DevicesType.TV;
        public string GetStatus() => _isOn ? "Телевизор включен" : "Телевизор выключен";
        public void TurnOn() => _isOn = true;
        public void TurnOff() => _isOn = false;
    }
}
