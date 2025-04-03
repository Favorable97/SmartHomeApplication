using SmartHome.Application.Services;
using SmartHome.Data.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<SmartHomeDBContext>(new SmartHomeDBContext(builder.Configuration.GetConnectionString("mssql")!));
builder.Services.AddScoped<IRoomServices, RoomServices>();
builder.Services.AddScoped<IRoomRepositury, RoomRepository>();
var app = builder.Build();


app.MapGet("/api/room/list", async (IRoomServices service) => Results.Ok(service.GetRooms()));

app.MapPost("/api/room/add", async (IRoomServices service, Room room) =>
{
    await service.AddRoom(room);
    return Results.Created($"/api/room/{room.ID}", room);
});

app.Run();
