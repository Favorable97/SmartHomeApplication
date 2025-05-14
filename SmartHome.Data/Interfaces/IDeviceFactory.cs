using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Interfaces
{
    public interface IDeviceFactory
    {
        IDevice CreateDevice(DataRow row);
        IDevice CreateDevice(Guid deviceId, DevicesType deviceType, string deviceName, double workTemperature = 0.0);
    }
}
