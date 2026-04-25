using MotorcycleApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IMotorcycleService, MotorcycleService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();