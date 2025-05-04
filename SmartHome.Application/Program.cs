using SmartHome.Application;
using SmartHome.Application.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddStartServices();
builder.Services.AddSqlService(builder.Configuration.GetConnectionString("mssql")!);
var app = builder.Build();
app.ErrorHandlerMiddleware();

app.MapGet("/api/room", async (IRoomServices service) => Results.Json(await service.GetRooms()));
app.MapGet("/api/room/{roomId}", async (Guid roomId, IRoomServices services) => 
    await services.GetRoom(roomId) is Room room
    ? Results.Json(room)
    : Results.NotFound()
);
app.MapPost("/api/room", async (IRoomServices service, Room room) =>
{
    await service.AddRoom(room);
    return Results.Created($"/api/room/{room.ID}", room);
});
app.MapPut("/api/room", async (IRoomServices service, Room room) =>
{
    bool success = await service.UpdateRoom(room);
    if (!success)
        return Results.NotFound($"������� � ID = {room.ID} �� �������!");
    return Results.Ok("��������� ������� �������!");
});
app.MapDelete("/api/room/{roomId}", async (IRoomServices service, Guid roomId) =>
{
    await service.RemoveRoom(roomId);
    return Results.NoContent();
});
app.Run();
