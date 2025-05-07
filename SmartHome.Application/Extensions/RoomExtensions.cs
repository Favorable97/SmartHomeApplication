using System.Data;
using SmartHome.Data.Interfaces;

namespace SmartHome.Application.Extensions
{
    public static class RoomExtensions()
    {
        
        public static List<Room> GetRooms(this DataTable dataTable)
        {
            var roomDict = new Dictionary<Guid,  Room>();

            foreach (DataRow row in dataTable.Rows)
            {
                Guid roomId = row.Field<Guid>("RoomID");
                string roomName = row.Field<string>("RoomName")!;
                double temperature = row.Field<Double>("RoomTemperature");

                if (!roomDict.TryGetValue(roomId, out Room room))
                {
                    room = new Room
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
                    IDevice? device = CreateNewDevice(row);
                    if (device is not null)
                    {
                        room!.Devices.Add(device);
                    }
                }
            }
    }
}
