using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Utils
{
    internal class Utils
    {
        public static List<Room> GetRoomList(DataTable roomsTable)
        {
            List<Room> roomList = new();

            foreach (DataRow row in roomsTable.Rows)
            {
                Guid roomId = row.Field<Guid>("RoomID");
                string roomName = row.Field<string>("RoomName")!;
                double temperature = row.Field<Double>("RoomTemperature");

                Room? room = roomList.FirstOrDefault(r => r.ID == roomId);
                if (room == null)
                {
                    room = new Room
                    {
                        ID = roomId,
                        Name = roomName,
                        Temperature = temperature,
                        Devices = []
                    };
                    roomList.Add(room);
                }

                Guid? deviceId = row.Field<Guid?>("DeviceID");
                if (deviceId.HasValue)
                {
                    IDevice? device = CreateNewDevice(row);
                    if (device is not null)
                    {
                        room!.Devices.Add(device);
                    }
                }
            }

            return roomList;
        }

        private static IDevice? CreateNewDevice(DataRow row)
        {
            var (id, name, typeId, workTemperature) = (
                row.Field<Guid>("DeviceID"),
                row.Field<string>("DeviceName"),
                row.Field<int>("DeviceType"),
                row.Field<double?>("WorkTemperature")
            );

            DevicesType devicesType = (DevicesType)typeId;
            switch (devicesType)
            {
                case DevicesType.TV:
                    return new TV() { ID = id, Name = name! };
                case DevicesType.Conditioner:
                    return new Conditioner() { ID = id, Name = name!, WorkTemperature = (double)workTemperature! };
                case DevicesType.Spots:
                    return new Spots() { ID = id, Name = name! };
                case DevicesType.Chandelier:
                    return new Chandelier() { ID = id, Name = name! };
                default:
                    return null;
            }
        }
    }
}
