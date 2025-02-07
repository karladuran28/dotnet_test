using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
  public DbSet<Formulario> Formularios {get; set;}
  public DbSet<Input> Inputs {get; set;}
  public DbSet<RespuestaFormulario> RespuestasFormularios {get; set;}
  public DbSet<RespuestaInput> RespuestasInputs {get; set;}
}