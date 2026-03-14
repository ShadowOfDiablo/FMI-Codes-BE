using Domain.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database config
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<FmiDatabaseConfig>(options =>
{
    if (!string.IsNullOrEmpty(connectionString))
    {
        options.UseMySql(
            connectionString,
            new MySqlServerVersion(new Version(8, 0, 31))
        );
    }
});


//MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

//Add Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Enable Swagger middleware for all environments to help debugging
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
    c.RoutePrefix = string.Empty; // Set Swagger at the root
});

app.MapGet("/health", () => Results.Ok("Service is running"));

app.MapControllers();

var port = Environment.GetEnvironmentVariable("PORT") ?? "33060";
app.Run($"http://0.0.0.0:8080");
