
namespace SmartHome.Data.Models
{
    public record Conditioner : IDevice
    {
        private bool _isOn;
        public Guid ID { get; init; }
        public string Name { get; init; } = "Кондиционер";
        public DevicesType Type { get; init; } = DevicesType.Conditioner;
        public double WorkTemperature { get; init; } = 21.0;
        public string GetStatus() => _isOn ? $"Кондиционер в комнате включен. Выставленная температура: {WorkTemperature}" : "Кондиционер в комнате отключен";
        public void TurnOn() => _isOn = true;
        public void TurnOff() => _isOn = false;
    }
}
