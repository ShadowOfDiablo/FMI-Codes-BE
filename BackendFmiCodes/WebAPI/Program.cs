using Domain.Entities;
using Domain.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database config
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<FmiDatabaseConfig>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    ));


//MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(RegisterHandler).Assembly,
        typeof(CompareSignatureHandler).Assembly
    );
});



//Add Controllers
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

// Enable Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();
