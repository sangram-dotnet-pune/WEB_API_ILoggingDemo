using Serilog;

var builder = WebApplication.CreateBuilder(args);

// --- Configure Serilog ---
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug() // You can set to Information, Warning, etc.
    .WriteTo.Console() // Logs to Console
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day) // Daily log files
    .Enrich.FromLogContext()
    .CreateLogger();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog();
builder.Logging.AddConsole();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
