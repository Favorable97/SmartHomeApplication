using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public class DeviceFactory : IDeviceFactory
    {
        public IDevice? CreateDevice(DataRow row)
        {
            DevicesType deviceType = (DevicesType)row.Field<int>("DeviceType");
            return deviceType switch
            {
                DevicesType.TV => new TV() { ID = row.Field<Guid>("DeviceID"), Name = row.Field<string>("DeviceName")! },
                DevicesType.Conditioner => new Conditioner { ID = row.Field<Guid>("DeviceID"), Name = row.Field<string>("DeviceName")!, WorkTemperature = row.Field<double>("WorkTemperature") },
                DevicesType.Spots => new Spots() { ID = row.Field<Guid>("DeviceID"), Name = row.Field<string>("DeviceName")! },
                DevicesType.Chandelier => new Chandelier() { ID = row.Field<Guid>("DeviceID"), Name = row.Field<string>("DeviceName")! },
                _ => null
            };
        }
        public IDevice? CreateDevice(Guid deviceId, DevicesType deviceType, string deviceName, double workTemperature)
        {
            return deviceType switch
            {
                DevicesType.TV => new TV() { ID = deviceId, Name = deviceName! },
                DevicesType.Conditioner => new Conditioner { ID = deviceId, Name = deviceName!, WorkTemperature = workTemperature },
                DevicesType.Spots => new Spots() { ID = deviceId, Name = deviceName! },
                DevicesType.Chandelier => new Chandelier() { ID = deviceId, Name = deviceName! },
                _ => null
            };
        }
    }
}
