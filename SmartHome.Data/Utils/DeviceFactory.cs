using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Utils
{
    public class DeviceFactory
    {
        public IDevice CreateDevice(DataRow row)
        {
            int typeId = row.Field<int>("DeviceType");
            DevicesType type = (DevicesType)typeId;
            return type switch
            {
                DevicesType.TV => new TV
                {
                    ID = row.Field<Guid>("DeviceID"),
                    Name = row.Field<string>("DeviceName")!
                },
                DevicesType.Chandelier => new Chandelier
                {
                    ID = row.Field<Guid>("DeviceID"),
                    Name = row.Field<string>("DeviceName")!
                },
                DevicesType.Spots => new Spots
                {
                    ID = row.Field<Guid>("DeviceID"),
                    Name = row.Field<string>("DeviceName")!
                },
                DevicesType.Conditioner => new Conditioner
                {
                    ID = row.Field<Guid>("DeviceID"),
                    Name = row.Field<string>("DeviceName")!,
                    WorkTemperature = row.Field<double?>("WorkTemperature") ?? 21
                },
                _ => throw new ArgumentException("Неизвестный тип устройства")
            };
        }
        /*public static List<Room> GetRoomList(DataTable roomsTable)
        {
            List<Room> roomList = [];

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
            return devicesType switch
            {
                DevicesType.TV => new TV() { ID = id, Name = name! },
                DevicesType.Conditioner => new Conditioner() { ID = id, Name = name!, WorkTemperature = (double)workTemperature! },
                DevicesType.Spots => new Spots() { ID = id, Name = name! },
                DevicesType.Chandelier => new Chandelier() { ID = id, Name = name! },
                _ => throw new ArgumentException("Неизвестный тип устройства"),
            };
        }*/
    }
}
