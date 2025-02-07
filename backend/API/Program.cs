using API.Data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Cargar variables de entorno
Env.Load();
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataContext>(opt => 
{
  var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
  opt.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddCors();

builder.Services.AddScoped<IFormularioRepository, FormularioRepository>();
builder.Services.AddScoped<IInputRepository, InputRepository>();

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
  .WithOrigins("http://localhost:5173", "https://localhost:5173"));

app.MapControllers();
app.Run();
