using SmartHome.Application.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddStartServices();
builder.Services.AddSqlService(builder.Configuration.GetConnectionString("mssql")!);
var app = builder.Build();
app.ErrorHandlerMiddleware();

app.MapGet("/api/room", async (IRoomServices service) => Results.Json(await service.GetRooms()));
app.MapGet("/api/room/{roomId}", async (Guid roomId, IRoomServices services) =>
{
    var result = await services.GetRoom(roomId);
    return result.Data is not null ? Results.Ok(result) : Results.NotFound(result);
});
app.MapPost("/api/room", async (IRoomServices service, Room room) =>
{
    var result = await service.AddRoom(room);
    return result.Success ? 
        Results.Created($"/api/room/{room.ID}", room) 
        : Results.BadRequest(result);
});
app.MapPut("/api/room", async (IRoomServices service, Room room) =>
{
    var result = await service.UpdateRoom(room);
    return result.Success ? Results.Ok(result) : Results.NotFound(result);
});
app.MapDelete("/api/room/{roomId}", async (IRoomServices service, Guid roomId) =>
{
    await service.RemoveRoom(roomId);
    return Results.NoContent();
});
app.MapPost("/api/device", async (IRoomServices service, AddDeviceToRoomDTO userData) =>
{
    
    await service.AddDeviceToRoom(userData);
    return Results.Created();
});
app.Run();
