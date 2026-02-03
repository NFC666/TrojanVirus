using VirusSignalR.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseRouting();
app.MapHub<VirusHub>("/virushub");

app.Run();
