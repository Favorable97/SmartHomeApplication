using SmartHome.Application;
using SmartHome.Application.Middleware;
using SmartHome.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddStartServices();
builder.Services.AddSqlService(builder.Configuration.GetConnectionString("mssql")!);
var app = builder.Build();
app.ErrorHandlerMiddleware();

app.MapGet("/api/room", async (IRoomServices service) => Results.Json(await service.GetRooms()));
//app.MapGet("/api/room/{roomId}", async (Guid roomId, IRoomServices services) => 
//    (await services.GetRoom(roomId)).Data is Room room
//    ? Results.Ok(room)
//    : Results.NotFound()
//);
app.MapGet("/api/room/{roomId}", async (Guid roomId, IRoomServices services) =>
{
    var result = await services.GetRoom(roomId);
    return result.Data is not null ? Results.Ok(result) : Results.NotFound(result);
});
app.MapPost("/api/room", async (IRoomServices service, Room room) =>
{
    bool success = await service.AddRoom(room);
    return success ? 
        Results.Created($"/api/room/{room.ID}", room) 
        : Results.BadRequest("Комната с подобным идентификатором уже была создана! Попробуйте обновить страницу");
});
app.MapPut("/api/room", async (IRoomServices service, Room room) =>
{
    bool success = await service.UpdateRoom(room);
    if (!success)
        return Results.NotFound($"Комната с ID = {room.ID} не найдена!");
    return Results.Ok("Изменения успешно внесены!");
});
app.MapDelete("/api/room/{roomId}", async (IRoomServices service, Guid roomId) =>
{
    await service.RemoveRoom(roomId);
    return Results.NoContent();
});
app.MapPost("/api/device", async (IRoomServices service, Guid roomId, IDevice device) =>
{
    await service.AddDeviceToRoom(roomId, device);
    return Results.Created();
});
app.Run();
