using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public static class Extensions
    {
        public static List<Room> ToRoomList(this DataTable table, IDeviceFactory deviceFactory)
        {
            var roomDict = new Dictionary<Guid, Room>();

            foreach (DataRow row in table.Rows)
            {
                Guid roomId = row.Field<Guid>("RoomID");
                string roomName = row.Field<string>("RoomName")!;
                double temperature = row.Field<Double>("RoomTemperature");

                if (roomDict.TryGetValue(roomId, out Room? room))
                {
                    room = new()
                    {
                        ID = roomId,
                        Name = roomName,
                        Temperature = temperature,
                        Devices = []
                    };
                    roomDict[roomId] = room;
                }
                Guid? deviceId = row.Field<Guid?>("DeviceID");
                if (deviceId.HasValue)
                {
                    IDevice? device = deviceFactory.CreateDevice(row);
                    if (device is not null)
                    {
                        room!.Devices.Add(device);
                    }
                }
            }
            return [.. roomDict.Values];
        }
    }
}
