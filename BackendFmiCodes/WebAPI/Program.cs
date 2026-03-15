using Domain.CheckStatus.JwtServices;
using Domain.Entities;
using Domain.Entities.Services;
using Domain.Handlers.Login;
using Domain.Services;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()    // Позволява заявки от всякъде (за тестове е супер)
                .AllowAnyHeader()    // Позволява всякакви хедъри (Content-Type, Authorization и т.н.)
                .AllowAnyMethod();   // Позволява GET, POST, PUT, DELETE и т.н.
        });
});
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
builder.Services.AddScoped<JwtService>();


//Firebase 
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile("Firebase/fmi-codes-c283c-firebase-adminsdk-fbsvc-366485ffa1.json")
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FmiDatabaseConfig>();
    // Това ще приложи всички миграции, които не са в базата още
    dbContext.Database.Migrate(); 
}
// Enable Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();   // <- това ти липсва

app.Run();
