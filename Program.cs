using MotorcycleApi.Services;
using MotorcycleApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IMotorcycleService, MotorcycleService>();

builder.Services.AddDbContext<MotorcycleContext>(options =>
options.UseSqlite("Data Source=motorcycles.db"));

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();