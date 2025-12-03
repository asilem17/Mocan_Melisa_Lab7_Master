using Microsoft.EntityFrameworkCore;
using Mocan_Melisa_Lab2_Master.Data;
using GrpcCustomersService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryContext"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GrpcCRUDService>();
app.MapGet("/", () =>
    "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909"
);

app.Run();
