using Domain.Entities;
using Domain.Entities.Services;
using Domain.Handlers.Login;
using Domain.Services;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database config
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<FmiDatabaseConfig>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    ));


//MediatR
builder.Services.AddMediatR(cfg =>
{

    cfg.RegisterServicesFromAssembly(typeof(LoginRequestHandler).Assembly);
    
});

// Add Controllers
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

//Services 
builder.Services.AddScoped<LoginServices>();
builder.Services.AddScoped<ChallengeServices>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<PushNotificationServices>();


//Firebase 
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile("Firebase/fmi-codes-c283c-firebase-adminsdk-fbsvc-115446c519.json")
});

var app = builder.Build();

// Enable Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();   // <- това ти липсва

app.Run();
