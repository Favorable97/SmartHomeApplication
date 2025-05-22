using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Interfaces
{
    public interface IDeviceRepository
    {
        public Task<List<IDevice>> GetDevicesByRoomId(Guid roomId);
        public Task<IDevice> GetDeviceById(Guid deviceId);
    }
}
