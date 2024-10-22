
using DataAccess.DbAccess;
using MessagingApplication;
using MessagingService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddSingleton<ISqlAccess, SqlAccess>();
builder.Services.AddSingleton<IApplication, Application>();

var app = builder.Build();
app.UseRouting();

app.MapGrpcService<MessagingGrpsApplication>();
app.MapGrpcService<ChatGrpcApplication>();

app.Run();
